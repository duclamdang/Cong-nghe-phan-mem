namespace WEBSHOP_CKLT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorderdealtal111 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tb_OrderDetail");
            AddColumn("dbo.tb_OrderDetail", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tb_OrderDetail", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.tb_OrderDetail");
            DropColumn("dbo.tb_OrderDetail", "ID");
            AddPrimaryKey("dbo.tb_OrderDetail", new[] { "OrderID", "ProductID" });
        }
    }
}
