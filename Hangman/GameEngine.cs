namespace Hangman
{
    using System;

    public static class GameEngine
    {
        private static bool notUseHelp = true;

        public static void GuessLetter(Word secretWord, char letter, int numberOfMistakes)
        {
            if (secretWord.IsLetter(letter) && secretWord.ContainsLetter(letter))
            {
                secretWord.RevealLetterPosition(letter);

                int numberOfOccurrences = secretWord.NumberOfLetterOccurrences(letter);
                string comment = numberOfOccurrences == 1 ? " letter" : " letters";

                Console.WriteLine("Good job! You revealed " + numberOfOccurrences + comment);
            }
            else
            {
                Console.WriteLine("Sorry! There are no unrevealed letters \"{0}\"", char.ToLower(letter));
                numberOfMistakes++;
            }
        }

        public static void GiveHint(Word secretWord)
        {
            int firstMissingLetter = secretWord.MaskedWord.IndexOf('_');
            char hintLetter = secretWord.SecretWord[firstMissingLetter / 2];

            Console.WriteLine("OK, I reveal for you the next letter \'{0}\'", hintLetter);

            secretWord.RevealLetterPosition(hintLetter);

            notUseHelp = false;
        }

        public static void EstimateScore(Word secretWord, int numberOfMistakes)
        {
            bool isNewTopScore = Scoreboard.ScoreboardInstance.IsNewTopScore(numberOfMistakes);
            string comment = numberOfMistakes == 1 ? " mistake" : " mistakes";

            Console.WriteLine("The secret word is " + secretWord.MaskedWord);
            Console.Write("\nYou won with " + numberOfMistakes + comment);

            if (notUseHelp && isNewTopScore)
            {
                Console.Write("\nPlease enter your name for the top scoreboard: ");

                string newTopPlayerName = Console.ReadLine();
                Player newTopPlayer = new Player(newTopPlayerName, numberOfMistakes);

                Scoreboard.ScoreboardInstance.AddPlayer(newTopPlayer);

                GameEngine.ShowScoreboard();
            }
            else if (!isNewTopScore)
            {
                Console.Write(" but your result is lower than top scores\n");
            }
            else
            {
                Console.Write(" but you have cheated. You are not allowed to enter into the scoreboard.\n");
            }

            notUseHelp = true;
        }

        public static void ShowScoreboard()
        {
            Console.WriteLine("Scoreboard:");

            Console.WriteLine(Scoreboard.ScoreboardInstance.ToString());
        }
    }
}