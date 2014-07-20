namespace HangmanTest
{
    using System;
    using Hangman;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
	[TestClass]
	public class GameTest
	{
		[TestMethod]
		public void GameCreationTest()
		{
			Game game = new Game(new InitialState());

			Assert.IsNotNull(game);
			Assert.AreEqual(game.Mistakes, 0);
			Assert.IsNotNull(game.State);
			Assert.IsNull(game.Word);
		}

		[TestMethod]
		public void GameAddWordTest()
		{
			Game game = new Game(new InitialState());

			game.Word = new Word();

			Assert.IsNotNull(game.Word);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void GameMistakeAsLessThanZero()
		{
			Game game = new Game(new InitialState());

			game.Mistakes = -1;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void GameMistakeAsMoreThanAlowed()
		{
			Game game = new Game(new InitialState());

			game.Mistakes = 29;
		}

		[TestMethod]
		public void GameRunTest()
		{
			Game game = new Game(new InitialState());

			game.Run();
        }
	}
}
