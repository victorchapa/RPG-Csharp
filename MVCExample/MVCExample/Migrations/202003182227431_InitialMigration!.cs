namespace MVCExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        Name = c.String(),
                        Vocation = c.String(),
                        Faction = c.String(),
                        Gender = c.String(),
                        WeaponId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("dbo.Weapons", t => t.WeaponId, cascadeDelete: true)
                .Index(t => t.WeaponId);
            
            CreateTable(
                "dbo.Weapons",
                c => new
                    {
                        WeaponId = c.Int(nullable: false, identity: true),
                        Attack = c.Int(nullable: false),
                        Defense = c.Int(nullable: false),
                        Handler = c.Int(nullable: false),
                        Name = c.String(),
                        Kind = c.String(),
                    })
                .PrimaryKey(t => t.WeaponId);
            
            CreateTable(
                "dbo.Monsters",
                c => new
                    {
                        MonsterId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Move = c.Int(nullable: false),
                        Health = c.Int(nullable: false),
                        Defense = c.Int(nullable: false),
                        Attack = c.Int(nullable: false),
                        WeaponId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MonsterId)
                .ForeignKey("dbo.Weapons", t => t.WeaponId, cascadeDelete: true)
                .Index(t => t.WeaponId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Monsters", "WeaponId", "dbo.Weapons");
            DropForeignKey("dbo.Characters", "WeaponId", "dbo.Weapons");
            DropIndex("dbo.Monsters", new[] { "WeaponId" });
            DropIndex("dbo.Characters", new[] { "WeaponId" });
            DropTable("dbo.Monsters");
            DropTable("dbo.Weapons");
            DropTable("dbo.Characters");
        }
    }
}
