using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.EntityFramework;

namespace DitiGestionStock.Model
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BdDitiGestionStockContext: DbContext
    {
        public BdDitiGestionStockContext():base("bdditigestionstockContext") 
        { }

        public DbSet<Produit> produits { get; set; }
        public DbSet<Client> clients { get; set; }

        public DbSet<Stock> stocks { get; set; }

        public DbSet<Td_Erreur> td_Erreurs { get; set; }

        public DbSet<Utilisateur> utilisateurs { get; set; }

        public DbSet<Profil> profils { get; set; }

        public DbSet<Vente> ventes { get; set; }

    }
}
