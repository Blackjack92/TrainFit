using Microsoft.Practices.Prism.Mvvm;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainFit.Models
{
    [Table("Exercises")]
    public class Exercise : ModelBase
    {
        #region fields
        private string name;
        private Difficulty difficulty;
        private Uri url;
        private Uri imageSource;
        private string description;
        #endregion

        #region properties
        public string Name { get { return name; } set { SetProperty(ref name, value); } }
        public Difficulty Difficulty { get { return difficulty; } set { SetProperty(ref difficulty, value); } }
        public Uri Url { get { return url; } set { SetProperty(ref url, value); } }
        public Uri ImageSource { get { return imageSource; } set { SetProperty(ref imageSource, value); } }
        public string Description { get { return description; } set { SetProperty(ref description, value); } }
        #endregion
    }
}
