using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class QuicksortList<T> : MyList<T>, ISortable<T>
        where T : IComparable<T>
    {
        // Returns position of pivot
        private int Partition(int leftPointer, int rightPointer) 
        {
            int pivotIndex = rightPointer;
            T pivot = items[pivotIndex];

            rightPointer--;

            while (true)
            {
                while (items[leftPointer].CompareTo(pivot) < 0)
                {
                    leftPointer++;
                }

                // Right pointer may go past the bounds of the array, so the additional check is necessary.
                // This is not possible with the left pointer, as it will get to the pivot and the condition will not be true

                while (rightPointer >= 0 
                    && items[rightPointer].CompareTo(pivot) > 0)
                {
                    rightPointer--;
                }
                
                if(leftPointer >= rightPointer) break;

                T temp = items[leftPointer];
                items[leftPointer] = items[rightPointer];
                items[rightPointer] = temp;
                
                // Will prevent the left pointer from comparing it to itself
                leftPointer++;
            }

            items[pivotIndex] = items[leftPointer];
            items[leftPointer] = pivot;

            return leftPointer;
        }

        public void Quicksort(int leftIndex, int rightIndex)
        {
            // Base case
            if (rightIndex - leftIndex <= 0) return;

            int pivotIndex = Partition(leftIndex, rightIndex);
            
            // Recursively sort the left subarray
            Quicksort(leftIndex, pivotIndex - 1);
            
            // Recursively sort the right subarray
            Quicksort(pivotIndex + 1, rightIndex);
            
        }
        public void Sort()
        {
            Quicksort(0, size - 1);
        }
    }
}
