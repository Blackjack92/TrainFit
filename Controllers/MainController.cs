using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Microsoft.Practices.Unity;
using TrainFit.Services;

namespace TrainFit.Controllers
{
    public class MainController
    {
        #region fields
        private readonly UnityContainer container;
        #endregion

        #region properties
        public INavigationService NavigationService { get; private set; }
        #endregion

        #region ctor
        public MainController(INavigationService navigationService, UnityContainer container)
        {
            NavigationService = navigationService;
            this.container = container;
        }
        #endregion

        #region methods
        public void Run()
        {
            NavigationService.Navigate("Login", null);
        }
        #endregion
    }
}
