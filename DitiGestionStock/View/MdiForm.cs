using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace DitiGestionStock.View
{
    public partial class MdiForm : Form
    {
        public MdiForm()
        {
            InitializeComponent();
        }

        public string NomPrenom, Profil;
        /// <summary>
        /// C'est la fonction qui permet de fermer toute les menus
        /// </summary>
        private void fermer()
        {
            Form[] charr = this.MdiChildren;
            //For each child form set the window state to Maximized
            foreach (Form chform in charr)
            {
                //chform.WindowState = FormWindowState.Maximized
                chform.Close();
            }
        }

        private void MdiForm_Load(object sender, EventArgs e)
        {
            Computer myComputer = new Computer();
            this.Width = myComputer.Screen.Bounds.Width;
            this.Height = myComputer.Screen.Bounds.Height;
            this.Location = new Point(0, 0);
            lblNomPrenom.Text = NomPrenom;
            if(Profil == "Admin")
            {
                parametrageToolStripMenuItem.Visible = false;
                venteToolStripMenuItem.Visible = false;
            }
        }

        private void quitterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void seDeconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void produitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmProduit f = new frmProduit();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmClient f = new frmClient();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void venteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmVente f = new frmVente();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }
        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if frmStock is already open
            foreach (Form form in this.MdiChildren)
            {
                if (form is frmStock)
                {
                    form.Activate();
                    return;
                }
            }
            // If not open, create a new instance and show it
            frmVente venteForm = new frmVente(); // Create an instance of frmVente
            frmStock f = new frmStock(venteForm); // Pass the instance to frmStock constructor
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        

        private void utilisateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmUtilisateur f = new frmUtilisateur();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void profilToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            fermer();
            frmProfil f = new frmProfil();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }
    }
}
