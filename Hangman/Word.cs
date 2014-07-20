namespace Hangman
{
    using System;
    using System.Linq;
    using System.Text;

    public class Word
    {
        private string secretWord;
        private string maskedWord;

        public Word()
        {
            this.SecretWord = RandomWordGenerator.GenerateWord();
            this.MaskedWord = Mask(this.SecretWord);
        }

        // added for testing purposes only
        public Word(string secretWord, string maskedWord)
        {
            this.SecretWord = secretWord;
            this.MaskedWord = maskedWord;
        }

        public string SecretWord
        {
            get
            {
                return this.secretWord;
            }

            private set
            {
                decimal number;

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Value of word to guess is null or white space.");
                }

                if (decimal.TryParse(value, out number))
                {
                    throw new ArgumentOutOfRangeException("Value of word to guess is a number.");
                }

                this.secretWord = value;
            }
        }

        public string MaskedWord
        {
            get
            {
                return this.maskedWord;
            }

            set
            {
                decimal number;

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Value of printed word  is null or white space.");
                }

                if (decimal.TryParse(value, out number))
                {
                    throw new ArgumentOutOfRangeException("Value of printed word is a number.");
                }

                this.maskedWord = value;
            }
        }

        public static string Mask(string word)
        {
            var maskedWord = new StringBuilder(word.Length * 2);

            for (int i = 0; i < word.Length; i++)
            {
                maskedWord.Append("_ ");
            }

            return maskedWord.ToString();
        }

        // implement single responsibility
        public string RevealLetterPosition(char letter)
        {
            StringBuilder maskedWordBuilder = new StringBuilder(this.MaskedWord);
            char letterLowerCase = char.ToLower(letter);

            for (int wordLenght = 0; wordLenght < this.SecretWord.Length - 1; wordLenght++)
            {
                int letterIndex = this.SecretWord.IndexOf(letterLowerCase, wordLenght);

                if (letterIndex >= 0)
                {
                    maskedWordBuilder[letterIndex * 2] = letter;
                }
            }

            this.MaskedWord = maskedWordBuilder.ToString();

            return this.MaskedWord;
        }

        public int NumberOfLetterOccurrences(char letter)
        {
            int number = 0;
            letter = char.ToLower(letter);

            for (int wordLenght = 0; wordLenght < this.SecretWord.Length; wordLenght++)
            {
                if (this.SecretWord[wordLenght].Equals(letter))
                {
                    number++;
                }
            }

            return number;
        }
    }
}