using Quizz.Data.Quizz.Data;
using Quizz.ViewModel;
using System.Windows;
using System.Windows.Controls;
    namespace Quizz.View
    {
        public partial class HistoryView : UserControl
        {
            public HistoryView()
            {
                InitializeComponent();   
            }
        private void ClearHistory_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment supprimer tout l'historique ?",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                using (var db = new QuizDbContext())
                {
                    db.Scores.RemoveRange(db.Scores);
                    db.SaveChanges();
                }

                // Recharge l'affichage
                DataContext = new HistoryViewModel();
            }
        }

    }
}

