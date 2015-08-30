using System.Linq;
using TrainFit.Utils;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace TrainFit.Controls
{
    public class HamburgerMenu : ContentControl
    {
        #region fields
        private ContentPresenter LeftPanePresenter { get;set; }
        private Rectangle MainPaneRectangle { get; set; }
        #endregion

        #region dependency properties
        public static readonly DependencyProperty LeftPaneProperty = DependencyProperty.Register("LeftPane", typeof(UIElement), typeof(HamburgerMenu), new PropertyMetadata(null));
        public UIElement LeftPane
        {
            get { return (UIElement)GetValue(LeftPaneProperty); }
            set { SetValue(LeftPaneProperty, value); }
        }

        public static readonly DependencyProperty IsLeftPaneOpenProperty = DependencyProperty.Register("IsLeftPaneOpen", typeof(bool), typeof(HamburgerMenu), new PropertyMetadata(false, new PropertyChangedCallback(OnIsLeftPaneOpenChanged)));
        public bool IsLeftPaneOpen
        {
            get { return (bool)GetValue(IsLeftPaneOpenProperty); }
            set { SetValue(IsLeftPaneOpenProperty, value); }
        }

        public static readonly DependencyProperty LeftPaneWidthProperty = DependencyProperty.Register("LeftPaneWidth", typeof(double), typeof(HamburgerMenu), new PropertyMetadata(300.0, new PropertyChangedCallback(OnLeftPaneWidthChanged)));
        public double LeftPaneWidth
        {
            get { return (double)GetValue(LeftPaneWidthProperty); }
            set { SetValue(LeftPaneWidthProperty, value); }
        }
        #endregion

        #region ctor
        public HamburgerMenu()
        {
            DefaultStyleKey = typeof(HamburgerMenu);
        }
        #endregion

        #region methods
        protected override void OnApplyTemplate()
        {
            // Find the left pane in the control template and store a reference
            LeftPanePresenter = GetTemplateChild("leftPanePresenter") as ContentPresenter;
            MainPaneRectangle = GetTemplateChild("mainPaneRectangle") as Rectangle;
            var mainToggleButton = GetTemplateChild("toggleButtonHamburgerMenu") as ToggleButton;
            var sideToggleButton = XamlHelper.GetChildrenOfType<ToggleButton>(LeftPanePresenter.Content as StackPanel).FirstOrDefault();

            if (MainPaneRectangle != null)
            {
                MainPaneRectangle.Tapped += (sender, e) => { IsLeftPaneOpen = false; };
            }

            // Ensure that the TranslateX on the RenderTransform of the left pane is set to the negative value of the left pa
            SetLeftPanePresenterX();

            // Set open/close for the sidebar
            if(mainToggleButton != null)
            {
                mainToggleButton.Click += OpenSidebar;
            }

            if (sideToggleButton != null)
            {
                sideToggleButton.Click += CloseSidebar;
            }

            base.OnApplyTemplate();
        }

        private void CloseSidebar(object sender, RoutedEventArgs e)
        {
            IsLeftPaneOpen = false;
        }

        private void OpenSidebar(object sender, RoutedEventArgs e)
        {
            IsLeftPaneOpen = true;
        }

        private void SetLeftPanePresenterX()
        {
            // Set the X position of the left pane content presenter to the negative of the pane so that it's off to the left of the screen when closed
            if (LeftPanePresenter != null)
            {
                LeftPanePresenter.RenderTransform = new CompositeTransform()
                {
                    TranslateX = -LeftPaneWidth
                };
            }
        }

        private static void OnIsLeftPaneOpenChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var ctrl = sender as HamburgerMenu;
            if (ctrl != null)
            {
                if (ctrl.LeftPane != null)
                {
                    // Change to appropriate view state when the the IsLeftPaneOpen is toggled
                    var value = (bool)args.NewValue;
                    if (value)
                        VisualStateManager.GoToState(ctrl, "OpenLeftPane", true);
                    else
                        VisualStateManager.GoToState(ctrl, "CloseLeftPane", true);
                }
            }
        }
       
        private static void OnLeftPaneWidthChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            // Update the starting X position of the left pane if the width is updated
            var ctrl = sender as HamburgerMenu;
            if (ctrl != null && args.NewValue is double)
                ctrl.SetLeftPanePresenterX();
        }
        #endregion
    }
}
