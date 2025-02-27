using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DitiGestionStock.Model
{
    public class Td_Erreur
    {
        [Key] 
        public int IdErreur { get; set; }

        public DateTime? DateErreur { get; set; }

        [MaxLength(2000)]
        public string DescriptionErreur { get; set; }

        [MaxLength(200)]
        public string TitreErreur { get; set; }

    }
}
