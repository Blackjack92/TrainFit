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
        #endregion

        #region properties
        public string Name { get { return name; } set { SetProperty(ref name, value); } }
        public Difficulty Difficulty { get { return difficulty; } set { SetProperty(ref difficulty, value); } }
        #endregion
    }
}
