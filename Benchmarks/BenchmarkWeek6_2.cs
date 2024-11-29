using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    public class BenchmarkWeek6_2
    {
        public static void RunBenchmark()
        {
            BenchmarkRunner.Run<MyBenchmark_2>();
        }
    }

    public class MyBenchmark_2
	{
        private List<int> originalList = [];
        public BubbleSortList<int> bsList = new BubbleSortList<int>();
		public SelectionSortList<int> ssList = new SelectionSortList<int>();
		public SelectionSortList<int> isList = new SelectionSortList<int>();

        [Params(100, 1000, 10_000)]
        public int N;

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
            bsList = new BubbleSortList<int>();
            ssList = new SelectionSortList<int>();
            isList = new SelectionSortList<int>();

            foreach (int num in originalList)
            {
                bsList.Insert(num);
                ssList.Insert(num);
                isList.Insert(num);
            }
        }

        [Benchmark(Baseline = true)]
		public void BubbleSort() => bsList.Sort();

		[Benchmark]
		public void SelectionSort() => ssList.Sort();

		[Benchmark]
		public void InsertionSort() => isList.Sort();
	}
}
