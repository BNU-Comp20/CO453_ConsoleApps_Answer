using System;

namespace CO453_ConsoleAppAnswer.App05
{
    /// <summary>
    /// This class will create a user interface for the
    /// Rock-Paper-Scissors game using the windows
    /// Console
    /// </summary>
    /// <author>
    /// Derek Peacock version 0.1
    /// </author>
    public class GameView
    {
        private Game game;

        public Game Game
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// This method will control the progress of the
        /// game from start to end.
        /// </summary>
        public void PlayGame()
        {
            StartGame();
            ShowComputerChoice();
        }

        /// <summary>
        /// Reset a game so that the scores reset to zero
        /// for both players and the number of rounds is set.
        /// </summary>
        public void StartGame()
        {
            SetupConsole();

            UserLib.OutputHeading("  Rock-Paper-Scissors Game");

            if(game == null)
            {
                Console.Write("  What is your name > ");
                string name = Console.ReadLine();
                game = new Game(name);
            }

            game.Start();
        }


        private void SetupConsole()
        {
            Console.SetWindowSize(100, 40);
            Console.SetBufferSize(100, 40);

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        /// <summary>
        /// Repeatedly ask the player to make a choice
        /// and then ask the computer to make a choice.
        /// The choices are then compared and scored
        /// </summary>
        public void GetPlayerChoice()
        {

        }

        public void ShowComputerChoice()
        {
            switch(game.ComputerChoice)
            {
                case GameChoice.Rock: 
                    GameImages.DrawStone(5, 8); break;

                case GameChoice.Paper:
                    GameImages.DrawPaper(5, 8); break;

                case GameChoice.Scissors:
                    GameImages.DrawScissors(5, 8); break;
            }
        }

        public void ShowRoundScores()
        {

        }

        public void ShowWinner()
        {

        }
        /// <summary>
        /// One player or more players have reached the chosen 
        /// maximum score and the winner can be decided.
        /// </summary>
        public void EndGame()
        {

        }
    }
}
