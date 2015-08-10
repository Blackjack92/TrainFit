using Microsoft.Practices.Prism.Mvvm.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;
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
                if (selectedExercise != null)
                {
                    NavigationService.Navigate(Navigate.Exercise.PageName(), selectedExercise);
                }
            }
        }
        #endregion

        #region ctor
        public ExercisesViewModel(INavigationService navigationService, ImageService imageService) 
            : base(navigationService)
        {
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

            exercises.Add(new ExerciseDataModel(exercise1, imageService));
            exercises.Add(new ExerciseDataModel(exercise2, imageService));
            exercises.Add(new ExerciseDataModel(exercise3, imageService));
            exercises.Add(new ExerciseDataModel(exercise4, imageService));
        }
        #endregion

        #region methods
       
        #endregion
    }
}
