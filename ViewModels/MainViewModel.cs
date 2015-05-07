using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrainFit.Utils;

namespace TrainFit.ViewModels
{
    public class MainViewModel : ExtendedViewModel
    {
        #region properties
        public ICommand BackCommand { get; private set; }
        public ICommand RegisterCommand { get; private set; }
        #endregion

        #region ctor
        public MainViewModel(INavigationService navigationService)
        {
            //TODO : Change this it creats a bug
            NavigationService = navigationService;
            BackCommand = new DelegateCommand(navigationService.GoBack);
            RegisterCommand = new DelegateCommand(ChangeToRegisterPage);
        }
        #endregion

        private void ChangeToRegisterPage()
        {
            NavigationService.Navigate(Navigate.Register.PageName(), null);
        }
    }
}
