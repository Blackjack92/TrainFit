﻿using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainFit.Models
{
    public class User : BindableBase
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