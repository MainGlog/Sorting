using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class LSDRadixSortList : MyList<int>, ISortable<int>
    {
        public void Sort()
        {
            for (int exponent = 1; items.Max() / exponent > 0; exponent *= 10)
            {
                // Create a list to represent the occurrences of integers 0 through 9
                List<int> occurrences = Enumerable.Repeat(0, 10).ToList();

                // Create new array to store the original array sorted by the place value
                int[] newArray = new int[items.Length];

                // Increment the occurrences of each value for each item in the array
                for (int i = 0; i < items.Length; i++)
                {
                    int sigDig = items[i] / exponent % 10;
                    occurrences[sigDig]++;
                }

                // Iterate through the occurrences, adding the previous number to the current one
                for (int i = 0; i < occurrences.Count - 1; i++)
                {
                    occurrences[i + 1] += occurrences[i];
                }

                // Place items sorted by the current place value into the new array
                for (int i = items.Length - 1; i >= 0; i--)
                {
                    int sigDig = items[i] / exponent % 10;
                    newArray[occurrences[sigDig] - 1] = items[i];
                    occurrences[sigDig]--;
                }

                // Overwrite existing array
                items = newArray;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                sb.Append(items[i]);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
    }
}
