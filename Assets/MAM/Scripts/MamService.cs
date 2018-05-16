using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            // Initialization
            questionList = new List<Question>();
            conversation = new List<Question>();
            toAsk = new List<Ask>();
            qAnswered = new List<string>();
            rand = new Random();
            questionList = LoadQuestions();
            var topics = Enum.GetValues(typeof(Topics));
            toAsk.Add(new Ask(Topics.Greetings.ToString(), 1));
            // We get some random questions, with the data of the user and mother
            foreach (var item in topics)
            {
                if (!item.Equals(Topics.Greetings) && !item.Equals(Topics.Goodbyes))
                    toAsk.Add(new Ask(item.ToString(), rand.Next(1,4)));
            }
            toAsk.Add(new Ask(Topics.Goodbyes.ToString(), 1));
            // Mother goes crazy 1 out of 5 times
            if (rand.Next(0, 5) == 2)
                mamMadness = true;
            GenerateConversation(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 100));
        }

        private List<Question> LoadQuestions()
        {
            // Load questions from XML file
            var questions = new List<Question>();
            bool fileExist = File.Exists("Assets/MAM/Resources/questions.xml");
            Debug.WriteLine(fileExist ? "File exists." : "File does not exist.");
            if (fileExist)
            {
                questions = DeserializeObj<List<Question>>("Assets/MAM/Resources/questions.xml");
            }
            return questions;
        }

        // DeserializeObj is used to tranform xml data to the corresponding object
        private static T DeserializeObj<T>(string path)
        {
            var reader = new XmlSerializer(typeof(T));
            var file = new StreamReader(path);
            var obj = (T)reader.Deserialize(file);
            file.Close();
            return obj;
        }

        // Used to obtain the question from the mother
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

        // Used to generate the questions that the mother will ask
        private void GenerateConversation(int sociability, int inner_peace, int madness)
        {
            foreach (var item in toAsk)
            {
                var tagList =  ValueToTag(sociability, inner_peace, madness, mamHappyness, mamMadness);
                var query = QuestionContainsTopic(tagList, item.topic);
                // LINQ. We get the questions which contains the tag generated with the user and the mothers data
                conversation = conversation.Concat(query.OrderBy(x => rand.Next()).Take(item.times)).ToList();
            }
            numQuestions = conversation.Count();
        }

        // ValueToTag is used to transform the numeric values to the corresponding tags
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

        // Used to check if a question contains the selected topic
        private List<Question> QuestionContainsTopic(List<String> tags, string topic)
        {
            var qList = new List<Question>();
            tags.Add(topic);
            foreach (var item in questionList)
            {
                bool exist = tags.All(i => item.tags.Contains(i));
                if (exist)
                    qList.Add(item);
            }
            return qList;
        }
    }
}
