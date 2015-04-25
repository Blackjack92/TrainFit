using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainFit.Presentation.Views;

namespace TrainFit.Application.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region ctor
        public MainViewModel()
        {
            View = new StartView();
        }
        #endregion
    }
}
