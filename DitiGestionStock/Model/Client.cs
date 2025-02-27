using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DitiGestionStock.Model
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }

        [Required, MaxLength(160)]
        public string NomPrenom { get; set; }

        [Required, MaxLength(160)]
        public string Quartier { get; set; }

        [Required, MaxLength(20)]
        public string Telephone { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, MaxLength(6)]
        public string Sexe { get; set; }
        public DateTime? DateNaissance { get; set; }
    }
}
