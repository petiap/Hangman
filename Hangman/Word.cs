using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Word
    {
        private string wordToGuess;
	    private StringBuilder printedWord;

		public Word(string theWordToGuess, StringBuilder theWord)
        {
			this.WordToGuess = theWordToGuess;
			this.PrintedWord = theWord;
        }

		public string WordToGuess
        {
			get { return this.wordToGuess; }
			private set { this.wordToGuess = value; }
        }

		public StringBuilder PrintedWord
        {
			get { return this.printedWord;}
			set { this.printedWord = value; }
        }

	    public bool Isletter(char theletter)
	    {
			if (char.ToLower(theletter) >= 'a' && char.ToLower(theletter) <= 'z')
		    {
			    return true;
		    }

		    return false;
        }

		public bool IsWordToGuessContainsLetter(char theLetter)
        {
			if (this.wordToGuess.Contains(char.ToLower(theLetter)))
			{
				return true;
			}

			return false;
        }

		public string WriteTheLetter(char theLetter)
        {

			for (int i = 0; i < this.wordToGuess.Length - 1; i++)
            {
				if (this.wordToGuess.IndexOf(char.ToLower(theLetter), i) >= 0)
                {
					this.printedWord[this.wordToGuess.IndexOf(char.ToLower(theLetter), i) * 2] = theLetter;
                }
            }

			return printedWord.ToString();
        }

        public int NumberOfInput(char theLetter)
        {
            int Number = 0;
			for (int i = 0; i < this.wordToGuess.Length; i++)
            {
				if (this.wordToGuess[i].Equals(char.ToLower(theLetter))) 
				{
					Number++;
				}
            }
            return Number;
        }
    }
}

