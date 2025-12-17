using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Model
{
        public class ScoreEntry
        {
            public int Id { get; set; }
            public string PlayerName { get; set; }
            public string Difficulty { get; set; }
            public int Score { get; set; }
        public int TotalQuestions { get; set; }

        public DateTime PlayedOn { get; set; }

        public string DisplayScore => $"{Score}/{TotalQuestions}";
        }
}


