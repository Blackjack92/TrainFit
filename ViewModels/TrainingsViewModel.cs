﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TrainFit.Models;
using TrainFit.Services;
using Windows.UI.Xaml.Navigation;

namespace TrainFit.ViewModels
{
    public class TrainingsViewModel : ExtendedViewModel
    {
        #region fields
        // TODO: implement an ObservableDatabaseCollection, this collection should automatically add, remove, update 
        private ObservableCollection<Exercise> exercises;
        private readonly IDatabaseService databaseService;
        #endregion

        #region properties
        public ObservableCollection<Exercise> Exercises { get { return exercises; } set { SetProperty(ref exercises, value); } }
        public ICommand AddExerciseCommand { get; private set; }
        public ICommand RemoveExerciseCommand { get; private set; }
        public ICommand StoreInDatabaseCommand { get; private set; }
        public ICommand LoadFromDatabaseCommand { get; private set; }
        #endregion

        #region ctor
        public TrainingsViewModel(INavigationService navigationService, IDatabaseService databaseService)
            : base(navigationService)
        {
            // Services
            this.databaseService = databaseService;

            // Properties
            exercises = new ObservableCollection<Exercise>();

            // Commands
            AddExerciseCommand = new DelegateCommand(AddExercise);
            RemoveExerciseCommand = new DelegateCommand(RemoveExercise);
            StoreInDatabaseCommand = new DelegateCommand(StoreInDatabase);
            LoadFromDatabaseCommand = new DelegateCommand(LoadFromDatabase);
        }
        #endregion

        #region methods
        private void AddExercise() 
        {
            var exercise = new Exercise();
            exercise.Difficulty = Difficulty.Easy;
            exercise.Name = "Einfache Übung";
            exercises.Add(exercise);
        }

        private void RemoveExercise()
        {
            if (exercises.Any())
            {
                var exercise = exercises.ElementAt(0);
                exercises.Remove(exercise);
                databaseService.DeleteFromDatabase(exercise);
                
            }
        }

        private void StoreInDatabase()
        {
            databaseService.InsertAllIntoDatabase(exercises);
        }

        private void LoadFromDatabase()
        {
            Exercises = databaseService.ReadListFromDatabase<Exercise>();
        }

        public override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);
            Exercises.Clear();

            var parameters = navigationParameter as IEnumerable<Exercise>;
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    Exercises.Add(parameter);
                }
            }
        }
        #endregion
    }
}
