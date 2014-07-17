namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Hangman
    { 
		const int ONE_LETTER = 1;

        static readonly string[] words = { 
                                             "computer",
                                             "programmer",
                                             "software",
                                             "debugger",
                                             "compiler",
                                             "developer",
                                             "algorithm",
                                             "array",
                                             "method",
                                             "variable"
                                         };

        static char InputLetter;
        static bool NotUseHelp = true;

        static void Main()
        {
            Random randomWordGenerator = new Random();

            while (true)
            {   //main loop, used to restart game automatically

                Console.Write("\nWelcome to “Hangman” game.Please try to guess my secret word.\nUse 'top' to view the top scoreboard,"
                        + "'restart' to start a new game, \n'help' to cheat and 'exit' to quit the game.\n");

                int PlayerMistakes = 0;

                string secretWord = words[randomWordGenerator.Next(0, (words.Length - 1))];

                StringBuilder printedWord = new StringBuilder();
                StringBuilder command = new StringBuilder();
                printedWord.Clear();

                for (int wordLenght = 0; wordLenght < secretWord.Length; wordLenght++)
                {   //makes _ _ _ _ _
                    printedWord.Append("_ ");
                }

                Word WordsInGame = new Word(secretWord, printedWord);
                //WordsInGame.SetPlayedWord();
                // WordsInGame.SetPrintedWord();

                while (WordsInGame.PrintedWord.ToString().Contains('_'))
                {
                    //start new game

                    Console.WriteLine("The secret word is " + WordsInGame.PrintedWord);

                    Console.Write("Enter your guess: ");
                    command.Clear();
                    command.Append(Console.ReadLine());

                    if (command.Length == ONE_LETTER)
                    {
                        InputLetter = (command[0]);
                    }

                    if (command.Length == ONE_LETTER && WordsInGame.Isletter(char.ToLower(InputLetter)))
                    {
                        if (WordsInGame.CheckForLetter(char.ToLower(InputLetter)))
                        {
                            WordsInGame.WriteTheLetter(char.ToLower(InputLetter));
                            Console.WriteLine("Good job! You revealed " + WordsInGame.NumberOfInput(InputLetter) + " letter");
                        }
                        else
                        {
                            Console.WriteLine("Sorry! There are no unrevealed letters " + "\"" + char.ToLower(InputLetter) + "\"");
                            PlayerMistakes++;
                        }

                    }
                    else
                    {
                        bool Restart = false;

                        switch (command.ToString())
                        {
                            case "help":
                                {
                                    GiveHint(WordsInGame);

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
                                    PlayerMistakes++;

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

                if (!WordsInGame.PrintedWord.ToString().Contains('_'))
                {
                    Console.WriteLine("The secret word is " + WordsInGame.PrintedWord);
                    Console.Write("\nYou won with " + PlayerMistakes + " mistakes");

                    bool BetterThanLast = Scoreboard.ScoreboardInstance.IsNewTopScore(PlayerMistakes);

                    if (NotUseHelp && BetterThanLast)
                    {
                        Console.Write("\nPlease enter your name for the top scoreboard: ");

                        string newTopPlayerName = Console.ReadLine();
                        Player newTopPlayer = new Player(newTopPlayerName, PlayerMistakes);
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

                    PlayerMistakes = 0;
                    NotUseHelp = true;
                }
            }
        } 
       
        private static void ShowScoreboard()
        {
            Console.WriteLine("Scoreboard:");

            Console.WriteLine(Scoreboard.ScoreboardInstance.ToString());                
        }

        private static void GiveHint(Word Game)
        {
            Console.WriteLine("OK, I reveal for you the next letter " + "\""
							   + Game.PrintedWord.ToString()[Game.PrintedWord.ToString().IndexOf('_') / 2] + "\"");

			int FirstMissingLetter = Game.PrintedWord.ToString().IndexOf('_');

			Game.WriteTheLetter(Game.PrintedWord.ToString()[FirstMissingLetter / 2]);
            NotUseHelp = false;
        }
    }
}