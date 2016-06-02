using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trivia;

namespace UglyTrivia
{
    public class Game
    {
        private readonly int nbPursesToWin = 6;
        private readonly List<Player> lesPlayers = new List<Player>();
        private readonly Questions _questionsGlobal = new Questions();

        int currentPlayer = 0;
        bool isGettingOutOfPenaltyBox;

        public Game(int nbPurse)
        {
            _questionsGlobal.addCategory("Pop");
            _questionsGlobal.addCategory("Science");
            _questionsGlobal.addCategory("Sports");
            _questionsGlobal.addCategory("Rock");
            nbPursesToWin = nbPurse;
        }

        public Game()
        {
            _questionsGlobal.addCategory("Pop");
            _questionsGlobal.addCategory("Science");
            _questionsGlobal.addCategory("Sports");
            _questionsGlobal.addCategory("Rock");
        }

        public bool isPlayable()
        {
            return (howManyPlayers() >= 2);
        }

        public bool add(String playerName)
        {

            var unPlayer = new Player(playerName);
            lesPlayers.Add(unPlayer);

            Console.WriteLine(unPlayer.Name + " was added");
            Console.WriteLine("They are player number " + lesPlayers.Count);
            return true;
        }

        public int howManyPlayers()
        {
            return lesPlayers.Count;
        }

        public void roll(int roll)
        {
            Console.WriteLine(lesPlayers[currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (lesPlayers[currentPlayer].InPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(lesPlayers[currentPlayer] + " is getting out of the penalty box");
                    lesPlayers[currentPlayer].updatePlace(roll);

                    Console.WriteLine(lesPlayers[currentPlayer]
                            + "'s new location is "
                            + lesPlayers[currentPlayer].Place);
                    Console.WriteLine("The category is " + currentCategory());
                    _questionsGlobal.askQuestion(currentCategory());
                }
                else
                {
                    Console.WriteLine(lesPlayers[currentPlayer] + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {
                lesPlayers[currentPlayer].updatePlace(roll);

                Console.WriteLine(lesPlayers[currentPlayer]
                        + "'s new location is "
                        + lesPlayers[currentPlayer].Place);
                Console.WriteLine("The category is " + currentCategory());
                _questionsGlobal.askQuestion(currentCategory());
            }

        }


        private String currentCategory()
        {
            var place = lesPlayers[currentPlayer].Place;
            string category = "Rock";
            if (place % 4 == 0) category = "Pop";
            else if (place % 4 == 1) category = "Science";
            else if (place % 4 == 2) category = "Sports";
            return category;
        }

        public bool wasCorrectlyAnswered()
        {
            if (lesPlayers[currentPlayer].InPenaltyBox)
            {
                if (isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    lesPlayers[currentPlayer].winOnePurse();
                    Console.WriteLine(lesPlayers[currentPlayer]
                            + " now has "
                            + lesPlayers[currentPlayer].Purse
                            + " Gold Coins.");
                    bool winner = didPlayerWin();
                    currentPlayer++;
                    if (currentPlayer == lesPlayers.Count) currentPlayer = 0;

                    return winner;
                }
                else
                {
                    currentPlayer++;
                    if (currentPlayer == lesPlayers.Count) currentPlayer = 0;
                    return true;
                }



            }
            else
            {

                Console.WriteLine("Answer was corrent!!!!");
                lesPlayers[currentPlayer].winOnePurse();
                Console.WriteLine(lesPlayers[currentPlayer]
                        + " now has "
                        + lesPlayers[currentPlayer].Purse
                        + " Gold Coins.");

                bool winner = didPlayerWin();
                currentPlayer++;
                if (currentPlayer == lesPlayers.Count) currentPlayer = 0;

                return winner;
            }
        }

        public bool wrongAnswer()
        {
            Console.WriteLine("Questions was incorrectly answered");
            Console.WriteLine(lesPlayers[currentPlayer] + " was sent to the penalty box");
            lesPlayers[currentPlayer].goInPenaltyBox();

            currentPlayer++;
            if (currentPlayer == lesPlayers.Count) currentPlayer = 0;
            return true;
        }


        private bool didPlayerWin()
        {
            return !(lesPlayers[currentPlayer].Purse == nbPursesToWin);
        }
    }
}
