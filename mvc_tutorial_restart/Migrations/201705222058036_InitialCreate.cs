namespace mvc_tutorial_restart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        GenreId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 160),
                        Price = c.Decimal(nullable: false, precision: 10, scale: 2, storeType: "numeric"),
                        AlbumArtUrl = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Artist", t => t.ArtistId)
                .ForeignKey("dbo.Genre", t => t.GenreId)
                .Index(t => t.GenreId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 120),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(nullable: false, maxLength: 50, unicode: false),
                        AlbumId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Album", t => t.AlbumId)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 120),
                        Description = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 10, scale: 2, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.Album", t => t.AlbumId)
                .Index(t => t.OrderId)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Username = c.String(maxLength: 256),
                        FirstName = c.String(maxLength: 160),
                        LastName = c.String(maxLength: 160),
                        Address = c.String(maxLength: 70),
                        City = c.String(maxLength: 40),
                        State = c.String(maxLength: 40),
                        PostalCode = c.String(maxLength: 10),
                        Country = c.String(maxLength: 40),
                        Phone = c.String(maxLength: 24),
                        Email = c.String(maxLength: 160),
                        Total = c.Decimal(nullable: false, precision: 10, scale: 2, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        GenreID = c.Int(nullable: false),
                        ArtistID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AlbumArtUrl = c.String(),
                    })
                .PrimaryKey(t => t.AlbumID)
                .ForeignKey("dbo.Artists", t => t.ArtistID, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreID, cascadeDelete: true)
                .Index(t => t.GenreID)
                .Index(t => t.ArtistID);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.__MigrationHistory",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 150),
                        ContextKey = c.String(nullable: false, maxLength: 300),
                        Model = c.Binary(nullable: false),
                        ProductVersion = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "GenreID", "dbo.Genres");
            DropForeignKey("dbo.Albums", "ArtistID", "dbo.Artists");
            DropForeignKey("dbo.OrderDetail", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Album", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.Cart", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.Album", "ArtistId", "dbo.Artist");
            DropIndex("dbo.Albums", new[] { "ArtistID" });
            DropIndex("dbo.Albums", new[] { "GenreID" });
            DropIndex("dbo.OrderDetail", new[] { "AlbumId" });
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.Cart", new[] { "AlbumId" });
            DropIndex("dbo.Album", new[] { "ArtistId" });
            DropIndex("dbo.Album", new[] { "GenreId" });
            DropTable("dbo.__MigrationHistory");
            DropTable("dbo.Genres");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Genre");
            DropTable("dbo.Cart");
            DropTable("dbo.Artist");
            DropTable("dbo.Album");
        }
    }
}
