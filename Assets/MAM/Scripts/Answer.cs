using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.MAM.Scripts
{
    [Serializable]
    public class Answer
    {
        public string text;
        public int reward;

        public Answer() { }

        public Answer(string text, int reward)
        {
            this.text = text;
            this.reward = reward;
        }
    }
}
