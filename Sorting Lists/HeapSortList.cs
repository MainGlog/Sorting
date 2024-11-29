using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sorting.Sorting_Lists
{
    public class HeapSortList<T> : MyList<T>, ISortable<T>
        where T : IComparable<T>
    {
        public void Sort()
        {
            int length = items.Length;

            for (int i = length / 2 - 1; i >= 0; i--)
            {
                Heapify(items, length, i);
            }

            for (int i = length - 1; i > 0; i--)
            {
                T temp = items[0];
                items[0] = items[i];
                items[i] = temp;

                Heapify(items, i, 0);
            }
        }

        static void Heapify(T[] array, int length, int root)
        {
            int largest = root;
            int leftIndex = 2 * root + 1;
            int rightIndex = 2 * root + 2;

            if (leftIndex < length && array[leftIndex].CompareTo(array[largest]) > 0)
            {
                largest = leftIndex;
            }

            if (rightIndex < length && array[rightIndex].CompareTo(array[largest]) > 0)
            {
                largest = rightIndex;
            }

            // Swap the last element in the array 
            if (largest != root)
            {
                T temp = array[root];
                array[root] = array[largest];
                array[largest] = temp;

                Heapify(array, length, largest);
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < items.Length; i++)
            {
                sb.Append(items[i]);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
    }
}
