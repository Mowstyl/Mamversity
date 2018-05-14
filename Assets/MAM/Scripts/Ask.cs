using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.MAM.Scripts
{
    public class Ask
    {
        public string topic;
        public int times;

        public Ask() { }

        public Ask(string topic, int times)
        {
            this.topic = topic;
            this.times = times;
        }
    }
}
