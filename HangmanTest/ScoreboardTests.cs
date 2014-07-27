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
			var scoreboardMock = Scoreboard.ScoreboardInstance;
            //var scoreboardMock = new Mock<Scoreboard>();

			Assert.IsNotNull(scoreboardMock);
        }

		[TestMethod]
		public void VerifyScoreboardToStringWorksWithoutAnyElements()
		{
			var scoreboardMock = Scoreboard.ScoreboardInstance;

			var scoreboard = scoreboardMock.ToString();

			Assert.AreEqual("No entries in the scoreboard\r\n", scoreboard);
		}

        [TestMethod]
        public void VerifyThatAddPlayerWorksCorrectly()
        {
            string testPlayerName = "Rinswind";
            int testPlayerScore = 29;
            Player testPlayer = new Player(testPlayerName, testPlayerScore);
			var scoreboardMock = Scoreboard.ScoreboardInstance;

			scoreboardMock.AddPlayer(testPlayer);

            var scoreboard = scoreboardMock.ToString();

			Assert.AreEqual("1. "+testPlayer + " mistakes\r\n", scoreboard);
        }

		//if run all tests this one fails
		//if run alone passes ?!?!?!?
		[TestMethod]
		public void VerifyScoreboardToStringWorks()
		{
			Player testPlayer1 = new Player("Rinswind", 7);
			Player testPlayer2 = new Player("Rinswinda", 4);
			Player testPlayer3 = new Player("Pencho", 19);
			Player testPlayer4 = new Player("Muncho", 10);
			Player testPlayer5 = new Player("Pesho", 23);
			var scoreboardMock = Scoreboard.ScoreboardInstance;

			scoreboardMock.AddPlayer(testPlayer1);
			scoreboardMock.AddPlayer(testPlayer2);
			scoreboardMock.AddPlayer(testPlayer3);
			scoreboardMock.AddPlayer(testPlayer4);
			scoreboardMock.AddPlayer(testPlayer5);

			var scoreboard = scoreboardMock.ToString();

			Assert.AreEqual("1. Rinswinda --> 4 mistakes\r\n2. Rinswind --> 7 mistakes\r\n3. Muncho --> 10 mistakes\r\n4. Pencho --> 19 mistakes\r\n5. Pesho --> 23 mistakes\r\n", scoreboard);
		}

		[TestMethod]
		public void VerifyScoreboardIsNewTopScoreWorksAsTrue()
		{
			Player testPlayer1 = new Player("Rinswind", 7);
			Player testPlayer2 = new Player("Rinswinda", 4);
			Player testPlayer3 = new Player("Pencho", 19);
			Player testPlayer4 = new Player("Muncho", 10);
			Player testPlayer5 = new Player("Pesho", 23);
			var scoreboardMock = Scoreboard.ScoreboardInstance;

			scoreboardMock.AddPlayer(testPlayer1);
			scoreboardMock.AddPlayer(testPlayer2);
			scoreboardMock.AddPlayer(testPlayer3);
			scoreboardMock.AddPlayer(testPlayer4);
			scoreboardMock.AddPlayer(testPlayer5);

			var check = scoreboardMock.IsNewTopScore(testPlayer5.Score);

			Assert.AreEqual(check, false);
		}

		[TestMethod]
		public void VerifyScoreboardIsNewTopScoreWorksAsFalse()
		{
			Player testPlayer1 = new Player("Rinswind", 7);
			Player testPlayer2 = new Player("Rinswinda", 4);
			Player testPlayer3 = new Player("Pencho", 19);
			Player testPlayer4 = new Player("Muncho", 10);
			Player testPlayer5 = new Player("Pesho", 23);
			var scoreboardMock = Scoreboard.ScoreboardInstance;

			scoreboardMock.AddPlayer(testPlayer1);
			scoreboardMock.AddPlayer(testPlayer2);
			scoreboardMock.AddPlayer(testPlayer3);
			scoreboardMock.AddPlayer(testPlayer4);
			scoreboardMock.AddPlayer(testPlayer5);

			var check = scoreboardMock.IsNewTopScore(testPlayer2.Score);

			Assert.AreEqual(check, true);
		}
    }
}