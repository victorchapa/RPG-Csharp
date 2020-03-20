using System.ComponentModel.DataAnnotations.Schema;

namespace MVCExample.Models
{
    [Table("Weapons")]
    public class Weapon
    {
        public int WeaponId { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Handler { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }

    }
}
