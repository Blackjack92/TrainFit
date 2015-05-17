using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using Windows.UI.Xaml;

namespace TrainFit.Services
{
    public class TimeService : BindableBase

    {
        #region fields
        private DispatcherTimer timer;
        private bool startTimer;
        private bool stopTimer;
        private TimeSpan time;
        #endregion

        #region properties
        public bool StartTimer { get { return startTimer; } set { SetProperty(ref startTimer, value); } }
        public bool StopTimer { get { return stopTimer; } set { SetProperty(ref stopTimer, value); } }
        public TimeSpan Time { get { return time; } set { SetProperty(ref time, value); } }
        #endregion

        #region ctor
        public TimeService()
        {
            timer = new DispatcherTimer();
            timer.Tick += OnTimerTick;
            PropertyChanged += OnPropertyChanged;
        }

        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // TODO: Handle property changed e.g. enable/disable timer
            throw new NotImplementedException();
        }

        private void OnTimerTick(object sender, object e)
        {
            // TODO: Handle timer tick e.g. with a callback
            throw new NotImplementedException();
        }
        #endregion
    }
}
