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

        public string SecretWord
        {
            get
            {
                return this.secretWord;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("SecretWord", "Value can't be null or empty string");
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("MaskedWord", "Value can't be null or empty string");
                }

                this.maskedWord = value;
            }
        }
        
        public bool ContainsLetter(char letter)
        {
            letter = char.ToLower(letter);

            if (this.SecretWord.Contains(letter))
            {
                return true;
            }

            return false;
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

        private string Mask(string word)
        {
            var maskedWord = new StringBuilder(word.Length * 2);

            for (int i = 0; i < word.Length; i++)
            {
                maskedWord.Append("_ ");
            }

            return maskedWord.ToString();
        }
    }
}