namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Hangman
    { 
		const int LETTER = 1;

        static bool NotUseHelp = true;

        static void Main()
        {
            const string WELCOME_MESSAGE = "Welcome to “Hangman” game.Please try to guess my secret word. \n" +
                "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to cheat and 'exit' to quit the game.";

            while (true)
            {
                Console.Write(WELCOME_MESSAGE);

                Word secretWord = new Word();

                int playerMistakes = 0;               
                                
                //start new game
                while (secretWord.MaskedWord.Contains('_'))
                {
                    Console.WriteLine("The secret word is " + secretWord.MaskedWord);

                    Console.Write("Enter your guess: ");

                    string command = Console.ReadLine();

                    if (command.Length == LETTER)
                    {
                        char letter = command[0];

                        if (secretWord.IsLetter(letter) && secretWord.ContainsLetter(letter))
                        {
                            secretWord.RevealLetterPosition(letter);

                            int numberOfOccurrences = secretWord.NumberOfLetterOccurrences(letter);
                            string comment = numberOfOccurrences == 1 ? " letter" : " letters";

                            Console.WriteLine("Good job! You revealed " + numberOfOccurrences + comment);
                        }
                        else
                        {
                            Console.WriteLine("Sorry! There are no unrevealed letters \'{0}\'", char.ToLower(letter));
                            playerMistakes++;
                        }
                    }
                    else
                    {
                        bool Restart = false;

                        switch (command)
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

        private static void ShowScoreboard()
        {
            Console.WriteLine("Scoreboard:");

            Console.WriteLine(Scoreboard.ScoreboardInstance.ToString());                
        }

        private static void GiveHint(Word secretWord)
        {
            char hintLetter = secretWord.MaskedWord[secretWord.MaskedWord.IndexOf('_') / 2];

            Console.WriteLine("OK, I reveal for you the next letter \'{0}\'", hintLetter);

			int firstMissingLetter = secretWord.MaskedWord.IndexOf('_');

			secretWord.RevealLetterPosition(secretWord.MaskedWord[firstMissingLetter / 2]);
            NotUseHelp = false;
        }
    }
}