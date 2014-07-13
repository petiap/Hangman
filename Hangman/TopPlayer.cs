namespace Hangman
{
    using System;

    class TopPlayer
    {
        private string playerName;
        private double playerScore;

        public string PlayerName
        {
            get { return this.playerName; }
            set { this.playerName = value; }
        }

        public double PlayerScore
        {
            get { return this.playerScore; }
            set { this.playerScore = value; }
        }
    }
}