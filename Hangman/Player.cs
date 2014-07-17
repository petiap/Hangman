namespace Hangman
{
    using System;

    public class Player
    {
        private string playerName;
        private int playerScore;

        public Player(string gamePlayerName, int gamePlayerScore)
        {
            this.PlayerName = gamePlayerName;
            this.PlayerScore = gamePlayerScore;
        }

        public string PlayerName
        {
            get
            {
                return this.playerName;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("PlayerName", "Value can't be null or an empty string");
                }

                this.playerName = value;
            }
        }

        public int PlayerScore
        {
            get
            {
                return this.playerScore;
            }

            set
            {
                if (playerScore < 0)
                {
                    throw new ArgumentOutOfRangeException("PlayerScore", "Value can't be negative");
                }

                this.playerScore = value;
            }
        }
    }
}