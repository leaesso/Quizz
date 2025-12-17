using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quizz.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private string _playerName = "";
        private string _selectedDifficulty = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public string PlayerName
        {
            get { return _playerName; }
            set
            {
                _playerName = value;
                OnPropertyChanged();
                StartQuizCommand.RaiseCanExecuteChanged();
            }
        }

        public string SelectedDifficulty
        {
            get { return _selectedDifficulty; }
            set
            {
                _selectedDifficulty = value;
                OnPropertyChanged();
                StartQuizCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<string> Difficulties { get; private set; }

        public RelayCommand StartQuizCommand { get; private set; }

        private readonly Action _startQuizAction;

        public HomeViewModel(Action startQuizAction, MainWindow main)
        {
            _startQuizAction = startQuizAction;

            Difficulties = new ObservableCollection<string>()
    {
        "Facile",
        "Moyen",
        "Difficile"
    };

            StartQuizCommand = new RelayCommand(
                p => StartQuiz(),
                p => CanStartQuiz()
            );
        }

        private bool CanStartQuiz()
        {
            return PlayerName.Trim() != "" && SelectedDifficulty.Trim() != "";
        }

        private void StartQuiz()
        {
            _startQuizAction();
        }


        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Difficulty => SelectedDifficulty;
    }
}
    
