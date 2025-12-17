using Quizz.ViewModel;

using System.Windows;
using System.Windows.Controls;


namespace Quizz.View
{
    public partial class QuizView : UserControl
    {
        private MainWindow _main;

        public QuizView()
        {
            InitializeComponent();
        }

        
            public QuizView(MainWindow main, string difficulty, string playerName)
            {
                InitializeComponent();
                _main = main;

                // ON PASSE LES 3 PARAMÈTRES
                DataContext = new QuizViewModel(
                    difficulty,
                    playerName,
                    () => _main.NavigateToHistory()
                );
            }
        


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as QuizViewModel;
            if (vm == null) return;

            string selected = (sender as RadioButton)?.Content.ToString();
            if (selected == null) return;

            int index = vm.CurrentQuestion.Choices.IndexOf(selected);
            vm.SelectedAnswerIndex = index;
        }

    }
}
