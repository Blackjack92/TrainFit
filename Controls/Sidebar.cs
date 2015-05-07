using Microsoft.Practices.Prism.Mvvm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrainFit.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TrainFit.Controls
{
    public class Sidebar : Control
    {
        #region fields
        private readonly string btnTrainings = "btnTrainings";
        private readonly string btnRegister = "btnRegister";

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
