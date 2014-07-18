namespace HangmanTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Hangman;

    [TestClass]
    public class WordTests
    {
        [TestMethod]
		public void WordCreation()
		{
			string inputWord = "string";
			string strBuild = "stringBuilder";

			Word word = new Word(inputWord, strBuild);

			Assert.IsNotNull(word);
			Assert.AreEqual(inputWord, word.SecretWord);
			Assert.AreEqual(strBuild,word.MaskedWord);
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
			string inputWord = "string";
			string strBuild = "stringBuilder";
			char letter = 't';

			Word word = new Word(inputWord, strBuild);

			bool hasLetter = word.ContainsLetter(letter);

			Assert.AreEqual(hasLetter, true);
		}

		[TestMethod]
		public void WordNotContainsLetter()
		{
			string inputWord = "string";
			string strBuild = "stringBuilder";
			char letter = 'h';

			Word word = new Word(inputWord, strBuild);

			bool hasLetter = word.ContainsLetter(letter);

			Assert.AreEqual(hasLetter, false);
		}

		[TestMethod]
		public void TheLetterAsNumber()
		{
			string inputWord = "string";
			string strBuild = "stringBuilder";
			char letter = '1';

			Word word = new Word(inputWord, strBuild);

			bool hasLetter = word.ContainsLetter(letter);

			Assert.AreEqual(hasLetter, false);
		}

		[TestMethod]
		public void TheLetterAsSomeChar()
		{
			string inputWord = "string";
			string strBuild = "stringBuilder";
			char letter = '%';

			Word word = new Word(inputWord, strBuild);

			bool hasLetter = word.ContainsLetter(letter);

			Assert.AreEqual(hasLetter,false);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void WordNumberAsInputForWordToGuess()
		{
			string inputWord = "11";
			string strBuild = "dfhc";

			Word word = new Word(inputWord, strBuild);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void WordNumberAsInputForWordToPrint()
		{
			string inputWord = "sdfh";
			string strBuild = "11";

			Word word = new Word(inputWord, strBuild);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void InputForWordToGuessAsWhitespace()
		{
			string inputWord = " ";
			string strBuild = "dfhc";

			Word word = new Word(inputWord, strBuild);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void InputForWordToPrintAsWhitespace()
		{
			string inputWord = "sdfh";
			string strBuild = " ";

			Word word = new Word(inputWord, strBuild);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void InputForWordToGuessAsEmptyString()
		{
			string inputWord = "";
			string strBuild = "dfhc";

			Word word = new Word(inputWord, strBuild);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void InputForWordToPrintAsEmptyString()
		{
			string inputWord = "sdfh";
			string strBuild = "";

			Word word = new Word(inputWord, strBuild);
		}

		[TestMethod]
		public void WordIndexOfLetter()
		{
			string inputWord = "string";
			string strBuild = "stringBuilder";
			char letter = 't';

			Word word = new Word(inputWord, strBuild);

			int letterIndex = word.NumberOfLetterOccurrences(letter);

			Assert.AreEqual(letterIndex, 1);
		}

	    [TestMethod]
	    public void WordWriteTheLetterInHiddenWord()
	    {
		    string inputWord = "string";
		    string strBuild = "_ _ _ _ _ _";
		    char letter = 't';

		    Word word = new Word(inputWord, strBuild);

			string writhedLetter = word.RevealLetterPosition(letter);

		    Assert.AreEqual("_ t _ _ _ _", writhedLetter);
		    Assert.AreEqual(inputWord, word.SecretWord);
	    }

		[TestMethod]
		public void WordIsLetterAsLetter()
		{
			char letter = 't';

			Word word = new Word();

			bool isLetter = word.IsLetter(letter);

			Assert.AreEqual(isLetter, true);
		}

		[TestMethod]
		public void WordIsLetterAsNonLetter()
		{
			char letter = '$';
			Word word = new Word();

			bool isLetter = word.IsLetter(letter);

			Assert.AreEqual(isLetter, false);
		}
    }
}