namespace SeminarDva.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Predbiljezbas",
                c => new
                    {
                        IdPredbiljezba = c.Int(nullable: false, identity: true),
                        DatumPredbiljezbe = c.DateTime(nullable: false),
                        Ime = c.String(nullable: false, maxLength: 20),
                        Prezime = c.String(nullable: false, maxLength: 20),
                        Adresa = c.String(nullable: false, maxLength: 70),
                        Email = c.String(nullable: false),
                        Telefon = c.String(nullable: false),
                        IdSeminar = c.Int(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdPredbiljezba)
                .ForeignKey("dbo.Seminars", t => t.IdSeminar)
                .Index(t => t.IdSeminar);
            
            CreateTable(
                "dbo.Seminars",
                c => new
                    {
                        IdSeminar = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 40),
                        Opis = c.String(nullable: false, maxLength: 50),
                        DatumPocetka = c.DateTime(nullable: false),
                        Popunjen = c.Boolean(nullable: false),
                        BrojMjesta = c.Int(),
                    })
                .PrimaryKey(t => t.IdSeminar);
            
            CreateTable(
                "dbo.Zaposleniks",
                c => new
                    {
                        IdZaposlenik = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        KorisnickoIme = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.IdZaposlenik);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Predbiljezbas", "IdSeminar", "dbo.Seminars");
            DropIndex("dbo.Predbiljezbas", new[] { "IdSeminar" });
            DropTable("dbo.Zaposleniks");
            DropTable("dbo.Seminars");
            DropTable("dbo.Predbiljezbas");
        }
    }
}
