using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    class Players
    {
        private List<Player> lesPlayers = new List<Player>();
        private int currentPlayer;
        public Players()
        {
            currentPlayer = 0;
        }

        public void add(Player unPlayer)
        {
            this.lesPlayers.Add(unPlayer);
        }

        public int count()
        {
            return this.lesPlayers.Count();
        }

        public Player current()
        {
            return lesPlayers[currentPlayer];
        }

        public void nextPlayer()
        {
            this.currentPlayer++;
        }

        public int getIndexCurrent()
        {
            return currentPlayer;
        }

        public void reinitIndexCurrent()
        {
            this.currentPlayer = 0;
        }
    }
}
