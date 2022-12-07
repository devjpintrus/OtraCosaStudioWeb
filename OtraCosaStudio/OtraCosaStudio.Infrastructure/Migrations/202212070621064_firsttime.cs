namespace OtraCosaStudio.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firsttime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentType",
                c => new
                    {
                        DocumentTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Digits = c.Int(nullable: false),
                        FlagActive = c.Boolean(nullable: false),
                        FlagDelete = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyBy = c.String(maxLength: 50, unicode: false),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.DocumentTypeId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100, unicode: false),
                        SecondaryName = c.String(nullable: false, maxLength: 100, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 100, unicode: false),
                        MiddleName = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        CellPhone = c.String(nullable: false, maxLength: 100, unicode: false),
                        DocumentTypeId = c.Int(nullable: false),
                        FlagActive = c.Boolean(nullable: false),
                        FlagDelete = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyBy = c.String(maxLength: 50, unicode: false),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId) 
                .Index(t => t.DocumentTypeId);
            AddForeignKey("dbo.User", "DocumentTypeId", "dbo.DocumentType", "DocumentTypeId");
        }
        private void AddForeignKey(string v)
        {
            throw new NotImplementedException();
        }

        public override void Down()
        {
            DropForeignKey("dbo.User", "DocumentTypeId", "dbo.DocumentType");
            DropIndex("dbo.User", new[] { "DocumentTypeId" });
            DropTable("dbo.User");
            DropTable("dbo.DocumentType");
        }
    }
}
