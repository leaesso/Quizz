using Quizz.View;
using System.Windows;

namespace Quizz
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new HomeView(this);
        }


        public void NavigateToQuiz(string difficulty, string playerName)
        {
            MainContent.Content = new QuizView(this, difficulty, playerName);
        }

        public void NavigateToHistory()
        {
            MainContent.Content = new HistoryView();
        }


       
    }
}

