using System;
using System.Collections.Generic;
using System.Linq;

namespace UglyTrivia
{
    internal class QuestionStack
    {
        private LinkedList<string> questions = new LinkedList<string>();

        public QuestionStack(string category)
        {
            for (int i = 0; i < 50; i++)
            {
                questions.AddLast(category + " Questions " + i);
            }
        }

        public void askQuestion()
        {
            Console.WriteLine(questions.First());
            questions.RemoveFirst();
        }
    }
}