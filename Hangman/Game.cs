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

        public GameState State
        {
            get 
            {
                return this.state; 
            }

            set
            {
                if (!(value is InitialState || value is PlayState))
                {
                    throw new ArgumentException("State", "Incorrect type of state value");
                }

                this.state = value;
            }
        }

        public Word Word
        {
            get
            {
                return this.word;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value.SecretWord))
                {
                    throw new ArgumentNullException("Word.SecretWord", "Value can't be null or empty string");
                }

                if (string.IsNullOrWhiteSpace(value.MaskedWord))
                {
                    throw new ArgumentNullException("Word.MaskedWord", "Value can't be null or empty string");
                }
            }
        }

        public int NumberOfMistakes
        {
            get 
            {
                return this.numberOfMistakes; 
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("NumberOfMistakes", "Value can't be negative");
                }

                this.numberOfMistakes = value;
            }
        }

        public void Run()
        {
            this.State.PerformAction(this);
        }
    }
}