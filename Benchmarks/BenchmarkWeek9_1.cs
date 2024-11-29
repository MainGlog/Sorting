/*
 * While the benchmark is running, go to the next slides
 */

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    public class BenchmarkWeek9_1
    {
        public static void RunBenchmark()
        {
            BenchmarkRunner.Run<MyBenchmark_3>();
        }
    }

    public class MyBenchmark_3
    {
        private List<int> originalList = [];
        public BubbleSortList<int> bsList = new BubbleSortList<int>();
        public SelectionSortList<int> ssList = new SelectionSortList<int>();
        public InsertionSortList<int> isList = new InsertionSortList<int>();
        public QuicksortList<int> qsList = new QuicksortList<int>();

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
            isList = new InsertionSortList<int>();
            qsList = new QuicksortList<int>();

            foreach (int num in originalList)
            {
                bsList.Insert(num);
                ssList.Insert(num);
                isList.Insert(num);
                qsList.Insert(num);
            }
        }

        [Benchmark(Baseline = true)]
        public void BubbleSort() => bsList.Sort();

        [Benchmark]
        public void SelectionSort() => ssList.Sort();

        [Benchmark]
        public void InsertionSort() => isList.Sort();

        [Benchmark]
        public void Quicksort() => qsList.Sort();
    }
}
