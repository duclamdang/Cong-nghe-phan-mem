namespace WEBSHOP_CKLT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDungChung : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Ads", "ModiferDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Category", "ModiferDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_News", "ModiferDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Post", "ModiferDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Contact", "ModiferDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Order", "ModiferDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Product", "ModiferDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_ProductCategory", "ModiferDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.tb_Ads", "ModifModiferDate");
            DropColumn("dbo.tb_Category", "ModifModiferDate");
            DropColumn("dbo.tb_News", "ModifModiferDate");
            DropColumn("dbo.tb_Post", "ModifModiferDate");
            DropColumn("dbo.tb_Contact", "ModifModiferDate");
            DropColumn("dbo.tb_Order", "ModifModiferDate");
            DropColumn("dbo.tb_Product", "ModifModiferDate");
            DropColumn("dbo.tb_ProductCategory", "ModifModiferDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_ProductCategory", "ModifModiferDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Product", "ModifModiferDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Order", "ModifModiferDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Contact", "ModifModiferDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Post", "ModifModiferDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_News", "ModifModiferDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Category", "ModifModiferDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Ads", "ModifModiferDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.tb_ProductCategory", "ModiferDate");
            DropColumn("dbo.tb_Product", "ModiferDate");
            DropColumn("dbo.tb_Order", "ModiferDate");
            DropColumn("dbo.tb_Contact", "ModiferDate");
            DropColumn("dbo.tb_Post", "ModiferDate");
            DropColumn("dbo.tb_News", "ModiferDate");
            DropColumn("dbo.tb_Category", "ModiferDate");
            DropColumn("dbo.tb_Ads", "ModiferDate");
        }
    }
}
