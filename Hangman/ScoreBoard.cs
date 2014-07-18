namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Scoreboard
    {
        private const int TopPlayersCount = 5;

        private static Scoreboard scoreboardInstance;

        private List<Player> topPlayers;

        private Scoreboard()
        {
			this.topPlayers = new List<Player>();
        }

		//singelton probubly!?
        public static Scoreboard ScoreboardInstance
        {
            get { return scoreboardInstance ?? (scoreboardInstance = new Scoreboard()); }
        }

        public void AddPlayer(Player newPlayer)
        {
			if (topPlayers.Count==0)
	        {
		         this.topPlayers.Add(newPlayer);
	        }
			else if (topPlayers.Count < TopPlayersCount)
			{
				this.topPlayers.Add(newPlayer);
				SortByHighestScore();
			}
			else
			{
				if (newPlayer.Score > topPlayers[TopPlayersCount-1].Score)
				{
					//replace the last and resort
					this.topPlayers[TopPlayersCount-1] = newPlayer;
					SortByHighestScore();
				}
			}
        }

		// score return fixed Test also
		public List<Player> GetScoreboard()
	    {
		    return this.topPlayers;
	    }

        // proububly not needed any more
		// proububly private all sorting and adding to TopPlayers in AddPlayer method
		public bool IsNewTopScore(double topScoreCandidate)
		{
			if (this.topPlayers.Count < TopPlayersCount)
			{
				return true;
			}
			else
			{
				SortByHighestScore();

				int lastPosition = (TopPlayersCount - 1);
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
            this.topPlayers = this.topPlayers.OrderByDescending(player => player.Score).ToList();
        }

        public override string ToString()
        {
            StringBuilder scoreboard = new StringBuilder();

			if (this.topPlayers.Count == 0)
            {
                scoreboard.AppendLine("No entries in the scoreboard");
            }
            else
            {
                for (int i = 0; i < this.topPlayers.Count; i++)
                {
                    int position = i + 1;

                    scoreboard.AppendLine(position + ". " + this.topPlayers[i].ToString());
                }
            }

            return scoreboard.ToString();
        }
    }
}