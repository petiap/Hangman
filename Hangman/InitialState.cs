namespace Hangman
{
    using System;
    public class InitialState : GameState
    {
        const string WELCOME_MESSAGE = "Welcome to “Hangman” game.Please try to guess my secret word. \n" +
                "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to cheat and 'exit' to quit the game. \n";

        public override void PerformAction(Game game)
        {
            Console.Write(WELCOME_MESSAGE);

            game.Word = new Word();
            game.NumberOfMistakes = 0;

            CommandInterpreter.AssignGameDelegate(() => game);

            game.State = new PlayState();
        }        
    }
}