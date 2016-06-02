using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UglyTrivia;

namespace Trivia
{
    public class GameRunner
    {

        private static bool notAWinner;

        public static void Main(String[] args)
        {
            Console.WriteLine("----------------- Bienvenue sur le jeu trivia -------------------");
            
            for (var i = 0; i < 10; i++)
            {
                var aGame = new Game();

                Console.WriteLine("Veuillez choisir le nombre point pour gagner !");
                int nbPurse = Convert.ToInt32(Console.ReadLine());
                aGame.setNbPurseToWin(nbPurse);

                aGame.add("Chet");
                aGame.add("Pat");
                aGame.add("Sue");

                Random rand = new Random(i);

                do
                {

                    aGame.roll(rand.Next(5) + 1);

                    if (rand.Next(9) == 7)
                    {
                        notAWinner = aGame.wrongAnswer();
                    }
                    else
                    {
                        notAWinner = aGame.wasCorrectlyAnswered();
                    }



                } while (notAWinner);
            }

        }


    }

}

