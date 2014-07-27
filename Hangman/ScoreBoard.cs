namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Scoreboard
    {
        private const int NumberOfTopPlayers = 5;

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

        public bool IsNewTopScore(int topScoreCandidate)
        {
			if (this.topPlayers.Count < NumberOfTopPlayers)
            {
                return true;
            }
            else
            {

                SortByHighestScore();

				int lastPosition = (NumberOfTopPlayers - 1);
                double lowestTopScore = this.topPlayers[lastPosition].Score;

                if (lowestTopScore > topScoreCandidate)
                {
                    return true;
                }

                return false;
            }
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
				if (count >= NumberOfTopPlayers)
                {
					count = NumberOfTopPlayers;
                }

                SortByHighestScore();

                for (int i = 0; i < count; i++)
                {
                    int position = i + 1;
                    string comment = this.topPlayers[i].Score == 1 ? "mistake" : "mistakes";

                    scoreboard.AppendLine(position + ". " + this.topPlayers[i].ToString() + " " + comment);
                }
            }

            return scoreboard.ToString();
        }

        private void SortByHighestScore()
        {
            this.topPlayers = this.topPlayers.OrderBy(player => player.Score).ToList();
        }
    }
}