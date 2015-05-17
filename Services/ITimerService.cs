using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainFit.Services
{
    public interface ITimerService
    {
        #region properties
        bool StartTimer { get; set; }
        bool StopTimer { get; set; }
        TimeSpan CurrentTime { get; set; }
        #endregion

        #region methods
        public void AddEventHandler(EventHandler<object> handler);
        public void RemoveEventHandler(EventHandler<object> handler);
        #endregion
    }
}
