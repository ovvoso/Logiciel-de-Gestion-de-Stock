using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DitiGestionStock.Model
{
    public class Produit
    {
        //update-Database -verbose : Pour faire la mise à jour de la base de donnée
        [Key]
        public int IdProduit { get; set; }
        [Required, MaxLength(10) ]
        public string CodeProduit { get; set; }
        [Required, MaxLength(80)]
        public string LibelleProduit { get; set; }
        [Required, MaxLength(500)]
        public string DescriptionProduit { get; set; }
        [Required, MaxLength(3)]
        public string Perissable { get; set; }
        [Required]
        public float QuantiteMinimale { get; set; }
        [Required]
        public float QuantiteSeuil { get; set; }
        [Required]
        public float PuProduit { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }

    }
}
