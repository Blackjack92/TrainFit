using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainFit.Services
{
    public interface IDataReader<T>
    {
        Task<ICollection<T>> ReadAllAsync();
    }
}
