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

            GameEngine.GuessLetter(game, letter);
        }

        [TestMethod]
        public void GameEngineNotContainsLetter()
        {
            char letter = 'q';

            Game game = new Game(new InitialState());

            GameEngine.GuessLetter(game, letter);
        }

        [TestMethod]
        public void TheLetterAsNumber()
        {
            char letter = '7';

            Game game = new Game(new InitialState());

            GameEngine.GuessLetter(game, letter);
        }

        [TestMethod]
        public void TheLetterAsSomeChar()
        {
            char letter = '%';

            Game game = new Game(new InitialState());

            GameEngine.GuessLetter(game, letter);
        }

        [TestMethod]
        public void GameEngineIsLetterAsLetter()
        {
            char letter = 't';

            Game game = new Game(new InitialState());

            GameEngine.GuessLetter(game, letter); ;
        }

        [TestMethod]
        public void WordIsLetterAsNonLetter()
        {
            char letter = '$';

            Game game = new Game(new InitialState());

            GameEngine.GuessLetter(game, letter);
        }

        [TestMethod]
        public void GameState()
        {
            char letter = '$';

            Game game = new Game(new InitialState());

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
            Word word = new Word();

            GameEngine.EstimateScore(word, 1);
        }

        [TestMethod]
        public void GameEngineEstimateScoreWithHelpTest()
        {
            Word word = new Word();

            GameEngine.GiveHint(word);
            GameEngine.EstimateScore(word, 1);
        }

        [TestMethod]
        public void GameEngineShowScoreboardTest()
        {
            GameEngine.ShowScoreboard();
        }    
    }
}