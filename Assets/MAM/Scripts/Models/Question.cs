using System.Collections.Generic;

namespace Models
{
    public class Question
    {
        public string text;
        public List<Answer> answers;

        public Question(string text, List<Answer> answers)
        {
            this.text = text;
            this.answers = answers;
        }
    }
}