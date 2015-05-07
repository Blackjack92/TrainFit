using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainFit.Utils
{
    public enum Navigate
    {
        Login,
        Main,
        Register,
        Trainings
    }

    static class NavigateExtensions
    {
        public static string PageName(this Navigate navigate)
        {
            return Enum.GetName(typeof(Navigate), navigate);
        }
    }
}