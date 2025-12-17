using System.Windows;
using System.Windows.Controls;



namespace Quizz.View
{
    public partial class HomeView : UserControl
    {
        private MainWindow _main;

        public HomeView(MainWindow main)
        {
            InitializeComponent();
            _main = main;
        }

        private void Easy_Click(object sender, RoutedEventArgs e)
        {
            string playerName = PlayerNameTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                MessageBox.Show("Veuillez entrer votre nom !");
                return;
            }

            _main.NavigateToQuiz("Facile", playerName);
        }


        private void Medium_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string playerName = PlayerNameTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                MessageBox.Show("Veuillez entrer votre nom !");
                return;
            }

            _main.NavigateToQuiz("Moyen", playerName);
        }

        

        private void Hard_Click(object sender, System.Windows.RoutedEventArgs e)
        {
                string playerName = PlayerNameTextBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(playerName))
                {
                    MessageBox.Show("Veuillez entrer votre nom !");
                    return;
                }

                _main.NavigateToQuiz("Difficile", playerName);
            }

        

        private void History_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _main.NavigateToHistory();
        }
    }
}
