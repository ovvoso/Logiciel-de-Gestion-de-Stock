using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DitiGestionStock.Helper;
using DitiGestionStock.Model;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace DitiGestionStock.View
{
    public partial class frmProduit : Form
    {
        BdDitiGestionStockContext db = new BdDitiGestionStockContext();
        Logger logger = new Logger();
        public frmProduit()
        {
            InitializeComponent();
        }

        private void frmProduit_Load(object sender, EventArgs e)
        {
            dgProduit.DataSource = db.produits.ToList();
            Effacer();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                Produit p = new Produit();
                p.PuProduit = float.Parse(txtPU.Text);
                p.DescriptionProduit = txtDescription.Text;
                p.CodeProduit = txtCode.Text;
                p.LibelleProduit = txtLibelle.Text;
                p.QuantiteMinimale = float.Parse(txtQteMin.Text);
                p.QuantiteSeuil = float.Parse(txtQteSeuil.Text);
                p.Perissable = cbbPerissable.Text;
                db.produits.Add(p);
                db.SaveChanges();
                Effacer();
            }
            catch (Exception ex)
            {
                logger.WriteDataError("frmProduit:btnAjouter_Click", ex.ToString());
            }
                       
        }

        private void Effacer()
        {
            txtCode.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtLibelle.Text = string.Empty;
            txtPU.Text = string.Empty;
            txtQteMin.Text = string.Empty;
            txtQteSeuil.Text = string.Empty;
            cbbPerissable.Text = string.Empty;
            dgProduit.DataSource = db.produits.ToList();
            txtCode.Focus();
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgProduit.CurrentRow.Cells[0].Value.ToString());
            var p = db.produits.Find(id);
            txtCode.Text = p.CodeProduit;
            txtDescription.Text = p.DescriptionProduit;
            txtLibelle.Text = p.LibelleProduit;
            txtPU.Text = p.PuProduit.ToString();
            txtQteMin.Text = p.QuantiteMinimale.ToString();
            txtQteSeuil.Text = p.QuantiteSeuil.ToString();
            cbbPerissable.Text = p.Perissable;
        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            Effacer();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgProduit.CurrentRow.Cells[0].Value.ToString());
            var p = db.produits.Find(id);
            p.PuProduit = float.Parse(txtPU.Text);
            p.DescriptionProduit = txtDescription.Text;
            p.CodeProduit = txtCode.Text;
            p.LibelleProduit = txtLibelle.Text;
            p.QuantiteMinimale = float.Parse(txtQteMin.Text);
            p.QuantiteSeuil = float.Parse(txtQteSeuil.Text);
            p.Perissable = cbbPerissable.Text;
            db.SaveChanges();
            Effacer();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgProduit.CurrentRow.Cells[0].Value.ToString());
            var p = db.produits.Find(id);
            db.produits.Remove(p);
            db.SaveChanges();
            Effacer();
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            frmViewReportListeProduit f = new frmViewReportListeProduit();
            f.Show();
        }

        
    }
}
