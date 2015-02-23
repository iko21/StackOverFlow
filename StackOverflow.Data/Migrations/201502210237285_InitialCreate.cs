namespace StackOverflow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Votes = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                        Owner_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Owner_Id", "dbo.Accounts");
            DropIndex("dbo.Questions", new[] { "Owner_Id" });
            DropTable("dbo.Questions");
            DropTable("dbo.Accounts");
        }
    }
}
