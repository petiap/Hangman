namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Scoreboard
    {
        private const int NUMBER_OF_TOP_PLAYERS = 5;

        private static Scoreboard scoreboardInstance;

        private List<Player> topPlayers;

        private Scoreboard()
        {
            this.topPlayers = new List<Player>();
        }

        public static Scoreboard ScoreboardInstance
        {
            get
            {
                if (scoreboardInstance == null)
                {
                    scoreboardInstance = new Scoreboard();
                }

                return scoreboardInstance;
            }
        }

        public void AddPlayer(Player newPlayer)
        {
            this.topPlayers.Add(newPlayer);
        }

        public bool IsNewTopScore(double topScoreCandidate)
        {
            if (this.topPlayers.Count < NUMBER_OF_TOP_PLAYERS)
            {
                return true;
            }
            else
            {
                SortByHighestScore();

                int lastPosition = (NUMBER_OF_TOP_PLAYERS - 1);
                double lowestTopScore = this.topPlayers[lastPosition].Score;

                if (lowestTopScore < topScoreCandidate)
                {
                    return true;
                }

                return false;
            }
        }

        private void SortByHighestScore()
        {
            this.topPlayers = this.topPlayers.OrderBy(player => player.Score).ToList();
        }

        public override string ToString()
        {
            StringBuilder scoreboard = new StringBuilder();
            int count = this.topPlayers.Count;

            if (count == 0)
            {
                scoreboard.AppendLine("No entries in the scoreboard");
            }
            else
            {
                if (count >= NUMBER_OF_TOP_PLAYERS)
                {
                    count = NUMBER_OF_TOP_PLAYERS;
                }

                SortByHighestScore();

                for (int i = 0; i < count; i++)
                {
                    int position = i + 1;
                    string comment = this.topPlayers[i].Score == 1 ? "mistake" : "mistakes";

                    scoreboard.AppendLine(position + ". " + this.topPlayers[i].Name + " --> " + this.topPlayers[i].Score + " " + comment);
                }
            }

            return scoreboard.ToString();
        }
    }
}