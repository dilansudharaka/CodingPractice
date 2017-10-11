using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms
{
    public class HeapSortAlgorithm
    {
        public static void Main(string[] args)
        {
            int[] arr = { 2, 3, 10, 4, -1, 6, 3, 1, 0, 100 };
            HeapSort(arr);
            Console.WriteLine(string.Join(",", arr));
        }
        private static void HeapSort(int[] array)
        {
            if(array.Length <= 1)
            {
                return;
            }

            for(int i = (array.Length - 1)/2; i >= 0; i--)
            {
                Heapify(array, i, array.Length);
            }

            int heapSize = array.Length;
            for(int i=array.Length - 1; i > 0; i--)
            {
                int temp = array[i];
                array[i] = array[0];
                array[0] = temp;

                Heapify(array, 0, --heapSize);
            }
        }

        private static void Heapify(int[] array, int index, int heapSize)
        {
            int leftchildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            if(leftchildIndex >= heapSize)
            {
                return;
            }

            int largestChildIndex = leftchildIndex;
            if(rightChildIndex < heapSize)
            {
                largestChildIndex = array[leftchildIndex] > array[rightChildIndex] ? leftchildIndex : rightChildIndex;
            }

            
            if(array[index] < array[largestChildIndex])
            {
                int temp = array[index];
                array[index] = array[largestChildIndex];
                array[largestChildIndex] = temp;

                Heapify(array, largestChildIndex, heapSize);
            }            
        }
    }
}
