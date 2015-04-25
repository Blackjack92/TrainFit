using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainFit.Application.ViewModels;
using TrainFit.Platform;

namespace TrainFit.Application
{
    public class MainController : NotifyPropertyChangedBase, IController
    {
        #region fields
        private ViewModelBase currentViewModel;
        #endregion

        #region properties
        public ViewModelBase CurrentViewModel 
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged();
            }
        }
        #endregion

    }
}
