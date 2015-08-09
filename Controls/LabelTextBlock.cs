using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TrainFit.Controls
{
    // Inherit from TextBox because TextBlock is sealed
    public class LabelTextBlock : TextBox
    {
        #region dependency properties
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(LabelTextBlock), null);
        #endregion

        #region ctor
        public LabelTextBlock()
        {
            this.DefaultStyleKey = typeof(TextBlock);
        }
        #endregion
    }
}
