namespace Hangman
{
    using System;

    public class Player
    {
        private string name;
        private int score;

        public Player(string playerName, int playerScore)
        {
            this.Name = playerName;
            this.Score = playerScore;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name", "Value can't be null or an empty string");
                }

                this.name = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Score", "Value can't be negative");
                }

                this.score = value;
            }
        }
    }
}