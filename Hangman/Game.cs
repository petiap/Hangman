namespace Hangman
{
    using System;
	
    public class Game
    {
		private const int MaxPosibleMistakes=28;

        private GameState state;
        private Word word;
        private int mistakes;

        public Game(GameState gameState)
        {
            this.State = gameState;
        }

        public GameState State 
		{ 
			get { return this.state; }
	        set
	        {
				if (string.IsNullOrEmpty(value.ToString()))
				{
					throw new ArgumentNullException("Value of the state is null or missing.");
				}

		        this.state = value;
	        }
		}

	    public Word Word
	    {
		    get { return this.word; }
		    set
		    {
				if (string.IsNullOrEmpty(value.ToString()))
				{
					throw new ArgumentNullException("Value of the word is null or missing.");
				}

			    if (string.IsNullOrEmpty(value.MaskedWord))
			    {
					throw new ArgumentNullException("Value of the masked word is null or missing.");
			    }

				if (string.IsNullOrEmpty(value.SecretWord))
				{
					throw new ArgumentNullException("Value of the secret word is null or missing.");
				}
				this.word = value;
		    }
	    }

		public int Mistakes
		{
			get { return this.mistakes; }
			set
			{
				if (string.IsNullOrWhiteSpace(value.ToString()))
				{
					throw new ArgumentNullException("Value of mistakes is null or white space.");
				}

				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value of the mistakes is less than zero.");
				}

				if (value > MaxPosibleMistakes)
				{
					throw new ArgumentOutOfRangeException("Value of the mistakes is more" +
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