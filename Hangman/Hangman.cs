namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Hangman
    { 
		const int LETTER = 1;

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
            {
                StringBuilder initialGameMessage = new StringBuilder();
                initialGameMessage.AppendLine("Welcome to “Hangman” game.Please try to guess my secret word.");
                initialGameMessage.AppendLine("Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to cheat and 'exit' to quit the game.");

                Console.Write(initialGameMessage);

                string secretWord = words[randomWordGenerator.Next(0, (words.Length - 1))];
                StringBuilder maskedWord = new StringBuilder();

                for (int wordLenght = 0; wordLenght < secretWord.Length; wordLenght++)
                {   //makes _ _ _ _ _
                    maskedWord.Append("_ ");
                }
                
                int playerMistakes = 0;               
                                
                StringBuilder command = new StringBuilder();



                Word WordsInGame = new Word(secretWord, maskedWord);

                while (WordsInGame.MaskedWord.ToString().Contains('_'))
                {
                    //start new game

                    Console.WriteLine("The secret word is " + WordsInGame.MaskedWord);
                    
                    command.Clear();

                    Console.Write("Enter your guess: ");
                    command.Append(Console.ReadLine());

                    if (command.Length == LETTER)
                    {
                        InputLetter = command[0];
                    }

                    if (command.Length == LETTER && WordsInGame.Isletter(char.ToLower(InputLetter)))
                    {
                        if (WordsInGame.CheckForLetter(char.ToLower(InputLetter)))
                        {
                            WordsInGame.WriteTheLetter(char.ToLower(InputLetter));
                            Console.WriteLine("Good job! You revealed " + WordsInGame.NumberOfInput(InputLetter) + " letter");
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

                if (!WordsInGame.MaskedWord.ToString().Contains('_'))
                {
                    Console.WriteLine("The secret word is " + WordsInGame.MaskedWord);
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
							   + Game.MaskedWord.ToString()[Game.MaskedWord.ToString().IndexOf('_') / 2] + "\"");

			int FirstMissingLetter = Game.MaskedWord.ToString().IndexOf('_');

			Game.WriteTheLetter(Game.MaskedWord.ToString()[FirstMissingLetter / 2]);
            NotUseHelp = false;
        }
    }
}