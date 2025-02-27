using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DitiGestionStock.Model
{
    public class ClassReportListeProduit
    {
       
        public string CodeProduit { get; set; }
        
        public string LibelleProduit { get; set; }
        
        public string Perissable { get; set; }
        
        public float QuantiteMinimale { get; set; }
        
        public float QuantiteSeuil { get; set; }

        public float PuProduit { get; set; }

    }
}
