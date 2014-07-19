namespace Hangman
{
    using System;

    public class Game
    {
        private GameState state;
        private Word word;
        private int numberOfMistakes;

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
			get { return this.numberOfMistakes; }
			// TODO: Implement value checks
			set { this.numberOfMistakes = value; }
		}

        public void Run()
        {
            this.State.PerformAction(this);
        }
    }
}