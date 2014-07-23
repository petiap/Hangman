namespace Hangman
{
    using System;

    public delegate Game GetGameDelegate();

    public class CommandInterpreter : Decoder
    {
        private static GetGameDelegate getGame;

        public static void AssignGameDelegate(GetGameDelegate getGameDelegate)
        {
            getGame = getGameDelegate;
        }

        public override void Decode(string command)
        {
            switch (command)
            {
                case "help":
                    GameEngine.GiveHint(getGame().Word);
                    break;

                case "exit":
                    Console.WriteLine("Good bye!");
                    Environment.Exit(0);
                    break;

                case "restart":
                    getGame().State = new InitialState();
                    Console.WriteLine();
                    break;

                case "top":
                    GameEngine.ShowScoreboard();
                    break;

                default:
                    if (command.Length == 1 && IsValidLetter(command[0]))
                    {
                        char letter = command[0];

                        GameEngine.GuessLetter(getGame(), letter);
                    }
                    else
                    {
                        Console.WriteLine("Incorect guess or command!");
                        getGame().NumberOfMistakes++;
                    }

                    break;
            }
        }

        public static bool IsValidLetter(char symbol)
        {
            symbol = char.ToLower(symbol);

            if (symbol >= 'a' && symbol <= 'z')
            {
                return true;
            }

            return false;
        }
    }
}