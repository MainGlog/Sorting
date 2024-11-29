using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class InsertionSortList<T> : MyList<T>, ISortable<T>
        where T : IComparable<T> 
    {
        public void Sort() 
        {
            for(int i = 1; i < size; i++) 
            {
                T temp = items[i]; // "Removal" of current element from list
                int j = i - 1;

                for (; j >= 0 && items[j].CompareTo(temp) > 0; j--)
                // While j is greater or equal to the left wall (0)
                // and the item at the current index is greater than the temp variable
                {
                    items[j + 1] = items[j]; // Shifting items to the right
                }
                // Exiting the inner for loop means either we went to the end of the array
                // Or the value at index j is less than or equal to the value of temp
                items[j + 1] = temp;
                // j can also be -1, you can't insert into the -1st element
                // j + 1 is necessary because you don't want to insert into J, it would be overwriting the value
            }
        }
    }
}
