using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms
{
    public class InsertionSortAlgorithm
    {
        public static void Main1(string[] args)
        {
            int[] array = { 10, 5, 3, 8, 16, 2 };
            InsertionSort(array);
            Console.WriteLine(string.Join(",", array));

            int[] newArr = { 5, 3, 20, 16, 4, 5, 6 ,2,7,1, -1,-1};
            BinaryInsertionSort(newArr);
            Console.WriteLine(string.Join(",", newArr));
        }

        public  static void InsertionSort(int[] array)
        {
            if(array.Length <= 1)
            {
                return;
            }

            for(int index = 1; index < array.Length; index++)
            {
                for(int reverseIndex = index; reverseIndex > 0; reverseIndex--)
                {
                    if(array[reverseIndex] < array[reverseIndex - 1])
                    {
                        int temp = array[reverseIndex];
                        array[reverseIndex] = array[reverseIndex - 1];
                        array[reverseIndex - 1] = temp;
                    }
                }
            }            
        }        

        public static void BinaryInsertionSort(int[] array)
        {
            if(array.Length <= 1)
            {
                return;
            }

            for(int index = 1; index < array.Length; index++)
            {
                if (array[index] < array[index - 1])
                {
                    int val = array[index];
                    int shiftLoc = BinarySearch(array, 0, index, val);
                    int value = array[index];
                    for(int i = index; i > shiftLoc; i--)
                    {
                        int temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                    }

                    array[shiftLoc] = value;
                }
            }
        }

        private static int BinarySearch(int[] array,int start, int end, int value)
        {
            if(end <= start)
            {
                return array[start] <= value ? start + 1 : start; 
            }

            int midIndex = (start + end) / 2;
            if(array[midIndex] > value)
            {
                return BinarySearch(array, start, midIndex - 1, value);
            }

            if(array[midIndex] < value)
            {
                return BinarySearch(array, midIndex + 1, end, value);
            }

            return midIndex;
        }        
    }
}
