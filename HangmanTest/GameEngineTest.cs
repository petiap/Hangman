namespace HangmanTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Hangman;

    [TestClass]
    public class GameEngineTest
    {
        [TestMethod]
        public void GameEngineContainsLetter()
        {
            char letter = 'd';

            Game game = new Game(new InitialState());

			game.Run();

            GameEngine.GuessLetter(game, letter);
        }

        [TestMethod]
        public void GameEngineNotContainsLetter()
        {
            char letter = 'q';

            Game game = new Game(new InitialState());

			game.Run();

            GameEngine.GuessLetter(game, letter);
        }

        [TestMethod]
        public void TheLetterAsNumber()
        {
            char letter = '7';

            Game game = new Game(new InitialState());

			game.Run();

            GameEngine.GuessLetter(game, letter);
        }

        [TestMethod]
        public void TheLetterAsSomeChar()
        {
            char letter = '%';

            Game game = new Game(new InitialState());

			game.Run();

            GameEngine.GuessLetter(game, letter);
        }

        [TestMethod]
        public void GameEngineIsLetterAsLetter()
        {
            char letter = 't';

            Game game = new Game(new InitialState());

			game.Run();

            GameEngine.GuessLetter(game, letter);
        }

        [TestMethod]
        public void WordIsLetterAsNonLetter()
        {
            char letter = '$';

            Game game = new Game(new InitialState());

			game.Run();

            GameEngine.GuessLetter(game, letter);
        }

        [TestMethod]
        public void GameState()
        {
            char letter = '$';

            Game game = new Game(new InitialState());

			game.Run();

            GameEngine.GuessLetter(game, letter);
        }

        [TestMethod]
        public void GameEngineGiveHintTest()
        {
            Word word = new Word();

            GameEngine.GiveHint(word);
        }

        [TestMethod]
        public void GameEngineEstimateScoreTest()
        {
			int mistakes = 1;
            Word word = new Word();

			GameEngine.EstimateScore(word, mistakes);
        }

		//[TestMethod]
		//public void GameEngineEstimateScoreWithNewScoreboardTest()
		//{
		//	int mistakes = 1;
		//	Word word = new Word();

		//	GameEngine.EstimateScore(word, mistakes);
		//}

        [TestMethod]
        public void GameEngineEstimateScoreWithHelpTest()
        {
			int mistakes = 1;
            Word word = new Word();

            GameEngine.GiveHint(word);
			GameEngine.EstimateScore(word, mistakes);
        }

        [TestMethod]
        public void GameEngineShowScoreboardTest()
        {
            GameEngine.ShowScoreboard();
        }    
    }
}