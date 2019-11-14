namespace DSCodeFirst.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IdClient = c.Int(nullable: false, identity: true),
                        Nom = c.String(maxLength: 50),
                        Prenom = c.String(maxLength: 50),
                        Email = c.String(nullable: false),
                        Echange_IdEchange = c.Int(),
                        Reservation_IdReservation = c.Int(),
                    })
                .PrimaryKey(t => t.IdClient)
                .ForeignKey("dbo.Echanges", t => t.Echange_IdEchange)
                .ForeignKey("dbo.Reservations", t => t.Reservation_IdReservation)
                .Index(t => t.Echange_IdEchange)
                .Index(t => t.Reservation_IdReservation);
            
            CreateTable(
                "dbo.Jeus",
                c => new
                    {
                        IdJeu = c.Int(nullable: false, identity: true),
                        Nom = c.String(maxLength: 50),
                        Plateforme = c.String(maxLength: 50),
                        Stock = c.Boolean(nullable: false),
                        Echange_IdEchange = c.Int(),
                        Reservation_IdReservation = c.Int(),
                    })
                .PrimaryKey(t => t.IdJeu)
                .ForeignKey("dbo.Echanges", t => t.Echange_IdEchange)
                .ForeignKey("dbo.Reservations", t => t.Reservation_IdReservation)
                .Index(t => t.Echange_IdEchange)
                .Index(t => t.Reservation_IdReservation);
            
            CreateTable(
                "dbo.Echanges",
                c => new
                    {
                        IdEchange = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.IdEchange);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        IdReservation = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.IdReservation);
            
            CreateTable(
                "dbo.JeuClients",
                c => new
                    {
                        Jeu_IdJeu = c.Int(nullable: false),
                        Client_IdClient = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Jeu_IdJeu, t.Client_IdClient })
                .ForeignKey("dbo.Jeus", t => t.Jeu_IdJeu, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_IdClient, cascadeDelete: true)
                .Index(t => t.Jeu_IdJeu)
                .Index(t => t.Client_IdClient);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jeus", "Reservation_IdReservation", "dbo.Reservations");
            DropForeignKey("dbo.Clients", "Reservation_IdReservation", "dbo.Reservations");
            DropForeignKey("dbo.Jeus", "Echange_IdEchange", "dbo.Echanges");
            DropForeignKey("dbo.Clients", "Echange_IdEchange", "dbo.Echanges");
            DropForeignKey("dbo.JeuClients", "Client_IdClient", "dbo.Clients");
            DropForeignKey("dbo.JeuClients", "Jeu_IdJeu", "dbo.Jeus");
            DropIndex("dbo.JeuClients", new[] { "Client_IdClient" });
            DropIndex("dbo.JeuClients", new[] { "Jeu_IdJeu" });
            DropIndex("dbo.Jeus", new[] { "Reservation_IdReservation" });
            DropIndex("dbo.Jeus", new[] { "Echange_IdEchange" });
            DropIndex("dbo.Clients", new[] { "Reservation_IdReservation" });
            DropIndex("dbo.Clients", new[] { "Echange_IdEchange" });
            DropTable("dbo.JeuClients");
            DropTable("dbo.Reservations");
            DropTable("dbo.Echanges");
            DropTable("dbo.Jeus");
            DropTable("dbo.Clients");
        }
    }
}
