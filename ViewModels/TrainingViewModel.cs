using Microsoft.Practices.Prism.Mvvm.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TrainFit.Models;
using Windows.UI.Xaml.Navigation;

namespace TrainFit.ViewModels
{
    public class TrainingViewModel : ExtendedViewModel
    {
        #region fields
        private ObservableCollection<Exercise> exercises;
        #endregion

        #region properties
        public ObservableCollection<Exercise> Exercises { get { return exercises; } set { SetProperty(ref exercises, value); } }
        #endregion

        #region ctor
        public TrainingViewModel(INavigationService navigationService) : base(navigationService)
        {
            // Properties
            exercises = new ObservableCollection<Exercise>();
        }
        #endregion

        #region methods
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
