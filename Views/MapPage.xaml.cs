using Microsoft.Practices.Prism.Mvvm;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;

namespace TrainFit.Views
{
    public sealed partial class MapPage : IView
    {
        #region ctor
        public MapPage()
        {
            this.InitializeComponent();

            Map.MapHolding += OnMapHolding;
        }

        void OnMapHolding(MapControl sender, MapInputEventArgs args)
        {
            // Get point were a landmark should be put

            // Show context menu
            FrameworkElement contextElement = spContextMenu as FrameworkElement;
            if (contextElement != null)
            {
                FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(contextElement);
                flyoutBase.ShowAt(contextElement);
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        #endregion
    }
}
