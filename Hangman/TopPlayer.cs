namespace Hangman
{
    using System;

    public class TopPlayer
    {
        private string playerName;
        private double playerScore;
        
        //private static TopPlayer topPlayerInstance;

        //private TopPlayer()
        //{

        //}

        //public static TopPlayer TopPlayerInstance
        //{
        //    get
        //    {
        //        if (topPlayerInstance == null)
        //        {
        //            topPlayerInstance = new TopPlayer();
        //        }

        //        return topPlayerInstance;
        //    }
        //}

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
                    throw new ArgumentNullException("PlayerName", "Value can't be null or empty string");
                }

                this.playerName = value;
            }
        }

        public double PlayerScore
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