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
            set { SetValue(ImageSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(BitmapImage), typeof(ImageButton), new PropertyMetadata(null, OnImageSourceChanged));
        #endregion

        #region ctor
        public ImageButton()
        {
            this.DefaultStyleKey = typeof(ImageButton);
        }
        #endregion

        #region methods
        private static void OnImageSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {

        }
        #endregion
    }
}
