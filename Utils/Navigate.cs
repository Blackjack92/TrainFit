using System;

namespace TrainFit.Utils
{
    public enum Navigate
    {
        Main,
        Trainings,
        Training
    }

    static class NavigateExtensions
    {
        public static string PageName(this Navigate navigate)
        {
            return Enum.GetName(typeof(Navigate), navigate);
        }
    }
}