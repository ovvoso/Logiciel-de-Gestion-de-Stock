using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DitiGestionStock.Model
{
    public class Stock
    {

        [Key]
        public int IdStock { get; set; }

        [Required]
        public float? QuantiteStock { get; set; }

        [Required]
        public float? PU { get; set; }

        [Required]
        public DateTime? DatePeremption { get; set; }

        [ForeignKey("Produit")]
        public int? IdProduit { get; set; }

        public virtual Produit Produit { get; set; }
       

    }
}
