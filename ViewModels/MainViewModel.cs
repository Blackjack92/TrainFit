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
        public ICommand RegisterCommand { get; private set; }

        #region ctor
        public MainViewModel(INavigationService navigationService)
        {
            //TODO : Change this it creats a bug
            this.navigationService = navigationService;
            BackCommand = new DelegateCommand(navigationService.GoBack);
            RegisterCommand = new DelegateCommand(ChangeToRegisterPage);
        }
        #endregion

        private void ChangeToRegisterPage()
        {
            navigationService.Navigate("Register", null);
        }
    }
}
