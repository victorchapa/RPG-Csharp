using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCExample.Models
{
    [Table("Monsters")]
    public class Monster
    {
        public int MonsterId { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        public int Move { get; set; }
        public int Health { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }
        public int WeaponId { get; set; }

        [ForeignKey("WeaponId")]
        public Weapon Weapon { get; set; }
    }
}
