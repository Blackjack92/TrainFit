using Microsoft.Practices.Prism.Mvvm;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainFit.Models
{
    [Table("Users")]
    public class User : ModelBase
    {
        #region fields
        private string name;
        #endregion

        #region properties
        public string Name 
        {
            get
            {
                return name;
            } 
            set 
            {
                SetProperty(ref name, value);
            } 
        }
        #endregion
    }
}
