using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using TrainFit.Utils;
using Windows.UI.Xaml;

namespace TrainFit.Services
{
    public static class TimerServiceNames
    {
        public static readonly string StartTimer = StaticReflection.GetMemberName<TimerService>(service => service.StartTimer);
        public static readonly string StopTimer = StaticReflection.GetMemberName<TimerService>(service => service.StopTimer);

    }

    public class TimerService : BindableBase, ITimerService
    {
        #region fields
        private DispatcherTimer timer;
        private bool startTimer;
        private bool stopTimer;
        private TimeSpan currentTime;
        #endregion

        #region properties
        public bool StartTimer { get { return startTimer; } set { SetProperty(ref startTimer, value); } }
        public bool StopTimer { get { return stopTimer; } set { SetProperty(ref stopTimer, value); } }
        public TimeSpan CurrentTime { get { return currentTime; } set { SetProperty(ref currentTime, value); } }
        #endregion

        #region ctor
        public TimerService()
        {
            CurrentTime = new TimeSpan();
            timer = new DispatcherTimer();
            timer.Tick += OnTimerTick;
            PropertyChanged += OnPropertyChanged;
        }
        #endregion

        #region methods
        public void AddEventHandler(EventHandler<object> handler)
        {
            if (timer != null) 
            {
                timer.Tick += handler;
            }
        }

        public void RemoveEventHandler(EventHandler<object> handler)
        {
            if (timer != null)
            {
                timer.Tick -= handler;
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == TimerServiceNames.StartTimer && StartTimer)
            {
                CurrentTime = new TimeSpan();
                timer.Start();
                StopTimer = false;
            }
            else if (e.PropertyName == TimerServiceNames.StopTimer && StopTimer)
            {
                timer.Stop();
                StartTimer = false;
            }
        }

        private void OnTimerTick(object sender, object e)
        {
            CurrentTime += timer.Interval;
        }
        #endregion
    }
}
