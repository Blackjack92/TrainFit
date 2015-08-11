using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using System.Collections.Generic;
using System.Windows.Input;
using TrainFit.DataModels;
using TrainFit.Models;
using TrainFit.Services;
using Windows.UI.Xaml.Navigation;

namespace TrainFit.ViewModels
{
    public class ExerciseViewModel : ExtendedViewModel
    {
        #region fields
        private ExerciseDataModel exercise;
        #endregion

        #region properties
        public ICommand BackCommand { get; private set; }

        public ExerciseDataModel Exercise { get { return exercise; } set { SetProperty(ref exercise, value); } }
        #endregion

        #region ctor
        public ExerciseViewModel(INavigationService navigationService, ImageService imageService) :
            base(navigationService)
        {
            BackCommand = new DelegateCommand(navigationService.GoBack);
        }
        #endregion

        #region methods
        public override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);

            Exercise = navigationParameter as ExerciseDataModel;
        }
        #endregion
    }
}
