namespace PIAdvisingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PiAdvisingBondMains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApiNumber = c.String(),
                        BookingNo = c.String(),
                        InvoiceQty = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BookingDate = c.DateTime(nullable: false),
                        Specification = c.String(),
                        Size = c.String(),
                        BondName = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PiAdvisingBondMains");
        }
    }
}
