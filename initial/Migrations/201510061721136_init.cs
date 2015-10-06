namespace initial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.something",
                c => new
                    {
                        somethingid = c.Int(nullable: false, identity: true),
                        someName = c.String(),
                        someIDNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.somethingid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.something");
        }
    }
}
