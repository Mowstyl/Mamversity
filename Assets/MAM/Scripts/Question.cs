using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.MAM.Scripts
{
    [Serializable]
    public class Question
    {
        public string questionID;
        public string text;
        public List<string> tags;
        public List<Answer> answers;

        public Question() { }

        public Question(string questionID, string text, List<Answer> answers, List<string> tags)
        {
            this.questionID = questionID;
            this.text = text;
            this.answers = answers;
            this.tags = tags;
        }
    }
}
