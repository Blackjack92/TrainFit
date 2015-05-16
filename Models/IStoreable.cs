using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainFit.Models
{
    public interface IStoreable
    {
        #region properties
        bool IsStored { get; set; }

        bool IsUpdated { get; set; }
        #endregion
    }
}
