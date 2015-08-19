using TrainFit.Models;
using TrainFit.Services;
using Windows.UI.Xaml.Media;

namespace TrainFit.DataModels
{
    public class ExerciseDataModel : ModelBase
    {
        #region fields
        private Exercise exercise;
        private ImageSource imageSource;
        private bool isChecked;
        #endregion

        #region properties
        public Exercise Exercise { get { return exercise; } private set { SetProperty(ref exercise, value); } }
        public ImageSource ImageSource { get { return imageSource; } private set { SetProperty(ref imageSource, value); } }
        public bool IsChecked { get { return isChecked; } set 
        { 
            SetProperty(ref isChecked, value); } }
        #endregion

        #region ctor
        public ExerciseDataModel(Exercise exercise, ImageService imageService)
        {
            Exercise = exercise;
            ImageSource = imageService.GetImageSource("");
        }
        #endregion
    }
}
