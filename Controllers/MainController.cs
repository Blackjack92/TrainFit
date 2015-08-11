using Microsoft.Practices.Prism.Mvvm.Interfaces;

namespace TrainFit.Controllers
{
    public class MainController
    {
        #region properties
        public INavigationService NavigationService { get; private set; }
        #endregion

        #region ctor
        public MainController(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        #endregion
    }
}
