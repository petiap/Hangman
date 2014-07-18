namespace Hangman
{
    using System;
    using System.Linq;
    using System.Text;

    public class Word
    {
        public Word()
        {
            this.SecretWord = RandomWordGenerator.GenerateWord();
            this.MaskedWord = Word.Mask(this.SecretWord);
        }

        public string SecretWord { get; private set; }

        public string MaskedWord { get; private set; }

        public static string Mask(string word)
        {
            StringBuilder maskedWord = new StringBuilder(word.Length);

            for (int i = 0; i < word.Length; i++)
            {
                maskedWord.Append("_ ");
            }

            return maskedWord.ToString();
        }

        // make it static or move out of class
        public bool IsLetter(char symbol)
        {
            symbol = char.ToLower(symbol);

            if (symbol >= 'a' && symbol <= 'z')
            {
                return true;
            }

            return false;
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
            StringBuilder unmaskedWord = new StringBuilder(this.MaskedWord);
            char letterLowerCase = char.ToLower(letter);

            for (int wordLenght = 0; wordLenght < this.SecretWord.Length - 1; wordLenght++)
            {
                int letterIndex = this.SecretWord.IndexOf(letterLowerCase, wordLenght);

                if (letterIndex >= 0)
                {
                    unmaskedWord[letterIndex * 2] = letter;
                }
            }

            this.MaskedWord = unmaskedWord.ToString();

            return this.MaskedWord;
        }

        public int NumberOfLetterOccurrences(char letter)
        {
            int number = 0;
            letter = char.ToLower(letter);

            for (int wordLenght = 0; wordLenght < this.SecretWord.Length; wordLenght++)
            {
                if (this.SecretWord[wordLenght].Equals(letter))
                    number++;
            }

            return number;
        }
    }
}