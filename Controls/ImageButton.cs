using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace TrainFit.Controls
{
    public class ImageButton : Button
    {
        #region dependency properties
        public BitmapImage ImageSource
        {
            get { return (BitmapImage)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, (BitmapImage)value); }
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(BitmapImage), typeof(ImageButton), null);

        public BitmapImage ImageSourcePressed
        {
            get { return (BitmapImage)GetValue(ImageSourcePressedProperty); }
            set { SetValue(ImageSourcePressedProperty, (BitmapImage)value); }
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourcePressedProperty =
            DependencyProperty.Register("ImageSourcePressed", typeof(BitmapImage), typeof(ImageButton), null);
        #endregion

        #region ctor
        public ImageButton()
        {
            this.DefaultStyleKey = typeof(ImageButton);
        }
        #endregion
    }
}
