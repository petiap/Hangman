namespace Hangman
{
    using System;

    public class InitialState : GameState
    {
        const string WelcomeMessage = "Welcome to “Hangman” game.Please try to guess my secret word. \n" +
                "Use 'top' to view the top scoreboard, 'restart' to start a new game, "+
				"'help' to cheat and 'exit' to quit the game. \n";

        public override void PerformAction(Game game)
        {
			Console.Write(WelcomeMessage);

            game.Word = new Word();
            game.Mistakes = 0;

            CommandInterpreter.AssignGameDelegate(() => game);

            game.State = new PlayState();
        }        
    }
}