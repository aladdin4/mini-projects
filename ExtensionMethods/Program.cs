using System;

namespace ExtensionMethods {
    public class Program {
        static void Main(string[] args) {
            //this is called the "Fluent Design"
            Player me = new Player().CreatePlayer().ChangeName("Ahmed");
            me.PrintPlayer();
        }

    }

    public class Player {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
    }

    public static class Extentions {
        public static Player CreatePlayer(this Player player) {
            player.Name = "New Player";
            player.Class = "New Class";
            player.Description = "Default Stat";
            player.Description2 = "Default Items";
            return player;
        }
        public static Player ChangeName(this Player player, string newName) {
            player.Name = newName;
            return player;
        }

        public static void PrintPlayer(this Player player) {
            Console.WriteLine(player.Name);
            Console.WriteLine("Hello World! from extended metho!!");
        }
    }
}
