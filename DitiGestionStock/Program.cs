using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DitiGestionStock.Helper;
using DitiGestionStock.Model;
using DitiGestionStock.View;
using System.Security.Cryptography;

namespace DitiGestionStock
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //using (var db = new BdDitiGestionStockContext())
            //{
            //    var superAdmin = db.utilisateurs.FirstOrDefault(u => u.Profil.code == "SUPER_ADMIN");
            //    if (superAdmin == null)
            //    {
            //        // Create a new super admin if it doesn't exist
            //        Utilisateur newSuperAdmin = new Utilisateur
            //        {
            //            Identifiant = "admin",
            //            NomPrenom = "Super Admin",
            //            MotDePasse = Utils.CreateMd5Hash("admin123"), // You can change the default password
            //            Email = "admin@example.com",
            //            Telephone = "0000000000",
            //            Status = "Active",
            //            isResetPassword = "No",
            //            Profil = db.profils.FirstOrDefault(p => p.code == "SUPER_ADMIN") ?? new Profil { code = "SUPER_ADMIN", libelle = "Super Administrator" }
            //        };
            //        db.utilisateurs.Add(newSuperAdmin);
            //        db.SaveChanges();
            //    }
            //}

            
        }
    }
}
    
