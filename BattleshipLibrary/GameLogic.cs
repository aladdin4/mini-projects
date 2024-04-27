using BattleshipLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipLibrary {
    public static class GameLogic {

        public static void CreatePlayers(int dimensions, List<PlayerModel> playerList) {
            playerList.ForEach(player =>
            {
                player.Name = "Player " + (playerList.IndexOf(player) + 1);
                player.ShipsGrid = CreateGrid(dimensions, dimensions);
                player.AttacksGird = CreateGrid(dimensions, dimensions);
            });
        }

        public static List<GridRowModel> CreateGrid(int rows, int columns) {
            var grid = new List<GridRowModel>();
            for (int i = 0; i < rows; i++)
            {
                var letter = (char)(i + 65);
                var row = new GridRowModel();
                row.Columns = new List<GridSpotModel>();
                for (int j = 0; j < columns; j++)
                {
                    var spot = new GridSpotModel
                    {
                        SpotStatus = Status.Empty,
                        SpotLetter = letter.ToString(),
                        SpotNumber = j + 1
                    };
                    row.Columns.Add(spot);
                }
                grid.Add(row);

            }
            return grid;
        }

       public static void CalculateScores(PlayerModel player, PlayerModel otherPlayer) {
            player.Hits = 0;
            player.Misses = 0;
            player.Sunk = 0;
            for (int i = 0; i < player.AttacksGird.Count; i++)
            {
                for (int j = 0; j < player.AttacksGird[i].Columns.Count; j++)
                {
                    switch (player.AttacksGird[i].Columns[j].SpotStatus)
                    {
                        case Status.Hit:
                            player.Hits++;
                            break;
                        case Status.Miss:
                            player.Misses++;
                            break;
                        default:
                            break;
                    }
                }
            }
            for (int i = 0; i < otherPlayer.AttacksGird.Count; i++)
            {
                for (int j = 0; j < otherPlayer.AttacksGird[i].Columns.Count; j++)
                {
                    if (otherPlayer.AttacksGird[i].Columns[j].SpotStatus == Status.Hit)
                    {
                        player.Sunk++;
                    }
                }
            }
            Console.WriteLine("Hits: " + player.Hits);
            Console.WriteLine("Misses: " + player.Misses);
            Console.WriteLine("Sunk: " + player.Sunk);
        }
    }
}
