namespace OtraCosaStudio.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_film : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Film",
                c => new
                    {
                        FilmId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FlagActive = c.Boolean(nullable: false),
                        FlagDelete = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyBy = c.String(maxLength: 50, unicode: false),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.FilmId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Film");
        }
    }
}
