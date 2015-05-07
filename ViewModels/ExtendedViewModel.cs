using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainFit.ViewModels
{
    public class ExtendedViewModel : ViewModel
    {
        #region properties
        public INavigationService NavigationService { get; protected set; }
        #endregion
    }
}
