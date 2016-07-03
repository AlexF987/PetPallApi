namespace PetPallApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PetOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PetWalkers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        PetOwner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PetOwners", t => t.PetOwner_Id)
                .Index(t => t.PetOwner_Id);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        PetOwnerId = c.Int(nullable: false),
                        PetWalker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PetOwners", t => t.PetOwnerId, cascadeDelete: true)
                .ForeignKey("dbo.PetWalkers", t => t.PetWalker_Id)
                .Index(t => t.PetOwnerId)
                .Index(t => t.PetWalker_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PetWalkers", "PetOwner_Id", "dbo.PetOwners");
            DropForeignKey("dbo.Pets", "PetWalker_Id", "dbo.PetWalkers");
            DropForeignKey("dbo.Pets", "PetOwnerId", "dbo.PetOwners");
            DropIndex("dbo.Pets", new[] { "PetWalker_Id" });
            DropIndex("dbo.Pets", new[] { "PetOwnerId" });
            DropIndex("dbo.PetWalkers", new[] { "PetOwner_Id" });
            DropTable("dbo.Pets");
            DropTable("dbo.PetWalkers");
            DropTable("dbo.PetOwners");
        }
    }
}
