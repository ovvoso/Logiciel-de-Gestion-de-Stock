using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DitiGestionStock.Model;

namespace DitiGestionStock.View
{
    public partial class frmProfil : Form
    {
        BdDitiGestionStockContext db = new BdDitiGestionStockContext();
        public frmProfil()
        {
            InitializeComponent();
        }

        private void frmProfil_Load(object sender, EventArgs e)
        {
            dgProfil.DataSource = db.profils.ToList();
            Effacer();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Profil p = new Profil();
            p.code = txtCode.Text;
            p.libelle = txtLibelle.Text;
            p.Description = txtDescription.Text;
            p.Status = cbbStatus.Text;
            db.profils.Add(p);
            db.SaveChanges();
            Effacer();
        }

        private void Effacer()
        {
            txtCode.Text = string.Empty;
            txtLibelle.Text = string.Empty;
            txtDescription.Text = string.Empty;
            cbbStatus.Text = string.Empty;
            dgProfil.DataSource = db.profils.ToList();
            txtCode.Focus();
        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            Effacer();
        }

       
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgProfil.CurrentRow.Cells[0].Value.ToString());
            var p = db.profils.Find(id);

            if (db.utilisateurs.Any(u => u.IdProfil == id))
            {
                MessageBox.Show("Impossible de supprimer ce profil car il est référencé par les utilisateurs.");
                return;
            }

            db.profils.Remove(p);
            db.SaveChanges();
            Effacer();
        }


        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgProfil.CurrentRow.Cells[0].Value.ToString());
            var p = db.profils.Find(id);
            txtCode.Text = p.code;
            txtLibelle.Text = p.libelle;
            txtDescription.Text = p.Description;
            cbbStatus.Text = p.Status;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgProfil.CurrentRow.Cells[0].Value.ToString());
            var p = db.profils.Find(id);

            if (p != null)
            {
                p.code = txtCode.Text;
                p.libelle = txtLibelle.Text;
                p.Description = txtDescription.Text;
                p.Status = cbbStatus.Text;
                db.SaveChanges();
                Effacer();
            }
            else
            {
                MessageBox.Show("Profil introuvable.");
            }
        }
    }
}
