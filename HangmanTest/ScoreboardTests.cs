namespace HangmanTest
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Hangman;
    using Moq;

    [TestClass]
    public class ScoreboardTests
    {
        [TestMethod]
        public void VerifySCoreboardSingletonInstanceIsCorrect()
        {
            var scoreboardMock = new Mock<Scoreboard>();
        }

        [TestMethod]
        public void VerifyThatAddPlayerWorksCorrectly()
        {
            string testPlayerName = "Rinswind";
            int testPlayerScore = 12345;
            Player testPlayer = new Player(testPlayerName, testPlayerScore);

            Scoreboard.ScoreboardInstance.AddPlayer(testPlayer);

            PrivateObject po = new PrivateObject(typeof(Scoreboard));
            var players = (List<Player>)po.GetField("topPlayers");
            Player referencePlayer = players[0];

            Assert.AreEqual(testPlayer, referencePlayer);
        }
    }
}