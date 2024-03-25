using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipLibrary.Models {
    public class PlayerModel {
        public string Name { get; set; }
        public List<GridRowModel> ShipsGrid { get; set; }
        public List<GridRowModel> AttacksGird { get; set; }
        public int Hits { get; set; }
        public int Misses { get; set; }
        public int Sunk { get; set; }
    }
}
