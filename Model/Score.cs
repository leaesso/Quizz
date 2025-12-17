using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Model
{
        public class Score
        {
            public string PlayerName { get; set; }
            public int ScoreValue { get; set; }
            public DateTime Date { get; set; }

            public Score(string playerName, int score)
            {
                PlayerName = playerName;
                ScoreValue = score;
                Date = DateTime.Now;
            }
        }
    }

