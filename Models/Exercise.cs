using Microsoft.Practices.Prism.Mvvm;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
        [XmlIgnoreAttribute]
        public Uri Url { get { return url; } set { SetProperty(ref url, value); } }
        [XmlIgnoreAttribute]
        public Uri ImageSource { get { return imageSource; } set { SetProperty(ref imageSource, value); } }
        public string Description { get { return description; } set { SetProperty(ref description, value); } }
        #endregion

        #region ctor
        public Exercise()
        { }
        #endregion
    }
}
