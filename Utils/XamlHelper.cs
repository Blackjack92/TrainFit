using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace TrainFit.Utils
{
    public static class XamlHelper
    {
        public static IEnumerable<T> GetChildrenOfType<T>(DependencyObject parent) where T : DependencyObject
        {
            List<T> children = new List<T>();

            if (parent == null) { return children; }

            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i); 

                if (child is T)
                {
                    children.Add((T)child);
                }

                int xx = VisualTreeHelper.GetChildrenCount(child);
                if (xx > 0)
                {
                    children.AddRange(GetChildrenOfType<T>(child));
                }
            }

            return children;
        }
    }
}
