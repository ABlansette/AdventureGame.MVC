﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models.Adventurer
{
    public class AdventurerListItem
    {
        public int AdventurerId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public Species Class { get; set; }
    }
    
}
