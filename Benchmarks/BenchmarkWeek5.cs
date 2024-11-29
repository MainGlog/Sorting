using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class BenchmarkWeek5
    {
        public static void RunBenchmark()
        {
            BenchmarkRunner.Run<MyBenchmark>();
        }
    }

    [MaxIterationCount(21)]
    public class MyBenchmark
    {
        [Params(10, 100, 1000, 10000)]
        public int N { get; set; }

        private List<int> originalList = [];
        private List<int> list = [];
        private BubbleSortList<int> list2 = new BubbleSortList<int>();

        [GlobalSetup]
        public void Setup()
        {
            Random rand = new Random();
            originalList = new List<int>(N);

            // Pre-generate the random data once
            for (int i = 0; i < N; i++)
            {
                originalList.Add(rand.Next(0, int.MaxValue));
            }
        }

        [IterationSetup]
        public void IterationSetup()
        {
            // Reset the lists to their unsorted state for each benchmark iteration
            list = new List<int>(originalList);
            list2 = new BubbleSortList<int>();
            foreach (var num in originalList)
            {
                list2.Insert(num);
            }
        }

        [Benchmark]
        public void ListSort()
        {
            list.Sort();
        }

        [Benchmark]
        public void MySortableListSort()
        {
            list2.Sort();
        }
    }
}
