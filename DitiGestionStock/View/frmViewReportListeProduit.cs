using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DitiGestionStock.Properties;
using DitiGestionStock.Report;
//using static MySqlX.Notice.Warning.Types;
using DitiGestionStock.Model;

namespace DitiGestionStock.View
{
    public partial class frmViewReportListeProduit : Form
    {
        public frmViewReportListeProduit()
        {
            InitializeComponent();
        }

        BdDitiGestionStockContext db = new BdDitiGestionStockContext();

        private void frmViewReportListeProduit_Load(object sender, EventArgs e)
        {
            rptListeProduit objRpt = new rptListeProduit();
            objRpt.SetDataSource(GetTableProduit);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        public DataTable GetTableProduit()
        {
            DataTable table = new DataTable();
            table.Columns.Add("CodeProduit", typeof(string));
            table.Columns.Add("LibelleProduit", typeof(string));
            table.Columns.Add("Perissable", typeof(string));
            table.Columns.Add("QuantiteMinimale", typeof(float));
            table.Columns.Add("QuantiteSeuil", typeof(float));
            table.Columns.Add("PuProduit", typeof(float));

            var liste = db.produits.ToList();
            foreach (var i in liste)
            {
                table.Rows.Add(i.CodeProduit, i.LibelleProduit, i.Perissable, i.QuantiteMinimale,
                    i.QuantiteSeuil, i.PuProduit);
            }
            return table;
        }
    }
}
