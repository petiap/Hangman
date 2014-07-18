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
        public GameState State { get; set; }

        public Word Word { get; set; }

        public int NumberOfMistakes { get; set; }

        public void Run()
        {
            this.State.PerformAction(this);
        }
    }
}