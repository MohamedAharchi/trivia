using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UglyTrivia;

namespace Trivia
{
    class Question
    {
        private Dictionary<string, QuestionStack> questionsByCategory = new Dictionary<string, QuestionStack>();

        public Question()
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

        public string getCategory(int place)
        {
            string category="Rock";
            if (place == 0 || place == 4 || place == 8) category = "Pop";
            else if (place == 1 || place == 5 || place == 9) category = "Science";
            else if (place == 2 || place == 6 || place == 10) category = "Sports";
            return category;
        }
    }
}
