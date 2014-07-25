namespace Hangman
{
    using System;

    public static class RandomWordGenerator
    {
        private static readonly string[] Words = 
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
			string randomWord = Words[randomWordGenerator.Next(0, (Words.Length - 1))];

            return randomWord;
        }
    }
}