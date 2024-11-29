using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class MergeSortList<T> : MyList<T>, ISortable<T>
         where T : IComparable<T>
    {
        private void Merge(int left, int middle, int right)
        {
            // Size of left sub-array
            int n1 = middle - left + 1;

            // Size of right sub-array
            int n2 = right - middle;


            // Creating temp arrays
            T[] leftArray = new T[n1];
            T[] rightArray = new T[n2];

            // Copying contents of the original arrays into the temp arrays
            for(int i = 0; i < n1; i++)
            {
                leftArray[i] = items[left + i];
            }

            for(int i = 0; i < n2; i++)
            {
                rightArray[i] = items[middle + 1 + i];
            }

            int leftIndex = 0;
            int rightIndex = 0;

            int mergeIndex = left;
            

            // This while loop will be exited with the contents of one array being empty
            // Once the left or right index exceeds their size, the while loop is exited
            while(leftIndex < n1 && rightIndex < n2)
            {
                // The element in the left sub-array is smaller
                if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) < 0)
                {
                    items[mergeIndex] = leftArray[leftIndex];
                    leftIndex++;
                }
                // The element in the right sub-array is smaller
                else
                {
                    items[mergeIndex] = rightArray[rightIndex];
                    rightIndex++;
                }

                // Increment mergeIndex so it doesn't constantly reassign over the same index
                mergeIndex++;

            }

            // Copy remaining elements of the left sub-array into merged array
            while(leftIndex < n1)
            {
                items[mergeIndex] = leftArray[leftIndex];
                leftIndex++;
                mergeIndex++;
            }

            while (rightIndex < n2)
            {
                items[mergeIndex] = rightArray[rightIndex];
                rightIndex++;
                mergeIndex++;
            }


        }

        private void MergeSort(int left, int right)
        {
            // Base case
            if (left >= right) return;

            int middle = (left + right) / 2;

            // Breaking down
            MergeSort(left, middle);
            MergeSort(middle + 1, right);

            // Merging
            Merge(left, middle, right);

        }

        public void Sort()
        {
            MergeSort(0, size - 1);
        }
    }
}
