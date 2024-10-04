namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentConstructorCenterDatas",
                c => new
                    {
                        DocumentConstructorCenterDataId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Npp = c.Int(nullable: false),
                        Size = c.String(),
                        Data_DocumentConstructorLeftDataId = c.Int(),
                    })
                .PrimaryKey(t => t.DocumentConstructorCenterDataId)
                .ForeignKey("dbo.DocumentConstructorLeftDatas", t => t.Data_DocumentConstructorLeftDataId)
                .Index(t => t.Data_DocumentConstructorLeftDataId);
            
            CreateTable(
                "dbo.DocumentConstructorLeftDatas",
                c => new
                    {
                        DocumentConstructorLeftDataId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Npp = c.Int(nullable: false),
                        SizeTitle = c.String(),
                    })
                .PrimaryKey(t => t.DocumentConstructorLeftDataId);
            
            CreateTable(
                "dbo.DocumentConstructors",
                c => new
                    {
                        DocumentConstructorId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.DocumentConstructorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DocumentConstructorCenterDatas", "Data_DocumentConstructorLeftDataId", "dbo.DocumentConstructorLeftDatas");
            DropIndex("dbo.DocumentConstructorCenterDatas", new[] { "Data_DocumentConstructorLeftDataId" });
            DropTable("dbo.DocumentConstructors");
            DropTable("dbo.DocumentConstructorLeftDatas");
            DropTable("dbo.DocumentConstructorCenterDatas");
        }
    }
}
