namespace DemoFaceRecognition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSlotTimeDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Slots", "StartTime", c => c.String());
            AlterColumn("dbo.Slots", "EndTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Slots", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Slots", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
