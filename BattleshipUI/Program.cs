using BattleshipLibrary;
using BattleshipLibrary.Models;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace BattleshipUI {

    /// <summary>
    /// Application Summary
    //## User Story
    //As a player,
    //I want to play a small, two-player console game based on the classic board game Battleship.
    //The game should have a 5x5 game board with labeled squares from A to E and 1 to 5.
    //Each player should have five ships to place on the board.
    //Players should take turns firing at each other's ships by calling out the coordinates of the square they want to attack.
    //The game should end when one player has sunk all of the other player's ships.
    //The game should track hits, misses, and sunk ships for each player.
    //## Acceptance Criteria
    //- The game board should be a 5x5 grid with labeled squares.
    //- Each player should have five ships to place on the board.
    //- Players should take turns firing at each other's ships by entering the coordinates of the square they want to attack.
    //- The game should track hits, misses, and sunk ships for each player.
    //- The game should end when one player has sunk all of the other player's ships.
    /// </summary>
    internal class Program {
        static PlayerModel player1 = new PlayerModel();
        static PlayerModel player2 = new PlayerModel();
        static List<PlayerModel> playerList = new List<PlayerModel>
            {
                player1,
                player2
            };

        //TBD: Input Validation
        static void Main(string[] args) {
            Console.WriteLine("Welcome to Battleship Lite!");
            Console.WriteLine("Please Enter Diemensions for the game board.");
            var dimensions = int.TryParse(Console.ReadLine(), out int result) ? result : 5;
            Console.Clear();
            GameLogic.CreatePlayers(dimensions, playerList);
            GameOn();
        }

        static void GameOn() {
            playerList.ForEach(player =>
                PlaceShips(player.Name, player.ShipsGrid)
            );

            while (true)
            {
                playerList.ForEach(player =>
                {
                    var otherPlayer = playerList.Find(p => p.Name != player.Name);
                    PlaceShoot(player, otherPlayer);
                    GameLogic.CalculateScores(player, otherPlayer);
                    CheckForWinner(player);
                });
            }
        }

        static void PrintGrid(List<GridRowModel> grid) {
            //to print the headers of the grid and side labels
            //then print the grid as we do it, but instead of spotletter and number make it _ or X or O


            Console.Write("    ");
            for (int i = 0; i < grid[0].Columns.Count; i++)
            {
                if(i < 9)
                    Console.Write((i + 1) + "   ");
                else
                    Console.Write((i + 1) + "  ");
            }
             Console.WriteLine ();
            for (int i = 0; i < grid.Count; i++)
            {
                Console.Write(" " + (char)(i + 65) + " ");
               
                for (int j = 0; j < grid[i].Columns.Count; j++)
                {
                    var spot = grid[i].Columns[j];
                    switch (spot.SpotStatus)
                    {
                        case Status.Empty:
                            Console.Write(" _ ");
                            break;
                        case Status.Ship:
                            Console.Write(" S ");
                            break;
                        case Status.Miss:
                            Console.Write(" M ");
                            break;
                        case Status.Hit:
                            Console.Write(" H ");
                            break;
                        case Status.Sunk:     //useless untill a ship can take more than one hit
                            Console.Write(" X ");
                            break;
                        default:
                            break;
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PlaceShips(string player, List<GridRowModel> grid) {
            PrintGrid(grid);
            Console.WriteLine($"{player}, please place your ships on the board.");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter the coordinates for ship #" + (i + 1) + ": ");
                var coordinates = Console.ReadLine();
                var row = coordinates[0] - 65;
                var column = coordinates[1] - 49;
                grid[row].Columns[column].SpotStatus = Status.Ship;
                Console.Clear();
                PrintGrid(grid);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void PlaceShoot(PlayerModel player, PlayerModel otherPlayer) {
            Console.Clear();

            Console.WriteLine($"{player.Name} , enter coordinates to attack: ");
            var coordinates = Console.ReadLine();
            var row = coordinates[0] - 65;
            var column = coordinates[1] - 49;
            if (otherPlayer.ShipsGrid[row].Columns[column].SpotStatus == Status.Ship)
            {
                Console.WriteLine("Hit!");
                player.AttacksGird[row].Columns[column].SpotStatus = Status.Hit;

            }
            else
            {
                Console.WriteLine("Miss!");
                player.AttacksGird[row].Columns[column].SpotStatus = Status.Miss;
            }
            PrintGrid(player.AttacksGird);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void CheckForWinner(PlayerModel player) {
            if (player.Hits == 5)
            {
                Console.WriteLine(player.Name + " wins!");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
