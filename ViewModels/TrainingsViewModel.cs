using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainFit.Models;

namespace TrainFit.ViewModels
{
    public class TrainingsViewModel : ExtendedViewModel
    {
        #region fields
        private ObservableCollection<Exercise> exercises;
        #endregion

        #region properties
        public ObservableCollection<Exercise> Exercises { get { return exercises; } }
        #endregion

        #region ctor
        public TrainingsViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            exercises = new ObservableCollection<Exercise>();

            // TODO: fill with real data
            var exercise = new Exercise();
            exercise.Difficulty = Difficulty.Easy;
            exercise.Name = "Einfache Übung";
            exercises.Add(exercise);
            exercise = new Exercise();
            exercise.Difficulty = Difficulty.Normal;
            exercise.Name = "Normale Übung";
            exercises.Add(exercise);
            exercise = new Exercise();
            exercise.Difficulty = Difficulty.Hard;
            exercise.Name = "Schwere Übung";
            exercises.Add(exercise);
            exercise = new Exercise();
            exercise.Difficulty = Difficulty.Easy;
            exercise.Name = "Einfache Übung";
            exercises.Add(exercise);
            exercise = new Exercise();
            exercise.Difficulty = Difficulty.Normal;
            exercise.Name = "Normale Übung";
            exercises.Add(exercise);
            exercise = new Exercise();
            exercise.Difficulty = Difficulty.Hard;
            exercise.Name = "Harte Übung";
            exercises.Add(exercise);
        }
        #endregion
    }
}
