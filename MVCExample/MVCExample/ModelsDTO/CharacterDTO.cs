using MVCExample.Models;

namespace MVCExample.ModelsDTO
{
    public class CharacterDTO
    {
        public int CharacterId { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Vocation { get; set; }
        public string Faction { get; set; }
        public string Gender { get; set; }
        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }
    }
}