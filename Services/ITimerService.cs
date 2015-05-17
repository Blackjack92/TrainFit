using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainFit.Services
{
    public interface ITimerService
    {
        bool StartTimer { get; set; }
        bool StopTimer { get; set; }
        TimeSpan CurrentTime { get; set; }
    }
}
