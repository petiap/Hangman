namespace Hangman
{
    using System;
    using System.Linq;
    using System.Text;

    public class Word
    {
        private string secretWord;
        private StringBuilder maskedWord;

        public Word(string secretWord, StringBuilder maskedWord)
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

            set
            {
                this.secretWord = value;
            }
        }

        public StringBuilder MaskedWord
        {
            get
            {
                return this.maskedWord;
            }

            private set
            {
                this.maskedWord = value;
            }
        }

        public bool Isletter(char Theletter)
        {
            if (char.ToLower(Theletter) >= 'a' && char.ToLower(Theletter) <= 'z')
            {
                return true;
            }

            return false;
        }

        public bool CheckForLetter(char TheLetter)
        {
            if (secretWord.Contains(char.ToLower(TheLetter)))
            {
                return true;
            }
            
            return false;
        }

        public string WriteTheLetter(char TheLetter)
        {

            for (int WordLenght = 0; WordLenght < secretWord.Length - 1; WordLenght++)
            {
                if (this.secretWord.IndexOf(char.ToLower(TheLetter), WordLenght) >= 0)
                {
                    this.maskedWord[this.secretWord.IndexOf(char.ToLower(TheLetter), WordLenght) * 2] = TheLetter;
                }
            }

            return maskedWord.ToString();
        }

        public int NumberOfInput(char TheLetter)
        {
            int Number = 0;

            for (int WordLenght = 0; WordLenght < secretWord.Length; WordLenght++)
            {
                if (this.secretWord[WordLenght].Equals(char.ToLower(TheLetter)))
                    Number++;
            }

            return Number;
        }
    }
}