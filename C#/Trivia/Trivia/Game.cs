using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trivia;

namespace UglyTrivia
{
    public class Game
    {


        List<Player> lesPlayers = new List<Player>();

        /*Dictionary<string, QuestionStack> questionsByCategory = new Dictionary<string, QuestionStack>();*/
        Question questionGlobal = new Question();

        int currentPlayer = 0;
        bool isGettingOutOfPenaltyBox;

        public Game()
        {
            questionGlobal.addCategory("Pop");
            questionGlobal.addCategory("Science");
            questionGlobal.addCategory("Sports");
            questionGlobal.addCategory("Rock");
            /*questionsByCategory["Pop"] = new QuestionStack("Pop");
            questionsByCategory["Science"] = new QuestionStack("Science");
            questionsByCategory["Sports"] = new QuestionStack("Sports");
            questionsByCategory["Rock"] = new QuestionStack("Rock");*/
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
                    askQuestion();
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
                askQuestion();
            }

        }

        private void askQuestion()
        {
            questionGlobal.askQuestion(currentCategory());
            /*questionsByCategory[currentCategory()].askQuestion();*/
        }


        private String currentCategory()
        {
            if (lesPlayers[currentPlayer].Place == 0) return "Pop";
            if (lesPlayers[currentPlayer].Place == 4) return "Pop";
            if (lesPlayers[currentPlayer].Place == 8) return "Pop";
            if (lesPlayers[currentPlayer].Place == 1) return "Science";
            if (lesPlayers[currentPlayer].Place == 5) return "Science";
            if (lesPlayers[currentPlayer].Place == 9) return "Science";
            if (lesPlayers[currentPlayer].Place == 2) return "Sports";
            if (lesPlayers[currentPlayer].Place == 6) return "Sports";
            if (lesPlayers[currentPlayer].Place == 10) return "Sports";
            return "Rock";
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
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(lesPlayers[currentPlayer] + " was sent to the penalty box");
            lesPlayers[currentPlayer].goInPenaltyBox();

            currentPlayer++;
            if (currentPlayer == lesPlayers.Count) currentPlayer = 0;
            return true;
        }


        private bool didPlayerWin()
        {
            return !(lesPlayers[currentPlayer].Purse == 6);
        }
    }
}
