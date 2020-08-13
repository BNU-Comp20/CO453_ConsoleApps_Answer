using System;

namespace CO453_ConsoleAppAnswer.App05
{
    /// <summary>
    /// The three available choices during the game
    /// </summary>
    public enum GameChoice
    {
        Rock, 
        Paper,
        Scissors
    }
    
    /// <summary>
    /// The two players of the game
    /// </summary>
    public enum GamePlayer
    {
        None,
        Computer,
        Player
    }

    /// <summary>
    /// This class models the Rock-Paper-Scissors 
    /// game and contains all the information on
    /// the state of the game and methods to implement
    /// the basic logic of the game.  It requires
    /// another class to provide the user interface
    /// and control the progress of the game.
    /// </summary>
    /// <author>
    /// Derek Peacock version 0.1
    /// </author>
    public class Game
    {
        // Players Properties
        public string PlayerName { get; }

        // Public only for Unit testing
        public int PlayerScore { get; set; }

        // Public only for Unit Testing
        public GameChoice PlayerChoice { get; set; }

        // Computer Properties
        public int ComputerScore { get; set; }
        
        // Public only for Unit Testing
        public GameChoice ComputerChoice { get; set; }

        // Game Properties
        public int LastRound { get; set; }

        public int Round { get; set; }

        public GamePlayer CurrentPlayer { get; set; }

        public String WinnerName { get; set; }

        // Use seed to get same sequence of random numbers
        private Random generator = new Random(55);

        public Game(string name)
        {
            PlayerName = name;
            LastRound = 5;
            Start();
        }

        public void Start()
        {
            PlayerScore = 0;
            ComputerScore = 0;

            CurrentPlayer = GamePlayer.Player;
            Round = 1;
        }

        public void GetComputerChoice()
        {
            int choice = generator.Next(1, 4);
            
            switch (choice)
            {
                case 1: ComputerChoice = GameChoice.Rock; break;
                case 2: ComputerChoice = GameChoice.Paper; break;
                case 3: ComputerChoice = GameChoice.Scissors; break;
            }
        }
        public void ScoreRound()
        {
            if(PlayerChoice == GameChoice.Rock && 
               ComputerChoice == GameChoice.Paper)
            {
                ComputerScore += 2;
                WinnerName = GamePlayer.Computer.ToString();
            }

            if (Round < LastRound) Round++;
            else End();
        }

        public void End()
        {
            if (ComputerScore > PlayerScore)
            {
                WinnerName = GamePlayer.Computer.ToString();
            }
            else if (PlayerScore > ComputerScore)
            {
                WinnerName = PlayerName;
            }
            else WinnerName = "No Player";
        }
    }
}
