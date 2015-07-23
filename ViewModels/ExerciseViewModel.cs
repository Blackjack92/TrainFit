using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrainFit.Models;

namespace TrainFit.ViewModels
{
    public class ExerciseViewModel : ViewModel
    {
        #region fields
        private Exercise exercise;
        #endregion

        #region properties
        public INavigationService NavigationService { get; set; }
        public ICommand BackCommand { get; private set; }

        public Exercise Exercise { get { return exercise; } set { SetProperty(ref exercise, value); } }
        #endregion

        #region ctor
        public ExerciseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            BackCommand = new DelegateCommand(navigationService.GoBack);

            Exercise = new Exercise()
            {
                Name = "Test",
                Description = "Description",
                Difficulty = Difficulty.Easy,
                ImageSource = new Uri("https://www.google.at/"),
                Url = new Uri("https://www.google.at/")
            };
        }
        #endregion
    }
}
