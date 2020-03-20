namespace MVCExample.Migrations
{
    using MVCExample.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MappleFakeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MappleFakeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //IList<Weapon> defaultWeapons = new List<Weapon>();
            //defaultWeapons.Add(new Weapon() { Name = "Stonecutter axe", Attack = 66, Defense = 20, Handler = 2, Kind = "Axe" });
            //defaultWeapons.Add(new Weapon() { Name = "Grostmurne", Attack = 77, Defense = 30, Handler = 2, Kind = "Sword" });
            //defaultWeapons.Add(new Weapon() { Name = "Magic longsword", Attack = 70, Defense = 25, Handler = 2, Kind = "Sword" });

            //IList<Monster> defaultMonsters = new List<Monster>();
            //defaultMonsters.Add(new Monster() { Name = "Gorgona", Health = 1000, Attack = 700, Defense = 300, Move = 7, WeaponId = 1 });
            //defaultMonsters.Add(new Monster() { Name = "Minotaur", Health = 3000, Attack = 200, Defense = 600, Move = 3, WeaponId = 2 });
            //defaultMonsters.Add(new Monster() { Name = "Dragon", Health = 7000, Attack = 1200, Defense = 700, Move = 5, WeaponId = 3 });

            //IList<Character> defaultCharacters = new List<Character>();
            //defaultCharacters.Add(new Character() { Name = "Arthas", Age = 36, Faction = "Lordaeron", Gender = "Male", Vocation = "Paladin", WeaponId = 2 });
            //defaultCharacters.Add(new Character() { Name = "Daniel", Age = 24, Faction = "Abdendriel", Gender = "Male", Vocation = "Sorcerer", WeaponId = 1 });

            //context.Weapons.AddRange(defaultWeapons);
            //context.Monsters.AddRange(defaultMonsters);
            //context.Characters.AddRange(defaultCharacters);

            base.Seed(context);
        }
    }
}
