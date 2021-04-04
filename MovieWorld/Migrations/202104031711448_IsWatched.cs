namespace MovieWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsWatched : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "IsWatched", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "IsWatched");
        }
    }
}
