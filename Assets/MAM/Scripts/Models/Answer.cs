namespace Models
{
    public class Answer
    {
        public string text;
        public Question question;

        public Answer(string text, Question question)
        {
            this.text = text;
            this.question = question;
        }
    }
}