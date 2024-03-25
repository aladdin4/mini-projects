using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipLibrary.Models {
    public class GridSpotModel {
        public string SpotLetter { get; set; }
        public int SpotNumber { get; set; }
        public Status SpotStatus { get; set; }
    }
}
