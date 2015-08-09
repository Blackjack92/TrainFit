using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;

namespace TrainFit.ViewModels
{
    public class ExtendedViewModel : ViewModel
    {
        #region properties
        public INavigationService NavigationService { get; private set; }
        #endregion

        #region ctor
        protected ExtendedViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        #endregion
    }
}
