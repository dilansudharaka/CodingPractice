using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms
{
    public class MergeSortAlgorithm
    {
        public static void Main1(string[] args)
        {
            int[] arr = { 2, 3, 100, 4, 8, 30, 45, 23, 12, -1, 6 };
            int[] modified = MergeSort(arr);
            Console.WriteLine(string.Join(",", modified));
        }
       
        private static int[] MergeSort(int[] array)
        {
            if(array.Length <= 1)
            {
                return array;
            }

            int leftCount = array.Length / 2;
            int rightCount = array.Length - leftCount;
            int[] leftArray = new int[leftCount];
            int[] rightArray = new int[rightCount];

            for(int i=0, leftIndex = 0, rightIndex =0; i< array.Length; i++)
            {
                if(i < leftCount)
                {
                    leftArray[leftIndex++] = array[i];
                }
                else
                {
                    rightArray[rightIndex++] = array[i];
                }
            }

          //  MergeSort(leftArray);
         //   MergeSort(rightArray);
            return Merge(MergeSort(leftArray), MergeSort(rightArray));
        }

        private static int[] Merge(int[] leftArray, int[] rightArray)
        {
            int totalLength = leftArray.Length + rightArray.Length;
            int[] newArr = new int[totalLength];

            int leftIndex = 0;
            int rightIndex = 0;
            int index = 0;
            for(; index < totalLength && leftIndex < leftArray.Length && rightIndex < rightArray.Length; index++)
            {
                if(leftArray[leftIndex] < rightArray[rightIndex])
                {
                    newArr[index] = leftArray[leftIndex++];
                }
                else
                {
                    newArr[index] = rightArray[rightIndex++];
                }
            }

            if(leftIndex < leftArray.Length)
            {
                while (index < totalLength)
                {
                    newArr[index++] = leftArray[leftIndex++];
                }

                return newArr;
            }

            if(rightIndex < rightArray.Length)
            {
                while(index < totalLength)
                {
                    newArr[index++] = rightArray[rightIndex++];
                }
            }

            return newArr;
            
        }
    }
}
