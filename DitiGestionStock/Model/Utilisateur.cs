using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DitiGestionStock.Model
{
    public class Utilisateur
    {
        [Key]
        public int IdUtilisateur { get; set; }

        [MaxLength(20)]
        public string Identifiant { get; set; }

        [MaxLength(160)]
        public string NomPrenom { get; set; }

        [MaxLength(512)]
        public string MotDePasse { get; set; }

        [MaxLength(80), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, MaxLength(20)]
        public string Telephone { get; set; }

        [MaxLength(10)]
        public string Status { get; set; }

        [MaxLength(10)]
        public string isResetPassword { get; set; }

        public int? IdProfil { get; set; }

        [ForeignKey("IdProfil")]
        public virtual Profil Profil { get; set; }

    }
}
