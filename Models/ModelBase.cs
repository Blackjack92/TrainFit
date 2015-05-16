using Microsoft.Practices.Prism.Mvvm;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainFit.Models
{
    public class ModelBase : BindableBase, IIdentifiable, IStoreable
    {
        #region fields
        private int id;
        private bool isStored;
        private bool isUpdated;
        #endregion

        #region ctor
        public ModelBase()
        {
            PropertyChanged += OnPropertyChanged;
        }
        #endregion

        #region properties
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set
            {
                SetProperty(ref id, value);
            }
        }

        public bool IsStored
        {
            get
            {
                return isStored;
            }
            set
            {
                SetProperty(ref isStored, value);
            }
        }

        public bool IsUpdated
        {
            get { return isUpdated; }
            set { SetProperty(ref isUpdated, value); }
        }
        #endregion

        #region methods
        protected void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsStored") && IsStored)
            {
                IsUpdated = true;
            }
            
        }
        #endregion
    }
}
