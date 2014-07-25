namespace HangmanTest
{
    using System;
    using Hangman;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
	
    [TestClass]
    public class WordTests
    {
        [TestMethod]
		public void WordCreation()
		{
			Word word = new Word();

			Assert.IsNotNull(word);
		}

		[TestMethod]
		public void WordContainsLetter()
		{
			char letter = 'x';

            Word word = new Word();

			bool hasLetter = word.ContainsLetter(letter);

            Assert.AreEqual(hasLetter, false, "This letter isn't included in the word");
		}

		[TestMethod]
		public void WordNotContainsLetter()
		{
			char letter = 'h';

            Word word = new Word();

			bool hasLetter = word.ContainsLetter(letter);

			Assert.IsNotNull(hasLetter);
		}
        
		[TestMethod]
		public void TheLetterAsNumber()
		{
			char letter = '1';

            Word word = new Word();

			bool hasLetter = word.ContainsLetter(letter);

            Assert.AreEqual(hasLetter, false, "The word can't contain a number!");
		}

		[TestMethod]
		public void TheLetterAsSomeChar()
		{
			char letter = '%';

            Word word = new Word();

			bool hasLetter = word.ContainsLetter(letter);

			Assert.AreEqual(hasLetter, false, "The word can't contain a char!");
		}

		

		[TestMethod]
		public void WordIndexOfLetter()
		{
			char letter = 't';

            Word word = new Word();

			int letterIndex = word.NumberOfLetterOccurrences(letter);

			Assert.IsNotNull(letterIndex);
		}

		[TestMethod]
		public void WordIsLetterAsNonLetter()
		{
			char letter = '$';

			bool isLetter = CommandInterpreter.IsValidLetter(letter);

			Assert.AreEqual(isLetter, false, "The word can contain only a letters!");
		}

	    [TestMethod]
	    public void WordWriteTheLetterInHiddenWord()
	    {
		    char letter = 't';

            Word word = new Word();

			string writhedLetter = word.RevealLetterPosition(letter);

		    Assert.IsNotNull(writhedLetter);
	    }

		[TestMethod]
		public void WordIsLetterAsLetter()
		{
			char letter = 't';

            bool isLetter = CommandInterpreter.IsValidLetter(letter);

			Assert.AreEqual(isLetter, true, "This letter isn't included in the word");
		}
    }
}