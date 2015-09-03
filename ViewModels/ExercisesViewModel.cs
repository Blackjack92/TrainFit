using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using TrainFit.DataModels;
using TrainFit.Models;
using TrainFit.Services;
using TrainFit.Utils;

namespace TrainFit.ViewModels
{
    public class ExercisesViewModel : ExtendedViewModel
    {
        #region fields
        private ObservableCollection<ExerciseDataModel> exercises;
        private ExerciseDataModel selectedExercise;
        private bool isCreateTrainingEnabled;
        #endregion

        #region properties
        public ObservableCollection<ExerciseDataModel> Exercises
        {
            get { return exercises; }
            private set { SetProperty(ref exercises, value); }
        }

        public ExerciseDataModel SelectedExercise
        {
            get { return selectedExercise; }
            set
            {
                SetProperty(ref selectedExercise, value);

                if (!IsCreateTrainingEnabled && selectedExercise != null)
                {
                    NavigationService.Navigate(Navigate.Exercise.PageName(), selectedExercise);
                }
            }
        }

        public bool IsCreateTrainingEnabled { get { return isCreateTrainingEnabled; } set { SetProperty(ref isCreateTrainingEnabled, value); } }

        public DelegateCommand CreateTrainingCommand { get; private set; } 
        #endregion

        #region ctor
        public ExercisesViewModel(INavigationService navigationService, ImageService imageService) 
            : base(navigationService)
        {
            CreateTrainingCommand = new DelegateCommand(CreateTraining, CanCreateTraining);

            IsCreateTrainingEnabled = true;
            exercises = new ObservableCollection<ExerciseDataModel>();

            // TODO: Remove this test data
            var exercise1 = new Exercise()
            {
                Id = 1,
                Difficulty = Difficulty.Easy,
                Description = "Test description",
                ExerciseType = ExerciseType.Arm,
                Name = "Arm exercise",
                Url = "https://www.google.at/"
            };

            var exercise2 = new Exercise()
            {
                Id = 2,
                Difficulty = Difficulty.Normal,
                Description = "Test description",
                ExerciseType = ExerciseType.Leg,
                Name = "Leg exercise",
                Url = "https://www.google.at/"
            };

            var exercise3 = new Exercise()
            {
                Id = 3,
                Difficulty = Difficulty.SuperEasy,
                Description = "Test description",
                ExerciseType = ExerciseType.Abs,
                Name = "Abs exercise",
                Url = "https://www.google.at/"
            };

            var exercise4 = new Exercise()
            {
                Id = 4,
                Difficulty = Difficulty.Hard,
                Description = "Test description",
                ExerciseType = ExerciseType.Chest,
                Name = "Chest exercise",
                Url = "https://www.google.at/"
            };

            exercises.CollectionChanged += OnCollectionChanged;

            exercises.Add(new ExerciseDataModel(exercise1, imageService));
            exercises.Add(new ExerciseDataModel(exercise2, imageService));
            exercises.Add(new ExerciseDataModel(exercise3, imageService));
            exercises.Add(new ExerciseDataModel(exercise4, imageService));
        }
        #endregion

        #region methods
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Eventually find a better solution
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems.OfType<ExerciseDataModel>())
                {
                    item.PropertyChanged += OnIsCheckedChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.NewItems.OfType<ExerciseDataModel>())
                {
                    item.PropertyChanged -= OnIsCheckedChanged;
                }
            }
        }

        private void OnIsCheckedChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsChecked"))
            {
                UpdateCommands();
            }
        }

        private void UpdateCommands()
        {
            CreateTrainingCommand.RaiseCanExecuteChanged();
        }

        private bool CanCreateTraining()
        {
            return IsCreateTrainingEnabled && Exercises.Any(exercise => exercise.IsChecked);
        }

        private void CreateTraining()
        {
            NavigationService.Navigate(Navigate.Training.PageName(), exercises.Where(exercise => exercise.IsChecked).Select(exercise => exercise.Exercise));
        }
        #endregion
    }
}
