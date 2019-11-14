namespace DSCodeFirst.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hop1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "Echange_IdEchange", "dbo.Echanges");
            DropForeignKey("dbo.Jeus", "Echange_IdEchange", "dbo.Echanges");
            DropForeignKey("dbo.Clients", "Reservation_IdReservation", "dbo.Reservations");
            DropForeignKey("dbo.Jeus", "Reservation_IdReservation", "dbo.Reservations");
            DropIndex("dbo.Clients", new[] { "Echange_IdEchange" });
            DropIndex("dbo.Clients", new[] { "Reservation_IdReservation" });
            DropIndex("dbo.Jeus", new[] { "Echange_IdEchange" });
            DropIndex("dbo.Jeus", new[] { "Reservation_IdReservation" });
            AddColumn("dbo.Reservations", "Jeu_IdJeu", c => c.Int());
            AddColumn("dbo.Reservations", "Client_IdClient", c => c.Int());
            CreateIndex("dbo.Reservations", "Jeu_IdJeu");
            CreateIndex("dbo.Reservations", "Client_IdClient");
            AddForeignKey("dbo.Reservations", "Jeu_IdJeu", "dbo.Jeus", "IdJeu");
            AddForeignKey("dbo.Reservations", "Client_IdClient", "dbo.Clients", "IdClient");
            DropColumn("dbo.Clients", "Echange_IdEchange");
            DropColumn("dbo.Clients", "Reservation_IdReservation");
            DropColumn("dbo.Jeus", "Echange_IdEchange");
            DropColumn("dbo.Jeus", "Reservation_IdReservation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jeus", "Reservation_IdReservation", c => c.Int());
            AddColumn("dbo.Jeus", "Echange_IdEchange", c => c.Int());
            AddColumn("dbo.Clients", "Reservation_IdReservation", c => c.Int());
            AddColumn("dbo.Clients", "Echange_IdEchange", c => c.Int());
            DropForeignKey("dbo.Reservations", "Client_IdClient", "dbo.Clients");
            DropForeignKey("dbo.Reservations", "Jeu_IdJeu", "dbo.Jeus");
            DropIndex("dbo.Reservations", new[] { "Client_IdClient" });
            DropIndex("dbo.Reservations", new[] { "Jeu_IdJeu" });
            DropColumn("dbo.Reservations", "Client_IdClient");
            DropColumn("dbo.Reservations", "Jeu_IdJeu");
            CreateIndex("dbo.Jeus", "Reservation_IdReservation");
            CreateIndex("dbo.Jeus", "Echange_IdEchange");
            CreateIndex("dbo.Clients", "Reservation_IdReservation");
            CreateIndex("dbo.Clients", "Echange_IdEchange");
            AddForeignKey("dbo.Jeus", "Reservation_IdReservation", "dbo.Reservations", "IdReservation");
            AddForeignKey("dbo.Clients", "Reservation_IdReservation", "dbo.Reservations", "IdReservation");
            AddForeignKey("dbo.Jeus", "Echange_IdEchange", "dbo.Echanges", "IdEchange");
            AddForeignKey("dbo.Clients", "Echange_IdEchange", "dbo.Echanges", "IdEchange");
        }
    }
}
