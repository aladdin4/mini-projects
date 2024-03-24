using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipLibrary.Models {
    public class GridSpot {
        public string SpotLetter { get; set; }
        public int SpotNumber { get; set; }
         
        public Status SpotStatus { get; set; }
        public enum Status {
            Empty,
            Ship,
            Miss,
            Hit,
            Sunk
        }
    }
}
