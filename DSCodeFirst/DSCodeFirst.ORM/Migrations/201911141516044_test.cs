namespace DSCodeFirst.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "Jeu_IdJeu", "dbo.Jeus");
            DropForeignKey("dbo.Reservations", "Client_IdClient", "dbo.Clients");
            DropIndex("dbo.Reservations", new[] { "Jeu_IdJeu" });
            DropIndex("dbo.Reservations", new[] { "Client_IdClient" });
            AddColumn("dbo.Clients", "Echange_IdEchange", c => c.Int());
            AddColumn("dbo.Clients", "Reservation_IdReservation", c => c.Int());
            AddColumn("dbo.Jeus", "Echange_IdEchange", c => c.Int());
            AddColumn("dbo.Jeus", "Reservation_IdReservation", c => c.Int());
            CreateIndex("dbo.Clients", "Echange_IdEchange");
            CreateIndex("dbo.Clients", "Reservation_IdReservation");
            CreateIndex("dbo.Jeus", "Echange_IdEchange");
            CreateIndex("dbo.Jeus", "Reservation_IdReservation");
            AddForeignKey("dbo.Clients", "Echange_IdEchange", "dbo.Echanges", "IdEchange");
            AddForeignKey("dbo.Jeus", "Echange_IdEchange", "dbo.Echanges", "IdEchange");
            AddForeignKey("dbo.Clients", "Reservation_IdReservation", "dbo.Reservations", "IdReservation");
            AddForeignKey("dbo.Jeus", "Reservation_IdReservation", "dbo.Reservations", "IdReservation");
            DropColumn("dbo.Reservations", "Jeu_IdJeu");
            DropColumn("dbo.Reservations", "Client_IdClient");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "Client_IdClient", c => c.Int());
            AddColumn("dbo.Reservations", "Jeu_IdJeu", c => c.Int());
            DropForeignKey("dbo.Jeus", "Reservation_IdReservation", "dbo.Reservations");
            DropForeignKey("dbo.Clients", "Reservation_IdReservation", "dbo.Reservations");
            DropForeignKey("dbo.Jeus", "Echange_IdEchange", "dbo.Echanges");
            DropForeignKey("dbo.Clients", "Echange_IdEchange", "dbo.Echanges");
            DropIndex("dbo.Jeus", new[] { "Reservation_IdReservation" });
            DropIndex("dbo.Jeus", new[] { "Echange_IdEchange" });
            DropIndex("dbo.Clients", new[] { "Reservation_IdReservation" });
            DropIndex("dbo.Clients", new[] { "Echange_IdEchange" });
            DropColumn("dbo.Jeus", "Reservation_IdReservation");
            DropColumn("dbo.Jeus", "Echange_IdEchange");
            DropColumn("dbo.Clients", "Reservation_IdReservation");
            DropColumn("dbo.Clients", "Echange_IdEchange");
            CreateIndex("dbo.Reservations", "Client_IdClient");
            CreateIndex("dbo.Reservations", "Jeu_IdJeu");
            AddForeignKey("dbo.Reservations", "Client_IdClient", "dbo.Clients", "IdClient");
            AddForeignKey("dbo.Reservations", "Jeu_IdJeu", "dbo.Jeus", "IdJeu");
        }
    }
}
