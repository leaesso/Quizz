using Quizz.Data;
using Quizz.Data.Quizz.Data;
using Quizz.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace Quizz.ViewModel
{
    public class HistoryViewModel
    {
        public ObservableCollection<ScoreEntry> Scores { get; set; }

        public HistoryViewModel()
        {
            using (var db = new QuizDbContext())
            {
                Scores = new ObservableCollection<ScoreEntry>(
                    db.Scores
                      .OrderByDescending(s => s.PlayedOn)
                      .ToList()
                );
            }
        }
    }
}
