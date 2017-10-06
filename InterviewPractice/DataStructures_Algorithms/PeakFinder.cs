using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DataStructures_Algorithms
{
    internal class PeakFinder
    {
        static void Main(string[] args)
        {
            int[] arr = { 10 };
            Console.WriteLine(PeakFinder.Find1DPeak(arr));

            arr = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(PeakFinder.Find1DPeak(arr));

            arr = new int[] { 1, 200, 40, 50, 65, 70, 46, 27 };
            Console.WriteLine(PeakFinder.Find1DPeak(arr));

            arr = new int[] { 1, 3, 20, 4, 1, 0 };
            Console.WriteLine(PeakFinder.Find1DPeak(arr));

            arr = new int[] { 1, 1, 1, 1 };
            Console.WriteLine(PeakFinder.Find1DPeak(arr));

            arr = new int[100000000];
            Random r = new Random();
            for (int i = 0; i < 100000000 ; i++)
            {
                arr[i] = i;
            }

            Stopwatch w = Stopwatch.StartNew();
            Console.WriteLine($"Total time taken: { w.ElapsedMilliseconds }");
            w.Stop();

            w = Stopwatch.StartNew();
            Console.WriteLine(PeakFinder.Find1DPeak(arr));
            Console.WriteLine($"Total time taken: { w.ElapsedMilliseconds }");
            w.Stop();

            w = Stopwatch.StartNew();
            Console.WriteLine($"Total time taken: { w.ElapsedMilliseconds }");
            w.Stop();

        }

        private static int Find1DPeak(int[] array)
        {
            if(array == null || array.Length == 0)
            {
                throw new ArgumentException();
            }

            if(array.Length == 1)
            {
                return array[0];
            }

            return Find1DPeakRecursive(array, 0, array.Length - 1);
        }

        private static int Find1DPeakRecursive(int[] input, int startIndex, int endIndex)
        {
            int itemCount = endIndex - startIndex + 1;
            if(itemCount == 1)
            {
                return input[endIndex];
            }

            int midIndex = (startIndex + endIndex) / 2;
            if(input[midIndex] < input[midIndex + 1])
            {
                return Find1DPeakRecursive(input, midIndex + 1, endIndex);
            }

            if(input[midIndex] < input[midIndex - 1])
            {
                return Find1DPeakRecursive(input, startIndex, midIndex - 1);
            }

            return input[midIndex];
        }
        
    }
}
