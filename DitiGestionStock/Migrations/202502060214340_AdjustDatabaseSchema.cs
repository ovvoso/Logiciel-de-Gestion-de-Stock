namespace DitiGestionStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustDatabaseSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IdClient = c.Int(nullable: false, identity: true),
                        NomPrenom = c.String(nullable: false, maxLength: 160, storeType: "nvarchar"),
                        Quartier = c.String(nullable: false, maxLength: 160, storeType: "nvarchar"),
                        Telephone = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        Email = c.String(nullable: false, unicode: false),
                        Sexe = c.String(nullable: false, maxLength: 6, storeType: "nvarchar"),
                        DateNaissance = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.IdClient);
            
            CreateTable(
                "dbo.Produits",
                c => new
                    {
                        IdProduit = c.Int(nullable: false, identity: true),
                        CodeProduit = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        LibelleProduit = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        DescriptionProduit = c.String(nullable: false, maxLength: 500, storeType: "nvarchar"),
                        Perissable = c.String(nullable: false, maxLength: 3, storeType: "nvarchar"),
                        QuantiteMinimale = c.Single(nullable: false),
                        QuantiteSeuil = c.Single(nullable: false),
                        PuProduit = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.IdProduit);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        IdStock = c.Int(nullable: false, identity: true),
                        QuantiteStock = c.Single(nullable: false),
                        PU = c.Single(nullable: false),
                        DatePeremption = c.DateTime(nullable: false, precision: 0),
                        IdProduit = c.Int(),
                    })
                .PrimaryKey(t => t.IdStock)
                .ForeignKey("dbo.Produits", t => t.IdProduit)
                .Index(t => t.IdProduit);
            
            CreateTable(
                "dbo.Td_Erreur",
                c => new
                    {
                        IdErreur = c.Int(nullable: false, identity: true),
                        DateErreur = c.DateTime(precision: 0),
                        DescriptionErreur = c.String(maxLength: 2000, storeType: "nvarchar"),
                        TitreErreur = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdErreur);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        IdUtilisateur = c.Int(nullable: false, identity: true),
                        Identifiant = c.String(maxLength: 20, storeType: "nvarchar"),
                        NomPrenom = c.String(maxLength: 160, storeType: "nvarchar"),
                        MotDePasse = c.String(maxLength: 512, storeType: "nvarchar"),
                        Email = c.String(maxLength: 80, storeType: "nvarchar"),
                        Status = c.String(maxLength: 10, storeType: "nvarchar"),
                        isResetPassword = c.String(maxLength: 10, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdUtilisateur);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "IdProduit", "dbo.Produits");
            DropIndex("dbo.Stocks", new[] { "IdProduit" });
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Td_Erreur");
            DropTable("dbo.Stocks");
            DropTable("dbo.Produits");
            DropTable("dbo.Clients");
        }
    }
}
