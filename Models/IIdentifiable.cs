using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainFit.Models
{
    public interface IIdentifiable
    {
        #region properties
        Guid Id { get; set; }
        #endregion
    }
}
