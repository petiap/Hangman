namespace HangmanTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Hangman;

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
            string name = "New player";
            int topScore = 5;

            Player topPlayer = new Player(name, topScore);

            Assert.IsNotNull(topPlayer);
            Assert.AreEqual(name, topPlayer.Name);
            Assert.AreEqual(topScore, topPlayer.Score);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TopPlayerNameAsEmptyString()
        {
            string name = string.Empty;
            int topScore = 5;

            Player topPlayer = new Player(name, topScore);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TopPlayerNameAsWhitespace()
        {
            string name = " ";
            int topScore = 5;

            Player topPlayer = new Player(name, topScore);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TopPlayerScoreLessThanZero()
        {
            string name = "New player";
            int topScore = -1;

            Player topPlayer = new Player(name, topScore);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TopPlayerNameAsNumber()
        {
            string name = "4526.34561";
            int topScore = 5;

            Player topPlayer = new Player(name, topScore);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TopPlayerScoreIsMoreThanAllLettersInAlphabeth()
        {
            string name = "New player";
            int topScore = 30;

            Player topPlayer = new Player(name, topScore);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TopPlayerScoreAsEmptyString()
        {
            string name = "New player";

            Player topPlayer = new Player(name, int.Parse(string.Empty));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TopPlayerScoreAsNull()
        {
            string name = "New player";

            Player topPlayer = new Player(name, int.Parse(null));
        }
    }
}