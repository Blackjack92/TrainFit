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
        private void OnElementTapped(object sender, TappedRoutedEventArgs e)
        {
            if (viewModel.IsCreateTrainingEnabled)
            {
                //var listBox = sender as ListBox;
                //if (listBox == null) { return; }

                //var exercise = listBox.SelectedItem as ExerciseDataModel;
                //if (exercise == null) { return; }

                //exercise.IsChecked = !exercise.IsChecked;
            }
            else
            {
                viewModel.SelectedExercise = listBox.SelectedItem as ExerciseDataModel;
            }
        }

        #endregion
    }
}
