namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Hangman
    { 
		const int ONE_LETTER = 1;
        const double MAX_SCORE = 1000000000.5;

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

       
        static TopPlayer DefaultTopPlayer = new TopPlayer { PlayerName = "", PlayerScore = MAX_SCORE };
        static TopPlayer[] TopPlayers = new TopPlayer[6];


        static char InputLetter;
        static bool NotUseHelp = true;
        static int GameCounter = 0;

        static void Main()
        {
            for (int playersNumber = 0; playersNumber < 6; playersNumber++)
            {
                TopPlayers[playersNumber] = DefaultTopPlayer;
            }

            Random randomWord = new Random();
            

            while (true)
            {   //main loop, used to restart game automatically

                Console.Write("\nWelcome to “Hangman” game.Please try to guess my secret word.\nUse 'top' to view the top scoreboard,"
                        + "'restart' to start a new game, \n'help' to cheat and 'exit' to quit the game.\n");

                int PlayerMistakes = 0;
				string PlayedWord = words[randomWord.Next(0, 10)];
                StringBuilder printedWord = new StringBuilder();
                StringBuilder inputString = new StringBuilder();
				printedWord.Clear();

                for (int WordLenght = 0; WordLenght < PlayedWord.Length; WordLenght++)
                {   //makes _ _ _ _ _...
					printedWord.Append("_ ");
                }

				Word WordsInGame = new Word(PlayedWord, printedWord);
                //WordsInGame.SetPlayedWord();
               // WordsInGame.SetPrintedWord();

				while (WordsInGame.PrintedWord.ToString().Contains('_'))
                {
                    //start new game

					Console.WriteLine("The secret word is " + WordsInGame.PrintedWord);

                    Console.Write("Enter your guess: ");
					inputString.Clear();
					inputString.Append(Console.ReadLine());

					if (inputString.Length == ONE_LETTER)
                    {
						InputLetter = (inputString[0]);
                    }

					if (inputString.Length == ONE_LETTER && WordsInGame.Isletter(char.ToLower(InputLetter)))
                    {


                        if (WordsInGame.CheckForLetter(char.ToLower(InputLetter)))
                        {
                            WordsInGame.WriteTheLetter(char.ToLower(InputLetter));
                            Console.WriteLine("Good job! You revealed " + WordsInGame.NumberOfInput(InputLetter) + " letter");
                        }
                        else
                        {
                            Console.WriteLine("Sorry! There are no unrevealed letters " + "\"" + char.ToLower(InputLetter)+ "\"");
                            PlayerMistakes++;
                        }

                    }
                    else
                    {
                        bool Restart = false;

						switch (inputString.ToString())
                        {
                            case "help": GiveHint(WordsInGame); break;                                

                            case "exit": Environment.Exit(0); break;

                            case "restart": Restart = true; break;

                            case "top": ShowScoreboard(); break;

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

                    bool BetterThanLast = TopPlayers[4].PlayerScore > PlayerMistakes;
                    if (NotUseHelp && BetterThanLast)
                    {
                        
                        Console.Write("\nPlease enter your name for the top scoreboard: ");
                                                                       
                        TopPlayers[GameCounter] = new TopPlayer { PlayerName = Console.ReadLine(), PlayerScore = PlayerMistakes };

                        if (GameCounter < 5)
                        {
                            GameCounter++;
                        }

                        Array.Sort(TopPlayers, (TopPlayer1, topPlayer2) => TopPlayer1.PlayerScore.CompareTo(topPlayer2.PlayerScore));
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
            Console.WriteLine("Scoreboard: ");

            for (int playersNumber = 0; playersNumber < 5; playersNumber++)
            {
                if (TopPlayers[playersNumber].PlayerScore != MAX_SCORE)
                {
                    Console.WriteLine(TopPlayers[playersNumber].PlayerScore.ToString() + " " + TopPlayers[playersNumber].PlayerName);
                }
            }

            if (GameCounter == 0)
            {
                Console.WriteLine("Scoreboard is empty");
            }
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
