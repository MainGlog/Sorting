using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public interface ISortable<T> : IList<T>
        where T : IComparable<T>
    {
        void Sort();
    }
}
