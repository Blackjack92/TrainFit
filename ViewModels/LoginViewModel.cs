using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using System;
using System.Windows.Input;
using TrainFit.Utils;

namespace TrainFit.ViewModels
{
    public class LoginViewModel : ExtendedViewModel
    {
        #region fields
        private string text;
        #endregion

        #region properties
        public string Text
        {
            get { return text; }
            set 
            {
                SetProperty(ref text, value);
            }
        }

        public ICommand ChangeTextCommand { get; private set; }
        #endregion

        #region ctor
        public LoginViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            ChangeTextCommand = new DelegateCommand(ChangeText);
        }
        #endregion

        #region methods
        private void ChangeText()
        {
            var random = new Random();
            Text = random.Next(1000, 10000).ToString();
            NavigationService.Navigate(Navigate.Main.PageName(), null);
        }
        #endregion
    }
}
