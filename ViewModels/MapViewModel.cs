using Microsoft.Practices.Prism.Mvvm.Interfaces;

namespace TrainFit.ViewModels
{
    public class MapViewModel : ExtendedViewModel
    {
        public MapViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
        }
    }
}
