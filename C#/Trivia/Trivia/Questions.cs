using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class Questions
    {
        private List<string> categories;
        private Dictionary<string, QuestionStack> questionsByCategory = new Dictionary<string, QuestionStack>();

        public Questions()
        {
            questionsByCategory["Pop"] = new QuestionStack("Pop");
            questionsByCategory["Science"] = new QuestionStack("Science");
            questionsByCategory["Sports"] = new QuestionStack("Sports");
            questionsByCategory["Rock"] = new QuestionStack("Rock");
        }
        
        public Questions(IEnumerable<string> categories )
        {
            foreach (var category in categories)
            {
                questionsByCategory[category] = new QuestionStack(category);
            }
        }

        public void addCategory(string category)
        {
            questionsByCategory[category] = new QuestionStack(category);
        }

        public void askQuestion(string category)
        {
            questionsByCategory[category].askQuestion();
        }

        public string currentCategory(int place)
        {
            int nbQt = questionsByCategory.Count;
            return questionsByCategory.Keys.ToList()[place%nbQt];
        }
    }
}
