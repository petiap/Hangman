namespace HangmanTest
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Hangman;

	[TestClass]
	public class CommandInterpreterTest
	{
		[TestMethod]
		public void CommandInterpreterDecodeHelpInput()
		{
			Game game = new Game(new InitialState());

			game.Word = new Word();

			CommandInterpreter.AssignGameDelegate(() => game);

			CommandInterpreter.Decode("help");
		}

		[TestMethod]
		public void CommandInterpreterDecodeRestartInput()
		{
			Game game = new Game(new InitialState());

			game.Word = new Word();

			CommandInterpreter.AssignGameDelegate(() => game);

			CommandInterpreter.Decode("restart");
		}

		[TestMethod]
		public void CommandInterpreterDecodeTopInput()
		{
			Game game = new Game(new InitialState());

			game.Word = new Word();

			CommandInterpreter.AssignGameDelegate(() => game);

			CommandInterpreter.Decode("top");
		}

		[TestMethod]
		public void CommandInterpreterDecodeInvalidInput()
		{
			Game game = new Game(new InitialState());

			game.Word = new Word();

			CommandInterpreter.AssignGameDelegate(() => game);

			CommandInterpreter.Decode("tophere");
		}

        [TestMethod]
        public void WordIsLetterAsLetter()
        {
            char letter = 't';

            bool isLetter = CommandInterpreter.IsValidLetter(letter);

            Assert.AreEqual(isLetter, true);
        }

        [TestMethod]
        public void WordIsLetterAsNonLetter()
        {
            char letter = '$';

            bool isLetter = CommandInterpreter.IsValidLetter(letter);

            Assert.AreEqual(isLetter, false);
        }
    }
}