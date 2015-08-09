using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;

namespace TrainFit.ViewModels
{
    public class ExtendedViewModel : ViewModel
    {
        #region properties
        public INavigationService NavigationService { get; protected set; }
        #endregion
    }
}
