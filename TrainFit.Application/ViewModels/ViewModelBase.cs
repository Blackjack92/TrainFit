using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainFit.Platform;
using TrainFit.Presentation.Views;

namespace TrainFit.Application.ViewModels
{
    public abstract class ViewModelBase : NotifyPropertyChangedBase
    {
        #region fields
        private IView view;
        #endregion

        #region properties
        public IView View
        {
            get { return view; }
            set 
            { 
                view = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
