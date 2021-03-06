﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TrainFit.Controls
{
    public class ImageButton : Button
    {
        #region dependency properties
        public ControlTemplate IconTemplate
        {
            get { return (ControlTemplate)GetValue(IconTemplateProperty); }
            set { SetValue(IconTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconTemplateProperty =
            DependencyProperty.Register("IconTemplate", typeof(ControlTemplate), typeof(ImageButton), null);
        #endregion

        #region ctor
        public ImageButton()
        {
            this.DefaultStyleKey = typeof(ImageButton);
        }
        #endregion
    }
}
