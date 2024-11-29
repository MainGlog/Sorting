using Sorting.Sorting_Lists;
using System.Collections.Immutable;

namespace Sorting
{
    public class Program
    {
        public static void Main()
        {
#if RELEASE
            // BENCHMARK CODE
            BenchmarkWeek9_2.RunBenchmark();
#else

            Console.WriteLine("Bubble Sort:");
            ISortable<int> bsList = new BubbleSortList<int>();
            TestSort(bsList);

            Console.WriteLine("Selection Sort:");
            ISortable<int> ssList = new SelectionSortList<int>();
            TestSort(ssList);

            Console.WriteLine("Insertion Sort:");
            ISortable<int> isList = new InsertionSortList<int>();
            TestSort(isList);

            Console.WriteLine("Quicksort:");
            ISortable<int> qsList = new QuicksortList<int>();
            TestSort(qsList);

            Console.WriteLine("Mergesort:");
            ISortable<int> msList = new MergeSortList<int>();
            TestSort(msList);

            Console.WriteLine("Heap Sort:");
            ISortable<int> hsList = new HeapSortList<int>();
            TestSort(hsList);

            Console.WriteLine("LSD Radix Sort:");
            ISortable<int> lsdList = new LSDRadixSortList();
            TestSort(lsdList);

#endif
        }

        private static void TestSort(ISortable<int> list)
        {
            Random rand = new Random();
            int[] items = Enumerable.Range(1, 12)
                .Select(x => rand.Next(0, 100)).ToArray();

            list = new BubbleSortList<int>();

            foreach (int i in items)
            {
                list.Insert(i);
            }


            Console.WriteLine("Unsorted: " + list);
            list.Sort();
            Console.WriteLine("Sorted: " + list + Environment.NewLine);
        }
    }

}
