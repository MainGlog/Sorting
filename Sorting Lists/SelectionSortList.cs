using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftAntimalwareEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class SelectionSortList<T> : MyList<T>, ISortable<T>
        where T : IComparable<T>
    {
        public void Sort()
        { 
            for(int i = 0; i < size - 1; i++)
            {
                int minIndex = i;
          
                // Second iteration to find the smallest index
                for(int j = i + 1; j < size; j++)
                {
                    if (items[j].CompareTo(items[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }
                
                // If the smallest index has changed, swap it with the original index
                if(minIndex != i)
                {
                    T temp = items[i];
                    items[i] = items[minIndex];
                    items[minIndex] = temp;
                }

            }
        }
    }
}
