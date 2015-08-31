using System;

namespace TrainFit.Utils
{
    public enum Navigate
    {
        Login,
        Main,
        Register,
        Trainings,
        Training,
        Exercise,
        Exercises
    }

    static class NavigateExtensions
    {
        public static string PageName(this Navigate navigate)
        {
            return Enum.GetName(typeof(Navigate), navigate);
        }
    }
}