using System;
using System.Diagnostics;

namespace SortingTemplateMethod
{
    abstract class SortingAlgorithm
    {
        public void Sort(int[] array)
        {
            StartSorting(array);
            PerformSort(array);
            EndSorting();
        }

        private void StartSorting(int[] array)
        {
            Console.WriteLine($"Sorting started with {array.Length} elements");
        }


        protected abstract void PerformSort(int[] array);

        private void EndSorting()
        {
            Console.WriteLine("Sorting completed.");
        }
    }
    class BubbleSort : SortingAlgorithm
    {
        protected override void PerformSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }

    class InsertionSort : SortingAlgorithm
    {
        protected override void PerformSort(int[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
        }
    }

    class SelectionSort : SortingAlgorithm
    {
        protected override void PerformSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIdx])
                    {
                        minIdx = j;
                    }
                }

                int temp = array[minIdx];
                array[minIdx] = array[i];
                array[i] = temp;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = GenerateRandomArray(1000);

            TestSortingAlgorithm(new BubbleSort(), array);

            TestSortingAlgorithm(new InsertionSort(), array);

            TestSortingAlgorithm(new SelectionSort(), array);

            Console.ReadLine();
        }

        static int[] GenerateRandomArray(int size)
        {
            Random rand = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(1, 10000);
            }
            return array;
        }

        static void TestSortingAlgorithm(SortingAlgorithm algorithm, int[] array)
        {
            int[] arrayCopy = (int[])array.Clone();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            algorithm.Sort(arrayCopy);

            stopwatch.Stop();

            Console.WriteLine($"{algorithm.GetType().Name} completed in {stopwatch.ElapsedMilliseconds} ms\n");
        }
    }
}
