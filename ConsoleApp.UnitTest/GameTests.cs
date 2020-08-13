using Microsoft.VisualStudio.TestTools.UnitTesting;
using CO453_ConsoleAppAnswer.App05;

namespace ConsoleApp.UnitTest
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestGameStart()
        {
            // Arrange
            Game game = new Game("Ana");

            // Act
            game.Start();

            // Assert
            Assert.AreEqual(0, game.PlayerScore);
            Assert.AreEqual(0, game.ComputerScore);
            Assert.AreEqual(1, game.Round);
            Assert.AreEqual(GamePlayer.Player, game.CurrentPlayer);
            Assert.IsNotNull(game.PlayerName);
        }

        [TestMethod]
        public void TestComputerChoiceIsRandom()
        {
            // Arrange
            Game game = new Game("Ana");
            int [] choices = new int[3];

            // Act
            for(int i = 0; i < 1000; i++)
            {
                game.GetComputerChoice();
                int choice = (int)game.ComputerChoice;
                choices[choice]++;
            }

            // Assert
            Assert.IsTrue(choices[0] > 300);
            Assert.IsTrue(choices[1] > 300);
            Assert.IsTrue(choices[2] > 300);
        }

        [TestMethod]
        public void TestScoreRoundRockPaper()
        {
            // Arrange
            Game game = new Game("Ana");
            game.Start();

            game.PlayerChoice = GameChoice.Rock;
            game.ComputerChoice = GameChoice.Paper;

            // Act
            game.ScoreRound();

            // Assert
            Assert.AreEqual(0, game.PlayerScore);
            Assert.AreEqual(2, game.ComputerScore);
            Assert.AreEqual("Computer", game.WinnerName);
        }
    }
}
