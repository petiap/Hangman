﻿namespace Hangman
{
    using System;

    public static class GameEngine
    {
        private static bool usedHelp = false;
        
        public static void GuessLetter(Game currentGame, char letter)
        {
            if (currentGame.Word.ContainsLetter(letter))
            {
                currentGame.Word.RevealLetterPosition(letter);

                int numberOfOccurrences = currentGame.Word.NumberOfLetterOccurrences(letter);
                string comment = numberOfOccurrences == 1 ? " letter" : " letters";

                Console.WriteLine("Good job! You revealed " + numberOfOccurrences + comment);
            }
            else
            {
                Console.WriteLine("Sorry! There are no unrevealed letters \"{0}\"", char.ToLower(letter));
                currentGame.NumberOfMistakes++;
            }
        }

        public static void GiveHint(Word secretWord)
        {
            int firstMissingLetter = secretWord.MaskedWord.IndexOf('_');
            char hintLetter = secretWord.SecretWord[firstMissingLetter / 2];

            Console.WriteLine("OK, I reveal for you the next letter \'{0}\'", hintLetter);

            secretWord.RevealLetterPosition(hintLetter);

            usedHelp = true;
        }

        public static void EstimateScore(Word secretWord, int numberOfMistakes)
        {
            bool isNewTopScore = Scoreboard.ScoreboardInstance.IsNewTopScore(numberOfMistakes);
            string comment = numberOfMistakes == 1 ? " mistake" : " mistakes";

            Console.WriteLine("The secret word is " + secretWord.MaskedWord);
            Console.Write("\nYou won with " + numberOfMistakes + comment);

            if (!usedHelp && isNewTopScore)
            {
                Console.Write("\nPlease enter your name for the top scoreboard: ");

                string newTopPlayerName = Console.ReadLine();
                Player newTopPlayer = new Player(newTopPlayerName, numberOfMistakes);

                Scoreboard.ScoreboardInstance.AddPlayer(newTopPlayer);

                ShowScoreboard();
            }
            else if (!isNewTopScore)
            {
                Console.Write(" but your result is lower than top scores\n");
            }
            else
            {
                Console.Write(" but you have cheated. You are not allowed to enter into the scoreboard.\n");
            }

            usedHelp = false;
        }

        public static void ShowScoreboard()
        {
            Console.WriteLine("Scoreboard:");

            Console.WriteLine(Scoreboard.ScoreboardInstance.ToString());
        }
    }
}