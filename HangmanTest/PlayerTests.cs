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
            int testPlayerScore = 12345;
            Player testPlayer;

            testPlayer = new Player(testPlayerName, testPlayerScore);
            string referencePlayerName = testPlayer.Name;

            Assert.AreEqual(testPlayerName, referencePlayerName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerInstantiatedWithIncorrectNameThrowsException()
        {
            string testPlayerName = "";
            int testPlayerScore = 12345;
            Player testPlayer;

            testPlayer = new Player(testPlayerName, testPlayerScore);
        }

        [TestMethod]
        public void InstatniatePlayerWithCorrectScore()
        {
            string testPlayerName = "Rinswind";
            int testPlayerScore = 12345;
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
    }
}