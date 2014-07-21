namespace Hangman
{
    using System;

    public static class RandomWordGenerator
    {
        private static readonly string[] WORDS = 
        { 
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

        private static Random randomWordGenerator;

        static RandomWordGenerator()
        {
            randomWordGenerator = new Random();
        }

        public static string GenerateWord()
        {
            string randomWord = WORDS[randomWordGenerator.Next(0, (WORDS.Length - 1))];

            return randomWord;
        }
    }
}