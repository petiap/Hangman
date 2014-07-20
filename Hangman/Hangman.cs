namespace Hangman
{
    using System;

    public class Hangman
    {
        public static void Main()
        {
            Game game = new Game(new InitialState());

            while (true)
            {
                // start new game
                game.Run();
            }
        }
    }
}