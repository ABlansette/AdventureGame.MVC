using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models.Adventurer
{
    public class AdventurerCreate
    {
        [Required]
        public string Name { get; set; }

        public Species Class { get; set; }
    }
}
