using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrainFit.DataModels;
using TrainFit.Models;
using TrainFit.Services;

namespace TrainFit.ViewModels
{
    public class ExerciseViewModel : ViewModel
    {
        #region fields
        private ExerciseDataModel exercise;
        #endregion

        #region properties
        public INavigationService NavigationService { get; set; }
        public ICommand BackCommand { get; private set; }

        public ExerciseDataModel Exercise { get { return exercise; } set { SetProperty(ref exercise, value); } }
        #endregion

        #region ctor
        public ExerciseViewModel(INavigationService navigationService, ImageService imageService)
        {
            NavigationService = navigationService;
            BackCommand = new DelegateCommand(navigationService.GoBack);

            var exercise = new Exercise()
            {
                Name = "Test",
                Description = "Description",
                Difficulty = Difficulty.Easy,
                Url = "https://www.google.at/"
            };

            Exercise = new ExerciseDataModel(exercise, imageService);
        }
        #endregion
    }
}
