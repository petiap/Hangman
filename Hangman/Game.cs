namespace Hangman
{
    using System;

    public class Game
    {
        private GameState state;
        private Word word;
        private int mistakes;

        public Game(GameState gameState)
        {
            this.State = gameState;
        }

        // TODO: Implement value checks
        public GameState State 
		{ 
			get { return this.state; }
			// TODO: Implement value checks
	        set { this.state = value; }
		}

	    public Word Word
	    {
		    get { return this.word; }
			// TODO: Implement value checks
			set { this.word = value; }
	    }

		public int Mistakes
		{
			get { return this.mistakes; }
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
					throw new ArgumentOutOfRangeException("Value of the mistaces is more" +
						" than all letters in the alphabet.");
				}
				this.mistakes = value;
			}
		}

        public void Run()
        {
            this.State.PerformAction(this);
        }
    }
}