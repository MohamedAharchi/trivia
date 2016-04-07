using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UglyTrivia;

namespace Trivia
{
    class Questions
    {
        private Dictionary<string, QuestionStack> questionsByCategory = new Dictionary<string, QuestionStack>();

        public Questions()
        {
        }

        public void addCategory(string category)
        {
            questionsByCategory[category] = new QuestionStack(category);
        }

        public void askQuestion(string category)
        {
            questionsByCategory[category].askQuestion();
        }
    }
}
