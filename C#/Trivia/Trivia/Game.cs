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

        /*int[] places = new int[6];*/
        int[] purses = new int[6];

        bool[] inPenaltyBox = new bool[6];

        LinkedList<string> popQuestions = new LinkedList<string>();
        LinkedList<string> scienceQuestions = new LinkedList<string>();
        LinkedList<string> sportsQuestions = new LinkedList<string>();
        LinkedList<string> rockQuestions = new LinkedList<string>();

        int currentPlayer = 0;
        bool isGettingOutOfPenaltyBox;

        public Game()
        {
            for (int i = 0; i < 50; i++)
            {
                popQuestions.AddLast("Pop Question " + i);
                scienceQuestions.AddLast(("Science Question " + i));
                sportsQuestions.AddLast(("Sports Question " + i));
                rockQuestions.AddLast(createRockQuestion(i));
            }
        }

        public String createRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public bool isPlayable()
        {
            return (howManyPlayers() >= 2);
        }

        public bool add(String playerName)
        {

            var unPlayer = new Player(playerName);
            lesPlayers.Add(unPlayer);
            /*places[howManyPlayers()] = 0;*/
            purses[howManyPlayers()] = 0;
            inPenaltyBox[howManyPlayers()] = false;
            
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

            if (inPenaltyBox[currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(lesPlayers[currentPlayer] + " is getting out of the penalty box");
                    lesPlayers[currentPlayer].Place = lesPlayers[currentPlayer].Place + roll;
                    //places[currentPlayer] = places[currentPlayer] + roll;
                    if (lesPlayers[currentPlayer].Place > 11) lesPlayers[currentPlayer].Place = lesPlayers[currentPlayer].Place - 12;
                    //if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

                    Console.WriteLine(lesPlayers[currentPlayer]
                            + "'s new location is "
                            + lesPlayers[currentPlayer].Place);
                            //+ places[currentPlayer]);
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

                /*places[currentPlayer] = places[currentPlayer] + roll;
                if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;*/
                lesPlayers[currentPlayer].Place = lesPlayers[currentPlayer].Place + roll;
                if (lesPlayers[currentPlayer].Place > 11) lesPlayers[currentPlayer].Place = lesPlayers[currentPlayer].Place - 12;

                Console.WriteLine(lesPlayers[currentPlayer]
                        + "'s new location is "
                        + lesPlayers[currentPlayer].Place);
                        //+ places[currentPlayer]);
                Console.WriteLine("The category is " + currentCategory());
                askQuestion();
            }

        }

        private void askQuestion()
        {
            if (currentCategory() == "Pop")
            {
                Console.WriteLine(popQuestions.First());
                popQuestions.RemoveFirst();
            }
            if (currentCategory() == "Science")
            {
                Console.WriteLine(scienceQuestions.First());
                scienceQuestions.RemoveFirst();
            }
            if (currentCategory() == "Sports")
            {
                Console.WriteLine(sportsQuestions.First());
                sportsQuestions.RemoveFirst();
            }
            if (currentCategory() == "Rock")
            {
                Console.WriteLine(rockQuestions.First());
                rockQuestions.RemoveFirst();
            }
        }


        private String currentCategory()
        {
            /*if (places[currentPlayer] == 0) return "Pop";
            if (places[currentPlayer] == 4) return "Pop";
            if (places[currentPlayer] == 8) return "Pop";
            if (places[currentPlayer] == 1) return "Science";
            if (places[currentPlayer] == 5) return "Science";
            if (places[currentPlayer] == 9) return "Science";
            if (places[currentPlayer] == 2) return "Sports";
            if (places[currentPlayer] == 6) return "Sports";
            if (places[currentPlayer] == 10) return "Sports";*/
            if(lesPlayers[currentPlayer].Place == 0) return "Pop";
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
            if (inPenaltyBox[currentPlayer])
            {
                if (isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    purses[currentPlayer]++;
                    Console.WriteLine(lesPlayers[currentPlayer]
                            + " now has "
                            + purses[currentPlayer]
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
                purses[currentPlayer]++;
                Console.WriteLine(lesPlayers[currentPlayer]
                        + " now has "
                        + purses[currentPlayer]
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
            inPenaltyBox[currentPlayer] = true;

            currentPlayer++;
            if (currentPlayer == lesPlayers.Count) currentPlayer = 0;
            return true;
        }


        private bool didPlayerWin()
        {
            return !(purses[currentPlayer] == 6);
        }
    }

}
