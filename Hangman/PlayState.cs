namespace Hangman
{
    using System;
    using System.Linq;

    public class PlayState : GameState
    {
        public override void PerformAction(Game game)
        {
            if (game.Word.MaskedWord.Contains('_'))
            {
                Console.WriteLine("The secret word is " + game.Word.MaskedWord);

                Console.Write("Enter your guess: ");

                string command = Console.ReadLine();

                CommandInterpreter.Decode(command);            
            }
            else
            {
                GameEngine.EstimateScore(game.Word, game.NumberOfMistakes);
                game.NumberOfMistakes = 0;

                game.State = new InitialState();
            }
        } 
    }
}