using Microsoft.Practices.Prism.Mvvm;
using TrainFit.DataModels;
using TrainFit.Utils;
using TrainFit.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace TrainFit.Views
{
    public sealed partial class ExercisesPage : IView
    {
        #region fields
        private readonly ExercisesViewModel viewModel;
        #endregion

        #region ctor
        public ExercisesPage()
        {
            InitializeComponent();

            viewModel = DataContext as ExercisesViewModel;
        }
        #endregion

        #region methods
        private void OnEnableSelectionClicked(object sender, RoutedEventArgs e)
        {
            //var checkBoxes = XamlHelper.GetChildrenOfType<CheckBox>(listBox);

            var visibility = btnCreateTraining.Visibility == Visibility.Collapsed
                 ? Visibility.Visible
                 : Visibility.Collapsed;

            btnCreateTraining.Visibility = visibility;

            //foreach (var checkBox in checkBoxes)
            //{
            //    checkBox.Visibility = visibility;
            //}
        }

        private void OnElementTapped(object sender, TappedRoutedEventArgs e)
        {
            if (viewModel.IsCreateTrainingEnabled)
            {
                var listBox = sender as ListBox;
                if (listBox == null) { return; }

                var exercise = listBox.SelectedItem as ExerciseDataModel;
                if (exercise == null) { return; }

                exercise.IsChecked = !exercise.IsChecked;
            }
        }

        #endregion

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void CheckBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {

        }

        private void CheckBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {

        }

        private void CheckBox_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void CheckBox_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            //e.Handled = true;
        }

        private void CheckBox_PointerExited(object sender, PointerRoutedEventArgs e)
        {

        }

        private void CheckBox_PointerCanceled(object sender, PointerRoutedEventArgs e)
        {

        }

        private void CheckBox_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {

        }

        private void CheckBox_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            e.Handled = true;
        }
    }
}
