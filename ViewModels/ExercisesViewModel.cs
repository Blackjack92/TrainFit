using Microsoft.Practices.Prism.Mvvm.Interfaces;

namespace TrainFit.ViewModels
{
    public class ExercisesViewModel : ExtendedViewModel
    {
        public ExercisesViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
