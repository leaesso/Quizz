using System.Collections.Generic;


namespace Quizz.Models
{
    public class Question
    {
        public string Text { get; set; }
        public List<string> Choices { get; set; }
        public int CorrectIndex { get; set; }

        public Question(string text, List<string> choices, int correctIndex)
        {
            Text = text;
            Choices = choices;
            CorrectIndex = correctIndex;
        }
    }
}


