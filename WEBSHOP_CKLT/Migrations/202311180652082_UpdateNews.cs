namespace WEBSHOP_CKLT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNews : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_News", "Title", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_News", "Title", c => c.String(nullable: false));
        }
    }
}
