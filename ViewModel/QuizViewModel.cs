using Quizz.Data;
using Quizz.Data.Quizz.Data;
using Quizz.Model;
using Quizz.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Quizz.ViewModel
{
    public class QuizViewModel : INotifyPropertyChanged
    {
        private int _score = 0;
        public event PropertyChangedEventHandler PropertyChanged;

        private int _currentIndex = 0;
        private int _selectedAnswerIndex = -1;
        private int _scoreCounter = 0;

        public string PlayerName { get; set; }
        private readonly Action _navigateToHistory;
        public ObservableCollection<Question> Questions { get; set; }
        public string Difficulty { get; set; }

        public string BackgroundColor
        {
            get
            {
                switch (Difficulty)
                {
                    case "Facile":
                        return "#FFF9C4";    // jaune clair
                    case "Moyen":
                        return "#BBDEFB";    // bleu clair
                    case "Difficile":
                        return "#FFCDD2";    // rouge clair
                    default:
                        return "White";
                }
            }
        }

        public Question CurrentQuestion => Questions[_currentIndex];

        public int SelectedAnswerIndex
        {
            get => _selectedAnswerIndex;
            set
            {
                _selectedAnswerIndex = value;
                OnPropertyChanged();
            }
        }

        public ICommand ValidateCommand { get; private set; }
        public QuizViewModel(string difficulty, string playerName, Action navigateToHistory)
        {
            Difficulty = difficulty;
            PlayerName = playerName;          
            _navigateToHistory = navigateToHistory;  

            LoadQuestions();                 
           
        Questions = new ObservableCollection<Question>(GetQuestionsForDifficulty(difficulty));

            ValidateCommand = new RelayCommand(p => ValidateAnswer());
        }

        // ============================
        //      LISTE DES QUESTIONS
        // ============================
        private void LoadQuestions()
        { }
        private List<Question> GetQuestionsForDifficulty(string difficulty)
        {
            if (difficulty == "Facile")
            {
                return new List<Question>
                {
                    new Question("1) Quelle est la capitale de la France ?",
                        new List<string>{"Paris","Rome","Berlin","Madrid"}, 0),

                    new Question("2) Combien font 3 + 2 ?",
                        new List<string>{"4","5","6","3"}, 1),

                    new Question("3) Quel est le plus grand animal ?",
                        new List<string>{"Éléphant","Girafe","Baleine bleue","Tigre"}, 2),

                    new Question("4) Quelle est la couleur du ciel ?",
                        new List<string>{"Bleu","Rouge","Vert","Jaune"}, 0),

                    new Question("5) Quelle est la langue officielle en France ?",
                        new List<string>{"Français","Anglais","Espagnol","Allemand"}, 0)
                };
            }

            if (difficulty == "Moyen")
            {
                return new List<Question>
                {
                    new Question("1) Quel est le symbole chimique de l'eau ?", new List<string>{"H2O","O2","CO2","H2"}, 0),
                    new Question("2) Quel pays a inventé le papier ?", new List<string>{"Chine","Japon","Egypte","Inde"}, 0),
                    new Question("3) Combien font 12 × 3 ?", new List<string>{"36","24","30","48"}, 0),
                    new Question("4) Qui a peint la Joconde ?", new List<string>{"Van Gogh","Léonard de Vinci","Monet","Picasso"}, 1),
                    new Question("5) Quel est le plus long fleuve du monde ?", new List<string>{"Nil","Amazon","Yangtsé","Mississippi"}, 1),
                    new Question("6) Quelle est la planète la plus proche du Soleil ?", new List<string>{"Terre","Mars","Mercure","Vénus"}, 2),
                    new Question("7) Quel est l’os le plus long du corps humain ?", new List<string>{"Fémur","Tibia","Humérus","Côte"}, 0),
                    new Question("8) Quelle est la capitale de l’Australie ?", new List<string>{"Sydney","Melbourne","Canberra","Perth"}, 2),
                    new Question("9) Qui a découvert l'Amérique ?", new List<string>{"Magellan","Colomb","Marco Polo","Newton"}, 1),
                    new Question("10) Combien font 64 / 8 ?", new List<string>{"6","7","8","9"}, 2)
                };
            }

            if (difficulty == "Difficile")
            {
                return new List<Question>
                {
                    new Question("1) Racine carrée de 256 ?", new List<string>{"14","15","16","18"}, 2),
                    new Question("2) Théorie de la relativité ?", new List<string>{"Einstein","Newton","Tesla","Galilée"}, 0),
                    new Question("3) Auteur de '1984' ?", new List<string>{"Orwell","Tolstoï","Huxley","Kafka"}, 0),
                    new Question("4) Organe principal de la digestion ?", new List<string>{"Foie","Estomac","Intestin","Pancréas"}, 1),
                    new Question("5) Vitesse de la lumière ?", new List<string>{"300 000 km/s","150 000 km/s","1 million km/s","10 000 km/s"}, 0),
                    new Question("6) Capitale du Kazakhstan ?", new List<string>{"Astana","Almaty","Bakou","Tachkent"}, 0),
                    new Question("7) Début de la Première Guerre mondiale ?", new List<string>{"1912","1914","1918","1920"}, 1),
                    new Question("8) Métal liquide à température ambiante ?", new List<string>{"Mercure","Fer","Cuivre","Plomb"}, 0),
                    new Question("9) Nombre d'os adulte ?", new List<string>{"206","201","208","199"}, 0),
                    new Question("10) Plus petit nombre premier ?", new List<string>{"0","1","2","3"}, 2),
                    new Question("11) Formule énergie cinétique ?", new List<string>{"E=mc²","1/2mv²","UI","F=ma"}, 1),
                    new Question("12) Pays avec plus de volcans actifs ?", new List<string>{"Japon","Islande","Indonésie","Italie"}, 2),
                    new Question("13) Capitale Mongolie ?", new List<string>{"Astana","Ulaanbaatar","Hanoï","Katmandou"}, 1),
                    new Question("14) Découvreur de la pénicilline ?", new List<string>{"Pasteur","Fleming","Darwin","Curie"}, 1),
                    new Question("15) Nombre d’éléments du tableau périodique ?", new List<string>{"92","118","104","126"}, 1)
                };
            }

            return new List<Question>();
        }
        

        // ============================
        //        VALIDATION
        // ============================
        private void ValidateAnswer()
        {
            if (SelectedAnswerIndex == -1)
            {
                MessageBox.Show("Veuillez choisir une réponse !");
                return;
            }

            if (SelectedAnswerIndex == CurrentQuestion.CorrectIndex)
            {
                MessageBox.Show("Bonne réponse !");
                _scoreCounter++;
            }

            else
                MessageBox.Show("Mauvaise réponse !");

            SelectedAnswerIndex = -1;

            if (_currentIndex < Questions.Count - 1)
            {
                _currentIndex++;
                OnPropertyChanged(nameof(CurrentQuestion));
            }
            else
            {
                SaveScore();
                _navigateToHistory?.Invoke();
            }

        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private void SaveScore()
        {

            using (var db = new QuizDbContext())
            {
                db.Scores.Add(new ScoreEntry
                {
                    PlayerName = PlayerName,
                    Difficulty = Difficulty,
                    Score = _scoreCounter,
                    TotalQuestions = Questions.Count,
                    PlayedOn = DateTime.Now
                });

                db.SaveChanges();
            }
        }



    }
}