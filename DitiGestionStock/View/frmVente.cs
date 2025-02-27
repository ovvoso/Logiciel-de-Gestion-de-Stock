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
    public partial class frmVente : Form
    {
        BdDitiGestionStockContext db = new BdDitiGestionStockContext();
        public event Action StockUpdated; // Declare the event here

        public frmVente()
        {
            InitializeComponent();
            LoadVentes(); // Load data when the form is initialized
        }

        private void txtCTel_MouseLeave(object sender, EventArgs e)
        {
            var c = db.clients.Where(a => a.Telephone == txtCTel.Text).FirstOrDefault();
            if (c != null)
            {
                txtCDateNaissance.Text = c.DateNaissance.ToString();
                txtCEmail.Text = c.Email;
                txtCNomPrenom.Text = c.NomPrenom;
                txtCQuartier.Text = c.Quartier;
            }
        }

        private void txtPCode_MouseLeave(object sender, EventArgs e)
        {
            var p = db.produits.Where(a => a.CodeProduit == txtPCode.Text).FirstOrDefault();
            if (p != null)
            {
                txtPLibelle.Text = p.LibelleProduit;
                txtPPU.Text = p.PuProduit.ToString();
                var stock = db.stocks.Where(s => s.IdProduit == p.IdProduit).FirstOrDefault();
                if (stock != null)
                {
                    txtPDatePeremption.Text = stock.DatePeremption?.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtPDatePeremption.Text = string.Empty; // Clear the DateTimePicker value
                }
                txtPDescription.Text = p.DescriptionProduit;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                var produit = db.produits.Where(p => p.CodeProduit == txtPCode.Text).FirstOrDefault();
                var client = db.clients.Where(c => c.Telephone == txtCTel.Text).FirstOrDefault();

                if (produit != null && client != null)
                {
                    if (int.TryParse(txtQuantite.Text, out int quantiteVendue) && float.TryParse(txtPPU.Text, out float puProduit))
                    {
                        var stock = db.stocks.FirstOrDefault(s => s.IdProduit == produit.IdProduit);
                        if (stock != null)
                        {
                            if (stock.QuantiteStock >= quantiteVendue)
                            {
                                var vente = new Vente
                                {
                                    IdProduit = produit.IdProduit,
                                    IdClient = client.IdClient,
                                    DateVente = DateTime.Now,
                                    Quantite = quantiteVendue,
                                    PrixTotal = puProduit * quantiteVendue
                                };

                                db.ventes.Add(vente);

                                // Mettre à jour le stock
                                stock.QuantiteStock -= quantiteVendue;

                                db.SaveChanges();

                                // Déclencher l'événement StockUpdated
                                StockUpdated?.Invoke();

                                // Mettre à jour dgVente
                                LoadVentes();

                                // Réinitialiser les champs de saisie
                                ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("Quantité en stock insuffisante.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Produit non trouvé dans le stock.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Quantité ou prix unitaire invalide.");
                    }
                }
                else
                {
                    MessageBox.Show("Produit ou client introuvable.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout de la vente : " + ex.Message);
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            // Calculate the total of all sales
            var totalVentes = db.ventes.Sum(v => v.PrixTotal);
            txtTotal.Text = totalVentes.ToString("F2"); // Display the total in the txtTotal field
        }

        private void LoadVentes()
        {
            var ventes = db.ventes.Include("Produit").Include("Client").Select(v => new
            {
                v.IdVente,
                Produit = v.Produit.LibelleProduit,
                Client = v.Client.NomPrenom,
                v.DateVente,
                v.Quantite,
                PrixUnitaire = v.Produit.PuProduit,
                v.PrixTotal
            }).ToList();
            dgVente.DataSource = ventes;

            // Update the total sales when loading ventes
            var totalVentes = ventes.Sum(v => v.PrixTotal);
            txtTotal.Text = totalVentes.ToString("F2");
        }


        private void ClearFields()
        {
            txtPCode.Text = string.Empty;
            txtPLibelle.Text = string.Empty;
            txtPPU.Text = string.Empty;
            txtPDatePeremption.Text = string.Empty;
            txtPDescription.Text = string.Empty;
            txtCTel.Text = string.Empty;
            txtCDateNaissance.Text = string.Empty;
            txtCEmail.Text = string.Empty;
            txtCNomPrenom.Text = string.Empty;
            txtCQuartier.Text = string.Empty;
            txtQuantite.Text = string.Empty;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgVente.CurrentRow != null)
            {
                int idVente = (int)dgVente.CurrentRow.Cells["IdVente"].Value;
                var vente = db.ventes.Find(idVente);

                if (vente != null)
                {
                    db.ventes.Remove(vente);
                    db.SaveChanges();

                    // Déclencher l'événement StockUpdated
                    StockUpdated?.Invoke();

                    // Mettre à jour dgVente
                    LoadVentes();

                    MessageBox.Show("Vente supprimée avec succès.");
                }
                else
                {
                    MessageBox.Show("Vente introuvable.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une vente à supprimer.");
            }
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {

        }

        

        
    }
}
