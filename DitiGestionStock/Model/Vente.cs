using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DitiGestionStock.Model
{
    public class Vente
    {
        [Key]
        public int IdVente { get; set; }
        public int IdProduit { get; set; }
        public int IdClient { get; set; }
        public DateTime DateVente { get; set; }
        public int Quantite { get; set; }
        public float PrixTotal { get; set; }

        [ForeignKey("IdProduit")]
        public virtual Produit Produit { get; set; }

        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }
    }
}
