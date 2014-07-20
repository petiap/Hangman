namespace HangmanTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Hangman;

    [TestClass]
    public class CommandInterpreterTests
    {
        [TestMethod]
        public void DecodeCommandTests()
        {
            Game game = new Game(new InitialState());

            game.Run();

            string testExampleWord = "computer";
            string testDecodeCommand = "help";

            CommandInterpreter.Decode(testDecodeCommand);

            // CommandInterpreter decodeCommandWord = new CommandInterpreter(testDecodeCommand);

            // var decodeCommand = CommandInterpreter.AssignGameDelegate(GetGameDelegate);
            // Assert.IsNotNull(decodeCommandWord);

            Assert.AreEqual(game.Word, testExampleWord);
        }
    }
}