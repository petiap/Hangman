namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Hangman
    { 
		const int LETTER = 1;
        static char InputLetter;
        static bool NotUseHelp = true;

        static void Main()
        {
            while (true)
            {
                StringBuilder initialGameMessage = new StringBuilder();
                initialGameMessage.AppendLine("Welcome to “Hangman” game.Please try to guess my secret word.");
                initialGameMessage.AppendLine("Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to cheat and 'exit' to quit the game.");

                Console.Write(initialGameMessage);

                Word secretWord = new Word();

                int playerMistakes = 0;               
                                
                StringBuilder command = new StringBuilder();

                while (secretWord.MaskedWord.Contains('_'))
                {
                    //start new game

                    Console.WriteLine("The secret word is " + secretWord.MaskedWord);
                    
                    command.Clear();

                    Console.Write("Enter your guess: ");
                    command.Append(Console.ReadLine());

                    if (command.Length == LETTER)
                    {
                        InputLetter = command[0];
                    }

                    if (command.Length == LETTER && secretWord.IsLetter(char.ToLower(InputLetter)))
                    {
                        if (secretWord.CheckForLetter(char.ToLower(InputLetter)))
                        {
                            secretWord.WriteTheLetter(char.ToLower(InputLetter));
                            Console.WriteLine("Good job! You revealed " + secretWord.NumberOfInput(InputLetter) + " letter");
                        }
                        else
                        {
                            Console.WriteLine("Sorry! There are no unrevealed letters " + "\"" + char.ToLower(InputLetter) + "\"");
                            playerMistakes++;
                        }
                    }
                    else
                    {
                        bool Restart = false;

                        switch (command.ToString())
                        {
                            case "help":
                                {
                                    GiveHint(secretWord);

                                    break;
                                }
                            case "exit":
                                {
                                    Environment.Exit(0);

                                    break;
                                }
                            case "restart":
                                {
                                    Restart = true;

                                    break;
                                }
                            case "top":
                                {
                                    ShowScoreboard();

                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Incorect input");
                                    playerMistakes++;

                                    break;
                                }
                        }

                        if (Restart)
                        {
                            Console.WriteLine("Game is Restarted");
                            break;
                        }
                    }
                }

                if (!secretWord.MaskedWord.Contains('_'))
                {
                    Console.WriteLine("The secret word is " + secretWord.MaskedWord);
                    Console.Write("\nYou won with " + playerMistakes + " mistakes");

                    bool BetterThanLast = Scoreboard.ScoreboardInstance.IsNewTopScore(playerMistakes);

                    if (NotUseHelp && BetterThanLast)
                    {
                        Console.Write("\nPlease enter your name for the top scoreboard: ");

                        string newTopPlayerName = Console.ReadLine();
                        Player newTopPlayer = new Player(newTopPlayerName, playerMistakes);
                        Scoreboard.ScoreboardInstance.AddPlayer(newTopPlayer);

                        ShowScoreboard();                        
                    }
                    else if (!BetterThanLast)
                    {
                        Console.Write(" but your result is lower than top scores\n");
                    }
                    else
                    {
                        Console.Write(" but you have cheated. \nYou are not allowed to enter into the scoreboard.\n");
                    }

                    playerMistakes = 0;
                    NotUseHelp = true;
                }
            }
        }

        private static void InterpredCommand(StringBuilder command, Word WordsInGame)
        {

        }

        private static void ShowScoreboard()
        {
            Console.WriteLine("Scoreboard:");

            Console.WriteLine(Scoreboard.ScoreboardInstance.ToString());                
        }

        private static void GiveHint(Word Game)
        {
            Console.WriteLine("OK, I reveal for you the next letter " + "\""
							   + Game.MaskedWord[Game.MaskedWord.IndexOf('_') / 2] + "\"");

			int FirstMissingLetter = Game.MaskedWord.IndexOf('_');

			Game.WriteTheLetter(Game.MaskedWord[FirstMissingLetter / 2]);
            NotUseHelp = false;
        }
    }
}