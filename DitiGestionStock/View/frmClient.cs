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
using Mysqlx.Session;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace DitiGestionStock.View
{
    public partial class frmClient : Form
    {
        BdDitiGestionStockContext db = new BdDitiGestionStockContext();
        public frmClient()
        {
            InitializeComponent();
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            dgClient.DataSource = db.clients.ToList();
            Effacer();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            
             Client p=new Client();
            p.NomPrenom = txtNomPrenom.Text;
            p.Quartier = txtQuartier.Text;
            p.Email = txtEmail.Text;
            p.DateNaissance = txtDateNaissance.Value;
            p.Sexe = cbbSexe.Text;
            p.Telephone = txtTel.Text;
            db.clients.Add(p);
            db.SaveChanges();
            Effacer();
        }

        private void Effacer()
        {
            txtTel.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtQuartier.Text = string.Empty;
            txtDateNaissance.Text = string.Empty;
            txtNomPrenom.Text = string.Empty;
            cbbSexe.Text = string.Empty;
            dgClient.DataSource = db.clients.ToList();
            txtNomPrenom.Focus();
        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            Effacer();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgClient.CurrentRow.Cells[0].Value.ToString());
            var p = db.clients.Find(id);
            db.clients.Remove(p);
            db.SaveChanges();
            Effacer();
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgClient.CurrentRow.Cells[0].Value.ToString());
            var p = db.clients.Find(id);
            txtNomPrenom.Text = p.NomPrenom;
            txtEmail.Text= p.Email;
            txtTel.Text = p.Telephone;
            txtQuartier.Text = p.Quartier;
            txtDateNaissance.Text = p.DateNaissance.ToString();
            cbbSexe.Text= p.Sexe;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgClient.CurrentRow.Cells[0].Value.ToString());
            var p = db.clients.Find(id);
            p.NomPrenom = txtNomPrenom.Text;
            p.Email = txtEmail.Text;
            p.Telephone = txtTel.Text;
            p.DateNaissance = txtDateNaissance.Value;
            p.Quartier = txtQuartier.Text;
            p.Sexe = cbbSexe.Text;
            db.SaveChanges();
            Effacer();
        }

        
    }
}
