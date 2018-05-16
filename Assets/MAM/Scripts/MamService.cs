using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace Assets.MAM.Scripts
{
    public class MamService
    {
        private Random rand;
        private List<string> qAnswered;
        private List<Question> conversation;
        private bool mamMadness = false;
        private int mamHappyness = 100;
        private List<Ask> toAsk;
        public enum Topics { Greetings, Health, Sociability, Study, Goodbyes};
        public int numQuestions = 0;

        private List<Question> questionList;

        public MamService()
        {
            questionList = new List<Question>();
            conversation = new List<Question>();
            toAsk = new List<Ask>();
            qAnswered = new List<string>();
            rand = new Random();
            questionList = LoadQuestions();
            var topics = Enum.GetValues(typeof(Topics));
            toAsk.Add(new Ask(Topics.Greetings.ToString(), 1));
            foreach (var item in topics)
            {
                if (!item.Equals(Topics.Greetings) && !item.Equals(Topics.Goodbyes))
                {
                    toAsk.Add(new Ask(item.ToString(), rand.Next(1,4)));
                }
            }
            toAsk.Add(new Ask(Topics.Goodbyes.ToString(), 1));
            if (rand.Next(0, 5) == 2)
                mamMadness = true;
            GenerateConversation(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 100));
        }

        private List<Question> LoadQuestions()
        {
            var questions = new List<Question>();
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"questions.xml");
            //string[] files = File.ReadAllLines(path);
            bool fileExist = File.Exists("Assets/MAM/Resources/questions.xml");
            Debug.WriteLine(fileExist ? "File exists." : "File does not exist.");
            if (fileExist)
            {
                questions = DeserializeObj<List<Question>>("Assets/MAM/Resources/questions.xml");
            }
            return questions;
        }

        private static T DeserializeObj<T>(string path)
        {
            var reader = new XmlSerializer(typeof(T));
            var file = new StreamReader(path);
            var obj = (T)reader.Deserialize(file);
            file.Close();
            return obj;
        }

        public Question GetQuestion()
        {
            if (conversation.Count == 0)
                return null;
            else
            {
                var q = new Question();
                q = conversation.FirstOrDefault();
                conversation.Remove(conversation.FirstOrDefault());
                return q;
            }
        }

        private void GenerateConversation(int sociability, int inner_peace, int madness)
        {
            foreach (var item in toAsk)
            {
                var tagList =  ValueToTag(sociability, inner_peace, madness, mamHappyness, mamMadness);
                var query = QuestionContainsTopic(tagList, item.topic);
                conversation = conversation.Concat(query.OrderBy(x => rand.Next()).Take(item.times)).ToList();
            }
            numQuestions = conversation.Count();
        }

        private List<string> ValueToTag(int sociability, int inner_peace, int madness, int mamHappyness, bool mamMadness)
        {
            if (mamMadness)
            {
                return new List<string>(new string[] { "MamMadness" });
            }
            else
            {
                var tags = new List<string>();

                if (sociability >= 0 && sociability < 40)
                {
                    tags.Add("LowSociability");
                }
                else
                {
                    tags.Add("SociabilityOK");
                }
                
                if (inner_peace >= 0 && inner_peace < 40)
                {
                    tags.Add("LowInnerPeace");
                }
                else
                {
                    tags.Add("InnerPeaceOK");
                }

                if (madness >= 0 && madness < 40)
                {
                    tags.Add("MadUser");
                }
                else
                {
                    tags.Add("UserOK");
                }

                if (mamHappyness >= 0 && mamHappyness < 33)
                {
                    tags.Add("MamMadness");
                }
                else if (mamHappyness >= 33 && mamHappyness < 66)
                {
                    tags.Add("MamSuspicious");
                }
                else
                {
                    tags.Add("MamHappy");
                }                

                return tags;

            }

            
        }

        private List<Question> QuestionContainsTopic(List<String> tags, string topic)
        {
            var qList = new List<Question>();
            tags.Add(topic);
            foreach (var item in questionList)
            {
                bool exist = tags.All(i => item.tags.Contains(i));
                if (exist)
                {
                    qList.Add(item);
                }
            }
            return qList;
        }
    }
}
