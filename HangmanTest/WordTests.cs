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
			string inputWord = "string";
			string strBuild = "stringBuilder";

			Word word = new Word();

			Assert.IsNotNull(word);
			Assert.AreEqual(inputWord, word.SecretWord, "Wrong word!");
			Assert.AreEqual(strBuild, word.MaskedWord);
		}

		[TestMethod]
		public void WordEmptyCreation()
		{
			Word word = new Word();

			Assert.IsNotNull(word);
		}

		[TestMethod]
		public void WordContainsLetter()
		{
			char letter = 't';

            Word word = new Word();

			bool hasLetter = word.ContainsLetter(letter);

            Assert.AreEqual(hasLetter, true, "This letter isn't included in the word");
		}

		[TestMethod]
		public void WordNotContainsLetter()
		{
			char letter = 'h';

            Word word = new Word();

			bool hasLetter = word.ContainsLetter(letter);

			Assert.AreEqual(hasLetter, false);
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

	/*	[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void WordNumberAsInputForWordToGuess()
		{
			string inputWord = "11";
			string strBuild = "dfhc";

            Word word = new Word();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void WordNumberAsInputForWordToPrint()
		{
			string inputWord = "sdfh";
			string strBuild = "11";

            Word word = new Word(); ;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void InputForWordToGuessAsWhitespace()
		{
			string inputWord = " ";
			string strBuild = "dfhc";

            Word word = new Word();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void InputForWordToPrintAsWhitespace()
		{
			string inputWord = "sdfh";
			string strBuild = " ";

            Word word = new Word();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void InputForWordToGuessAsEmptyString()
		{
			string inputWord = string.Empty;
			string strBuild = "dfhc";

            Word word = new Word();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void InputForWordToPrintAsEmptyString()
		{
			string inputWord = "sdfh";
			string strBuild = string.Empty;

            Word word = new Word();
		}
        */
		[TestMethod]
		public void WordIndexOfLetter()
		{
			char letter = 't';

            Word word = new Word();

			int letterIndex = word.NumberOfLetterOccurrences(letter);

			Assert.AreEqual(letterIndex, 1, "Wrong number of appropriate letters");
		}

	    [TestMethod]
	    public void WordWriteTheLetterInHiddenWord()
	    {
		    string inputWord = "string";
		    char letter = 't';

            Word word = new Word();

			string writhedLetter = word.RevealLetterPosition(letter);

		    Assert.AreEqual("_ t _ _ _ _", writhedLetter, "This letter isn't included in the word!");
		    Assert.AreEqual(inputWord, word.SecretWord, "Wrong word!");
	    }

		[TestMethod]
		public void WordIsLetterAsLetter()
		{
			char letter = 't';

            bool isLetter = CommandInterpreter.IsValidLetter(letter);

			Assert.AreEqual(isLetter, true, "This letter isn't included in the word");
		}

		[TestMethod]
		public void WordIsLetterAsNonLetter()
		{
			char letter = '$';

            bool isLetter = CommandInterpreter.IsValidLetter(letter);

			Assert.AreEqual(isLetter, false, "The word can contain only a letters!");
		}
    }
}