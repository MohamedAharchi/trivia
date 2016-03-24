using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    class Player
    {
        private string name;

        public Player(string aName)
        {
            this.name = aName;
        }

        public string Name
        {
            get { return name; }
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
