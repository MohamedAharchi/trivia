using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    class Player
    {
        private string name;

        public string getName()
        {
            return this.name;
        }

        public void setName(string aName)
        {
            this.name = aName;
        }
    }
}
