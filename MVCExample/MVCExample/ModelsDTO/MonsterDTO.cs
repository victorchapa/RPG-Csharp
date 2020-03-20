using MVCExample.Models;

namespace MVCExample.ModelsDTO
{
    public class MonsterDTO
    {
        public int MonsterId { get; set; }
        public string Name { get; set; }
        public int Move { get; set; }
        public int Health { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }
        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }
    }
}