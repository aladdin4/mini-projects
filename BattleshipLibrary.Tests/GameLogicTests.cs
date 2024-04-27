using BattleshipLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BattleshipLibrary.Tests {
    public class GameLogicTests {
        [Fact]
        public void CreatePlayersTest() {
            // Arrange
            int dimensions = 5;
            List<PlayerModel> players = new List<PlayerModel>
            {
                new PlayerModel { },
                new PlayerModel { }
            };

            // Act
            GameLogic.CreatePlayers(dimensions, players);

            // Assert every player has a name, a ShipsGrid, and an AttacksGrid
            Assert.Equal(2, players.Count);
            Assert.All(players, player =>
            {
                int playerIndex = players.IndexOf(player);
                Assert.Equal("Player " + (playerIndex + 1), player.Name);
                Assert.Equal(dimensions, player.ShipsGrid.Count);
                Assert.Equal(dimensions, player.AttacksGird.Count);
            });
        }

        [Fact]
        public void CreateGridTest() {
           var testGird = GameLogic.CreateGrid(5, 5);
            Assert.Equal(5, testGird.Count);
            Assert.All(testGird, row =>
            {
                Assert.Equal(5, row.Columns.Count);
                Assert.All(row.Columns, spot =>
                {
                    Assert.Equal(Status.Empty, spot.SpotStatus);
                    Assert.True(spot.SpotLetter.Length == 1);
                    Assert.True(spot.SpotNumber > 0);
                });
            });
        }
    }
}
