﻿using Microsoft.Practices.Prism.Commands;
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
    public class LoginViewModel : ViewModel
    {
        #region fields
        private string text;
        private INavigationService navigationService;
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
        {
            this.navigationService = navigationService;
            ChangeTextCommand = new DelegateCommand(ChangeText);
        }
        #endregion

        #region methods
        private void ChangeText()
        {
            var random = new Random();
            Text = random.Next(1000, 10000).ToString();

            navigationService.Navigate("Main", null);
        }
        #endregion
    }
}
