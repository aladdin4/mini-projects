using BattleshipLibrary.Models;
using System;
using System.Collections.Generic;

namespace BattleshipUI {

    /// <summary>
    /// Application Summary
    /// To build a small, two-player console game that has its roots in the classic board game Battleship.
    /// There will be 25 squares on the board, and each player will have five ships to place on the board.
    /// The squares will be labeled with letters and numbers, from A to E and 1 to 5.
    /// players will take turns firing at each other's ships by calling out the coordinates of the square they want to attack.
    /// The game will end when one player has sunk all of the other player's ships.
    /// </summary>
    /// 
    //TBD: Input Validation
    //TBD: Sunk Ships
    internal class Program {
        static int currentPlayerHits = 0;
        static int currentPlayerMisses = 0;
        static int currentPlayersunk = 0;

        static void Main(string[] args) {

            //intro
            Console.WriteLine("Welcome to Battleship Lite!");
            Console.WriteLine("Please Enter Diemensions for the game board.");
            var Dimensions = int.TryParse(Console.ReadLine(), out int result) ? result : 5;
            Console.Clear();

            //player 1 places ships
            var Player1ShipsGrid = CreateGrid(Dimensions, Dimensions);
            PlaceShips("Player 1", Player1ShipsGrid);

            //player 2 places ships
            var Player2ShipsGrid = CreateGrid(Dimensions, Dimensions);
            PlaceShips("Player 2", Player2ShipsGrid);


            //game loop
            List<GridRow> Player1AttackGrid = CreateGrid(Dimensions, Dimensions);
            List<GridRow> Player2AttackGrid = CreateGrid(Dimensions, Dimensions);
            while (true)
            {
                //player 1 turn
                PlaceShoot("Player 1", Player1AttackGrid, Player2ShipsGrid);
                CalculateScores(Player1AttackGrid);
                CheckForWinner("Player 1");

               

                //player 2 turn
                PlaceShoot("Player 2", Player2AttackGrid, Player1ShipsGrid);
                CalculateScores(Player2AttackGrid);
                CheckForWinner("Player 2");
            }
        }

        static List<GridRow> CreateGrid(int rows, int columns) {
            var grid = new List<GridRow>();
            for (int i = 0; i < rows; i++)
            {
                var letter = (char)(i + 65);
                var row = new GridRow();
                row.Columns = new List<GridSpot>();
                for (int j = 0; j < columns; j++)
                {
                    var number = j + 1;
                    var spot = new GridSpot();
                    spot.SpotStatus = GridSpot.Status.Empty;
                    spot.SpotLetter = letter.ToString();
                    spot.SpotNumber = number;
                    row.Columns.Add(spot);
                }
                grid.Add(row);

            }
            return grid;
        }

        static void PrintGrid(List<GridRow> grid) {
            for (int i = 0; i < grid.Count; i++)
            {
                for (int j = 0; j < grid[i].Columns.Count; j++)
                {
                    var spot = grid[i].Columns[j];
                    switch (spot.SpotStatus)
                    {
                        case GridSpot.Status.Empty:
                            Console.Write(spot.SpotLetter + spot.SpotNumber);
                            break;
                        case GridSpot.Status.Ship:
                            Console.Write("SS");
                            break;
                        case GridSpot.Status.Miss:
                            Console.Write("MM");
                            break;
                        case GridSpot.Status.Hit:
                            Console.Write("HH");
                            break;
                        case GridSpot.Status.Sunk:     //useless untill a ship can take more than one hit
                            Console.Write("XX");
                            break;
                        default:
                            break;
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        static void PlaceShips(string player, List<GridRow> grid) {
            PrintGrid(grid);
            Console.WriteLine($"{player}, please place your ships on the board.");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter the coordinates for ship #" + (i + 1) + ": ");
                var coordinates = Console.ReadLine();
                var row = coordinates[0] - 65;
                var column = coordinates[1] - 49;
                grid[row].Columns[column].SpotStatus = GridSpot.Status.Ship;
                Console.Clear();
                PrintGrid(grid);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void PlaceShoot(string player, List<GridRow> attackGrid, List<GridRow> othersShipsGrid) {
            Console.Clear();
            Console.WriteLine($"{player} , enter coordinates to attack: ");
            var coordinates = Console.ReadLine();
            var row = coordinates[0] - 65;
            var column = coordinates[1] - 49;
            if (othersShipsGrid[row].Columns[column].SpotStatus == GridSpot.Status.Ship)
            {
                Console.WriteLine("Hit!");
                attackGrid[row].Columns[column].SpotStatus = GridSpot.Status.Hit;
            }
            else
            {
                Console.WriteLine("Miss!");
                attackGrid[row].Columns[column].SpotStatus = GridSpot.Status.Miss;
            }
            PrintGrid(attackGrid);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void CalculateScores(List<GridRow> attackGrid) {
            currentPlayerHits = 0;
            currentPlayerMisses = 0;
            currentPlayersunk = 0;

            for (int i = 0; i < attackGrid.Count; i++)
            {
                for (int j = 0; j < attackGrid[i].Columns.Count; j++)
                {
                    switch (attackGrid[i].Columns[j].SpotStatus)
                    {
                        case GridSpot.Status.Hit:
                            currentPlayerHits++;
                            break;
                        case GridSpot.Status.Miss:
                            currentPlayerMisses++;
                            break;
                        case GridSpot.Status.Sunk:
                            currentPlayersunk++;
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine("Hits: " + currentPlayerHits);
            Console.WriteLine("Misses: " + currentPlayerMisses);
            Console.WriteLine("Sunk: " + currentPlayersunk);
        }

        static void CheckForWinner(string player) {
            if (currentPlayerHits == 5)
            {
                Console.WriteLine(player + " wins!");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
