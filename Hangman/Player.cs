using System.Text;

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
				decimal number;

				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("Value of top player name is null or white space.");
				}

				if (decimal.TryParse(value, out number))
				{
					throw new ArgumentOutOfRangeException("Value of top player name is a number.");
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
				if (string.IsNullOrWhiteSpace(value.ToString()))
				{
					throw new ArgumentNullException("Value of word to guess is null or white space.");
				}

				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value of the player score is less than zero.");
				}

				if (value > 28)
				{
					throw new ArgumentOutOfRangeException("Value of the player score is more" +
						" than all letters in the alphabet.");
				}

				this.score = value;
            }
        }

		// it will be better to have it here and call it in scoreboard directly
	    public override string ToString()
	    {
		    StringBuilder str = new StringBuilder();
		    string comment = this.Score == 1 ? "mistake" : "mistakes";

		    str.Append(this.Name + " --> " + this.Score + " " + comment);

		    return str.ToString();
	    }
    }
}