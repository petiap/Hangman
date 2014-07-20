namespace Hangman
{
    using System;

    public delegate Game GetGameDelegate();

    public static class CommandInterpreter
    {
        private static GetGameDelegate getGame;
        // private string command;

        public static void AssignGameDelegate(GetGameDelegate getGameDelegate)
        {
            getGame = getGameDelegate;
        }

        // added for testing purposes only
   /*     public CommandInterpreter(string command)
        {
            this.Command = command;
        }

        public string Command
        {
            get
            {
                return this.command;
            }

            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
				{
					throw new ArgumentNullException("Value of the word is null or missing.");
				}
                this.command = value;
            }
        }
    */
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
                    Console.WriteLine("Incorect guess or command!");
                    getGame().Mistakes++;
                    break;
            }
        }
    }
}