namespace HangmanTest
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Hangman;
	[TestClass]
	public class GameTest
	{
		[TestMethod]
		public void GameCreationTest()
		{
			Game game = new Game(new InitialState());

			Assert.IsNotNull(game);
			Assert.AreEqual(game.Mistakes, 0);
			//Assert.AreEqual(game.State, );
		}
	}
}
