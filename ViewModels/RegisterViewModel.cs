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
    public class RegisterViewModel : ViewModel
    {
        #region fields
        private string firstname, lastname, emailaddress, password;
        private INavigationService navigationService;
        #endregion

        #region properties
        public string FirstName
        {
            get { return firstname; }
            set 
            {
                SetProperty(ref firstname, value);
            }
        }

        public string LastName
        {
            get { return lastname; }
            set
            {
                SetProperty(ref lastname, value);
            }
        }

        public string EmailAddress
        {
            get { return emailaddress; }
            set
            {
                SetProperty(ref emailaddress, value);
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                SetProperty(ref password, value);
            }
        }

        public ICommand ChangeTextFieldsCommand { get; private set; }
        #endregion

        #region ctor
        public RegisterViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            ChangeTextFieldsCommand = new DelegateCommand(ChangeText);
        }
        #endregion

        #region methods
        private void ChangeText()
        {
            var random = new Random();
            FirstName = random.Next(100, 199).ToString();
            LastName = random.Next(200, 299).ToString();
            EmailAddress = random.Next(300, 399).ToString();
            Password = random.Next(400, 500).ToString();

            navigationService.Navigate("Main", null);
        }
        #endregion
    }
}
