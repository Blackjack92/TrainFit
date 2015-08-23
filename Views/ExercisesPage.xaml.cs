using Microsoft.Practices.Prism.Mvvm;
using TrainFit.Utils;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkID=390556 dokumentiert.

namespace TrainFit.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet werden kann oder auf die innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class ExercisesPage : IView
    {
        #region ctor
        public ExercisesPage()
        {
            this.InitializeComponent();
        }
        #endregion

        #region methods
        /// <summary>
        /// Wird aufgerufen, wenn diese Seite in einem Frame angezeigt werden soll.
        /// </summary>
        /// <param name="e">Ereignisdaten, die beschreiben, wie diese Seite erreicht wurde.
        /// Dieser Parameter wird normalerweise zum Konfigurieren der Seite verwendet.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void OnEnableSelectionClicked(object sender, RoutedEventArgs e)
        {
            var checkBoxes = XamlHelper.GetChildrenOfType<CheckBox>(listBox);

            var visibility = btnCreateTraining.Visibility == Visibility.Collapsed
                 ? Visibility.Visible
                 : Visibility.Collapsed;

            btnCreateTraining.Visibility = visibility;

            foreach (var checkBox in checkBoxes)
            {
                checkBox.Visibility = visibility;
            }
        }
        #endregion
    }
}
