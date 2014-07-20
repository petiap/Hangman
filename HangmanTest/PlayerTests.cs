namespace HangmanTest
{
    using System;
    using Hangman;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void InstantiatePlayerWithCorrectName()
        {
            string testPlayerName = "Rinswind";
            int testPlayerScore = 27;
            Player testPlayer;

            testPlayer = new Player(testPlayerName, testPlayerScore);
            string referencePlayerName = testPlayer.Name;

            Assert.AreEqual(testPlayerName, referencePlayerName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerInstantiatedWithIncorrectNameThrowsException()
        {
            string testPlayerName = string.Empty;
            int testPlayerScore = 27;
            Player testPlayer;

            testPlayer = new Player(testPlayerName, testPlayerScore);
        }

        [TestMethod]
        public void InstatniatePlayerWithCorrectScore()
        {
            string testPlayerName = "Rinswind";
            int testPlayerScore = 27;
            Player testPlayer;

            testPlayer = new Player(testPlayerName, testPlayerScore);
            int referencePlayerScore = testPlayer.Score;

            Assert.AreEqual(testPlayerScore, referencePlayerScore);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlayerInstantiatedWithIncorrectNegativeScoreThrowsException()
        {
            string testPlayerName = "Rinswind";
            int testPlayerScore = -1234;
            Player testPlayer;

            testPlayer = new Player(testPlayerName, testPlayerScore);
        }

		public void TopPlayerCreation()
		{
			string name = "New guy";
			int score = 5;

			Player topPlayer = new Player(name, score);

			Assert.IsNotNull(topPlayer);
			Assert.AreEqual(name, topPlayer.Name);
			Assert.AreEqual(score, topPlayer.Score);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TopPlayerNameAsWhitespace()
		{
			string name = " ";
			int score = 6;

			Player topPlayer = new Player(name, score);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TopPlayerNameAsEmptyString()
		{
            string name = string.Empty;
			int score = 5;

			Player topPlayer = new Player(name, score);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TopPlayerNameAsNumber()
		{
			string name = "213432.34532";
			int score = 9;

			Player topPlayer = new Player(name, score);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TopPlayerScoreLessThanZero()
		{
			string name = "New Guy";
			int score = -1;

			Player topPlayer = new Player(name, score);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TopPlayerScoreIsMoreThanAllLettersInAlphabeth()
		{
			string name = "New Guy";
			int score = 30;

			Player topPlayer = new Player(name, score);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TopPlayerScoreAsNull()
		{
			string name = "New Guy";

			Player topPlayer = new Player(name, int.Parse(null));
		}

		[TestMethod]
		[ExpectedException(typeof(FormatException))]
		public void TopPlayerScoreAsEmptyString()
		{
			string name = "New Guy";

			Player topPlayer = new Player(name, int.Parse(string.Empty));
		}
    }
}