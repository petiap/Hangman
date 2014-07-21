namespace Hangman
{
    using System;

    public delegate Game GetGameDelegate();

    public static class CommandInterpreter
    {
        private static GetGameDelegate getGame;

        public static void AssignGameDelegate(GetGameDelegate getGameDelegate)
        {
            getGame = getGameDelegate;
        }

        public static void Decode(string command)
        {
            switch (command)
            {
                case "help":
                    GameEngine.GiveHint(getGame().Word);
                    break;

                case "exit":
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
                    if (command.Length == 1)
                    {
                        char letter = command[0];

                        if (IsValidLetter(letter))
                        {
                            GameEngine.GuessLetter(getGame().Word, letter, getGame().NumberOfMistakes);
                        }
                    }

                    Console.WriteLine("Incorect guess or command!");
                    getGame().NumberOfMistakes++;
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