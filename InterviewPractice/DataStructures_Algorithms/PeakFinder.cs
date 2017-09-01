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
            Console.WriteLine(PeakFinder.FindPeak(arr, 0, 0));

            arr = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(PeakFinder.FindPeak(arr, 0, arr.Length - 1));

            arr = new int[] { 1, 200, 40, 50, 65, 70, 46, 27 };
            Console.WriteLine(PeakFinder.FindPeak(arr, 0, arr.Length));

            arr = new int[] { 1, 3, 20, 4, 1, 0 };
            Console.WriteLine(PeakFinder.FindPeak(arr, 0, arr.Length));

            arr = new int[] { 1, 1, 1, 1 };
            Console.WriteLine(PeakFinder.FindPeak(arr, 0, arr.Length));

            arr = new int[100000000];
            Random r = new Random();
            for (int i = 0; i < 100000000 ; i++)
            {
                arr[i] = i;
            }

            Stopwatch w = Stopwatch.StartNew();
            Console.WriteLine(PeakFinder.FindPeak(arr, 0, arr.Length));
            Console.WriteLine($"Total time taken: { w.ElapsedMilliseconds }");
            w.Stop();

            w = Stopwatch.StartNew();
            Console.WriteLine(PeakFinder.FindPeakLinear(arr));
            Console.WriteLine($"Total time taken: { w.ElapsedMilliseconds }");
            w.Stop();

        }

        private static int FindPeakLinear(int[] array)
        {
            for(int i=0; i<array.Length; i++)
            {
                if (i == 0)
                {
                    if (array[i] >= array[i + 1])
                    {
                        return array[i];
                    }
                }
                else if (i == array.Length - 1)
                {
                    if(array[i] >= array[i-1])
                    {
                        return array[i];
                    }
                }
                else
                {
                    if(array[i] >= array[i-1] && array[i] >= array[i+1])
                    {
                        return array[i];
                    }
                }                
            }

            return -1;
        }


        private static int FindPeak(int[] array, int startIndex, int endIndex)
        {
            // base case.
            if(endIndex == startIndex)
            {
                return array[startIndex];
            }

            int midIndex = (startIndex + endIndex) / 2;
            if((midIndex == 0 || array[midIndex-1] <= array[midIndex]) 
                && (midIndex == array.Length -1 || array[midIndex] >= array[midIndex + 1]))
            {
                return array[midIndex];
            }

            if (midIndex > 0 && array[midIndex - 1] > array[midIndex])
            {
                return FindPeak(array, startIndex, midIndex - 1);
            }
            else
            {
                return FindPeak(array, midIndex + 1, endIndex);
            }     
        }
    }
}
