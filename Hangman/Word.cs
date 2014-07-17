namespace Hangman
{
    using System;
    using System.Linq;
    using System.Text;

    public class Word
    {
        private string playedWord;
        private StringBuilder printedWord;

        public Word(string playedWord, StringBuilder printedWord)
        {
            this.playedWord = playedWord;
            this.printedWord = printedWord;
        }

        public string PlayedWord
        {
            get
            {
                return this.playedWord;
            }

            set
            {
                this.playedWord = value;
            }
        }

        public string PrintedWord
        {
            get
            {
                return this.printedWord.ToString();
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
            if (playedWord.Contains(char.ToLower(TheLetter)))
            {
                return true;
            }
            
            return false;
        }

        public string WriteTheLetter(char TheLetter)
        {

            for (int WordLenght = 0; WordLenght < playedWord.Length - 1; WordLenght++)
            {
                if (this.playedWord.IndexOf(char.ToLower(TheLetter), WordLenght) >= 0)
                {
                    this.printedWord[this.playedWord.IndexOf(char.ToLower(TheLetter), WordLenght) * 2] = TheLetter;
                }
            }

            return printedWord.ToString();
        }

        public int NumberOfInput(char TheLetter)
        {
            int Number = 0;

            for (int WordLenght = 0; WordLenght < playedWord.Length; WordLenght++)
            {
                if (this.playedWord[WordLenght].Equals(char.ToLower(TheLetter)))
                    Number++;
            }

            return Number;
        }
    }
}