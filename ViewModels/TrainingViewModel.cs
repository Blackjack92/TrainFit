using Microsoft.Practices.Prism.Mvvm.Interfaces;

namespace TrainFit.ViewModels
{
    public class TrainingViewModel : ExtendedViewModel
    {
        #region ctor
        protected TrainingViewModel(INavigationService navigationService) : base(navigationService)
        { }
        #endregion
    }
}
