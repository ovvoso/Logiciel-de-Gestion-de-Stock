using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DitiGestionStock.Helper;
using DitiGestionStock.View;
using DitiGestionStock.Model;
using System.Security.Cryptography;

namespace DitiGestionStock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        BdDitiGestionStockContext db = new BdDitiGestionStockContext();

        private void btnSeConnecter_Click(object sender, EventArgs e)
        {
            var ut = db.utilisateurs.Where(a => a.Identifiant == txtIdentifiant.Text).FirstOrDefault();
            if (ut != null)
            {
                string hash = ut.MotDePasse;
                using (MD5 md5Hash = MD5.Create())
                {
                    if (Utils.VerifyMd5Hash(md5Hash, txtMotDePasse.Text, hash))
                    {
                        MdiForm f = new MdiForm();
                        f.NomPrenom = ut.NomPrenom;
                        f.Profil = ut.Profil.code;
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Votre identifiant ou mot de passe est incorrect.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Votre identifiant ou mot de passe est incorrect.");
            }
        }
        private void txtMotDePasse_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void btnQuiter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Logger.WriteLogSystem("Demarrage de l'application", string.Format("{0} ", DateTime.Now.ToString()));
        }
    }
}
