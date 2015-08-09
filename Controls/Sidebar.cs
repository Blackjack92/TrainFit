using System.Collections.Generic;
using TrainFit.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TrainFit.Controls
{
    public class Sidebar : Control
    {
        #region fields
        private const string btnTrainings = "btnTrainings";
        private const string btnRegister = "btnRegister";
        private const string btnMap = "btnMap";
        private const string btnExercise = "btnExercise";
        private const string btnExercises = "btnExercises";

        private List<Button> buttons;
        #endregion

        #region ctor
        public Sidebar()
        {
            this.DefaultStyleKey = typeof(Sidebar);
            buttons = new List<Button>();
        }
        #endregion

        #region methods
        protected override void OnApplyTemplate()
        {
            buttons.Add(GetTemplateChild(btnTrainings) as Button);
            buttons.Add(GetTemplateChild(btnRegister) as Button);
            buttons.Add(GetTemplateChild(btnMap) as Button);
            buttons.Add(GetTemplateChild(btnExercise) as Button);
            buttons.Add(GetTemplateChild(btnExercises) as Button);

            foreach (var button in buttons)
            {
                button.Click += OnButtonClick;
            }

            base.OnApplyTemplate();
        }

        void OnButtonClick(object sender, RoutedEventArgs e)
        {
            // HACK: because dependency property has not worked
            var context = DataContext as ExtendedViewModel;
            var button = sender as Button;
            string navigateTo = button == null || button.Content == null || !(button.Content is string) ? "Main" : button.Content as string;

            if (context != null && context.NavigationService != null)
            {
                context.NavigationService.Navigate(navigateTo, null);
            }
        }
        #endregion

    }
}
