﻿namespace Hangman
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
                    Console.WriteLine("Incorect guess or command!");
                    getGame().Mistakes++;
                    break;
            }
        }
    }
}