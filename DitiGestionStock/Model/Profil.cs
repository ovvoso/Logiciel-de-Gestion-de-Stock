using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DitiGestionStock.Model
{
    public class Profil
    {
        [Key]
        public int IdProfil { get; set; }

        [MaxLength(10)]
        public string code { get; set; }

        [MaxLength(100)]
        public string libelle { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
    }
}
