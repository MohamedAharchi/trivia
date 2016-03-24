using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    class Player
    {
        private string name;
        private int place;
        private int purse;
        private bool inPenaltyBox;

        public Player(string aName)
        {
            this.name = aName;
            this.place = 0;
            this.purse = 0;
            this.inPenaltyBox = false;
        }

        public string Name
        {
            get { return name; }
        }

        public int Place
        {
            get { return place; }
            set { place = value; }
        }

        public int Purse
        {
            get { return purse; }
            set { purse = value; }
        }

        public bool InPenaltyBox
        {
            get { return inPenaltyBox; }
            set { inPenaltyBox = value; }
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
