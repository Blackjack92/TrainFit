using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using System.Linq;
using TrainFit.DataModels;
using TrainFit.ViewModels;
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

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox == null) { return; }

            // Use this because it is not possible to bind on the selected item
            var selectedElement = listBox.SelectedItem;

            var viewModel = DataContext as ExercisesViewModel;
            if (viewModel == null) { return; }

            viewModel.SelectedExercise = selectedElement as ExerciseDataModel;
         }
        #endregion
    }
}
