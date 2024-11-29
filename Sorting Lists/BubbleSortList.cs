using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class BubbleSortList<T> : MyList<T>, ISortable<T>
        where T : IComparable<T>
    {
        public void Sort()
        {
            bool sorted = false;
            int unsortedUntilIndex = size - 1;

            while (sorted == false)
            {
                sorted = true;

                for (int i = 0; i < unsortedUntilIndex; i++)
                {
                    // Swap if items are out of order
                    if (items[i].CompareTo(items[i + 1]) > 0)
                    {
                        T temp = items[i];
                        items[i] = items[i + 1];
                        items[i + 1] = temp;
                        sorted = false;
                    }
                }

                unsortedUntilIndex--;
            }
        }
    }
}
