using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Data
{
    public class BadGuy
    {
        [Key]
        public int BadGuyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public int Health
        {
            get
            {
                return Level * 200;
            }
        }

        [Required]
        public int Damage
        {
            get
            {
                return Level * 19;
            }
        }

        [Required]
        public int XpDropped { get; set; }

        [Required]
        [ForeignKey(nameof(PlanetId))]
        public int PlanetId { get; set; }

        public virtual Planet Planet { get; set; }
    }
}
