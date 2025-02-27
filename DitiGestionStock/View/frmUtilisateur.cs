using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DitiGestionStock.Helper;
using DitiGestionStock.Model;
using Mysqlx.Session;

namespace DitiGestionStock.View
{
    public partial class frmUtilisateur : Form
    {
        public frmUtilisateur()
        {
            InitializeComponent();
        }

        BdDitiGestionStockContext db = new BdDitiGestionStockContext();

        private void frmUtilisateur_Load(object sender, EventArgs e)
        {
            ResetForm();
        }
                
        private void btnAjouter_Click_1(object sender, EventArgs e)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                Utilisateur ut = new Utilisateur();
                ut.Identifiant = txtIdentifiant.Text;
                ut.MotDePasse = Utils.GetMd5Hash(md5Hash, "P@sser123");
                ut.Email = txtEmail.Text;
                ut.Telephone = txtTel.Text;
                ut.NomPrenom = txtNomPrenom.Text;
                ut.isResetPassword = "true"; // Fixed here
                db.utilisateurs.Add(ut);
                db.SaveChanges();
                ResetForm();
            }
        }

        //private void cbbProfil_Leave(object sender, EventArgs e)
        //{
        //    var id = int.Parse(cbbProfil.SelectedValue.ToString());
        //    var p = db.profils.Find(id);
        //    txtEmail.Text = p != null ? p.PuProduit.ToString() : "";
        //}

        private void ResetForm()
        {
            txtEmail.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtNomPrenom.Text = string.Empty;
            txtIdentifiant.Text = string.Empty;
            cbbProfil.DataSource = LoadComboBoxProfil().ToList();
            cbbProfil.ValueMember = "Value";
            cbbProfil.DisplayMember = "Text";
            dgUtilisateur.DataSource = db.utilisateurs.Select(a => new { a.IdUtilisateur, a.Identifiant, a.NomPrenom, a.Email, a.Telephone }).ToList();
            txtNomPrenom.Focus();
        }

        private void btnBloquer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgUtilisateur.CurrentRow.Cells[0].Value.ToString());
            var ut = db.utilisateurs.Find(id);
            if (ut != null)
            {
                ut.Status = "Bloquer";
                db.SaveChanges();
            }
        }

        private void btnDebloquer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgUtilisateur.CurrentRow.Cells[0].Value.ToString());
            var ut = db.utilisateurs.Find(id);
            if (ut != null)
            {
                ut.Status = "Debloquer";
                db.SaveChanges();
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgUtilisateur.CurrentRow.Cells[0].Value.ToString());
            var ut = db.utilisateurs.Find(id);
            if (ut != null)
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    ut.isResetPassword = "true"; // Fixed here
                    ut.MotDePasse = Utils.GetMd5Hash(md5Hash, "P@sser123");
                    db.SaveChanges();
                }
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgUtilisateur.CurrentRow.Cells[0].Value.ToString());
            var ut = db.utilisateurs.Find(id);
            if (ut != null)
            {
                txtEmail.Text = ut.Email;
                txtIdentifiant.Text = ut.Identifiant;
                txtNomPrenom.Text = ut.NomPrenom;
                txtTel.Text = ut.Telephone;
            }
        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            Effacer();
        }

        private void Effacer()
        {
            txtEmail.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtNomPrenom.Text = string.Empty;
            txtIdentifiant.Text = string.Empty;
            if (cbbProfil.Items.Count > 0)
            {
                cbbProfil.SelectedIndex = 0;
            }
        }



        public List<ItemListExample> LoadComboBoxProfil()
        {
            var list = db.profils.ToList();

            var ListItem = new List<ItemListExample>();
            var i = new ItemListExample();
            i.Text = "Selectionnez...";
            i.Value = 0;
            ListItem.Add(i);
            foreach (var item in list)
            {
                var j = new ItemListExample();
                j.Value = item.IdProfil;
                j.Text = item.libelle;
                ListItem.Add(j);

            }
            return ListItem;
        }

        
    }
}
