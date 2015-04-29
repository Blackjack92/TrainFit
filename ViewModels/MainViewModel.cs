using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TrainFit.ViewModels
{
    public class MainViewModel : ViewModel
    {
        #region fields
        private readonly INavigationService navigationService; 
        #endregion

        #region properties
        public ICommand BackCommand { get; private set; }
        #endregion

        #region ctor
        public MainViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            BackCommand = new DelegateCommand(navigationService.GoBack);
        }
        #endregion
    }
}
