namespace MovieWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavCounts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "FavoritesCount", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "FavoritesCount");
        }
    }
}
