namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class RandomWordGenerator
    {
        private static readonly string[] words = { 
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

        public static string RandomWord { get; private set; }

        public static string GenerateWord()
        {
            RandomWord = words[randomWordGenerator.Next(0, (words.Length - 1))];

            return RandomWord;
        }
    }
}