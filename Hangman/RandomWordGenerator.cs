namespace Hangman
{
    using System;

    public static class RandomWordGenerator
    {
        private static readonly string[] words = 
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

        private readonly static Random randomWordGenerator;

        static RandomWordGenerator()
        {
            randomWordGenerator = new Random();
        }

        public static string GenerateWord()
        {
			string randomWord = words[randomWordGenerator.Next(0, (words.Length - 1))];

            return randomWord;
        }
    }
}