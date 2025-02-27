using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using DitiGestionStock.Model;
using Mysqlx.Session;
using static System.Net.Mime.MediaTypeNames;

namespace DitiGestionStock.View
{
    public partial class frmStock : Form
    {
        BdDitiGestionStockContext db = new BdDitiGestionStockContext();
        public frmStock(frmVente venteForm)
        {
            InitializeComponent();
            venteForm.StockUpdated += ResetForm;
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        public List<ItemListExample> LoadComboBoxProduit()
        {
            var list = db.produits.ToList();
            var ListItem = new List<ItemListExample>();
            var i = new ItemListExample();
            i.Value = 0;
            i.Text = "Selectionnez...";
            ListItem.Add(i);
            foreach (var item in list)
            {
                var j = new ItemListExample();
                j.Value = item.IdProduit;
                j.Text = item.LibelleProduit;
                ListItem.Add(j);
            }
            return ListItem;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock();
            stock.IdProduit = int.Parse(cbbProduit.SelectedValue.ToString());
            stock.QuantiteStock = int.Parse(txtQuantite.Text);
            stock.PU = float.Parse(txtPU.Text);
            stock.DatePeremption = txtDatePeremption.Value;
            db.stocks.Add(stock);
            db.SaveChanges();
            ResetForm();
        }

        public void ResetForm()
        {
            cbbProduit.SelectedValue = 0;
            txtDatePeremption.Value = DateTime.Now;
            txtPU.Text = string.Empty;
            txtQuantite.Text = string.Empty;
            cbbProduit.DataSource = LoadComboBoxProduit().ToList();
            cbbProduit.ValueMember = "Value";
            cbbProduit.DisplayMember = "Text";
            dgStock.DataSource = db.stocks.Include("Produit").Select(s => new
            {
                s.IdStock,
                Produit = s.Produit.LibelleProduit,
                s.QuantiteStock,
                s.PU,
                s.DatePeremption
            }).ToList();
            cbbProduit.Focus();
        }


        private void cbbProduit_Leave(object sender, EventArgs e)
        {
            var id = int.Parse(cbbProduit.SelectedValue.ToString());
            var p = db.produits.Find(id);
            txtPU.Text = p != null ? p.PuProduit.ToString() : "";
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgStock.CurrentRow != null)
            {
                int id = int.Parse(dgStock.CurrentRow.Cells[0].Value.ToString());
                var stock = db.stocks.Find(id);
                if (stock != null)
                {
                    db.stocks.Remove(stock);
                    db.SaveChanges();
                    ResetForm();
                }
            }
        }

        //private void btnModifier_Click(object sender, EventArgs e)
        //{
        //    if (dgStock.CurrentRow != null)
        //    {
        //        int id = int.Parse(dgStock.CurrentRow.Cells[0].Value.ToString());
        //        var stock = db.stocks.Find(id);
        //        if (stock != null)
        //        {
        //            stock.IdProduit = int.Parse(cbbProduit.SelectedValue.ToString());

        //            if (int.TryParse(txtQuantite.Text, out int quantite))
        //            {
        //                stock.QuantiteStock = quantite;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Quantité invalide.");
        //                return;
        //            }

        //            stock.PU = float.Parse(txtPU.Text);
        //            stock.DatePeremption = txtDatePeremption.Value;
        //            db.SaveChanges();
        //            ResetForm();
        //        }
        //    }
        //}



    }
    class ComboBoxIten
    {

        public string Text { get; set; }

        public int Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
