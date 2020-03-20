using System.ComponentModel.DataAnnotations.Schema;

namespace MVCExample.Models
{
    [Table("Characters")]
    public class Character
    {
        public int CharacterId { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Vocation { get; set; }
        public string Faction { get; set; }
        public string Gender { get; set; }
        public int WeaponId { get; set; }

        [ForeignKey("WeaponId")]
        public Weapon Weapon { get; set; }




    }
}
