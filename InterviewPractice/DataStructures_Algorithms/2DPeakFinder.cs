using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms
{
    public class _2DPeakFinder
    {
        public static void Main(string[] args)
        {
            int[,] arr = { { 10, 13, 30, 40, 68 }};
            Console.WriteLine(Find2DPeak(arr));

            arr = new int[,]{ { 10, 13, 30, 40, 68 },
                     { 12, 18, 16, 39, 36 },
                           { 54, 16, 12, 28 , 29},
                           { 10, 8, 14, 10, 70 }
            };
            Console.WriteLine(Find2DPeak(arr));
        }

        private static int Find2DPeak(int[,] array)
        {
            if (array == null)
                throw new Exception("");

            return Find2DPeakRecursive(array, 0, array.GetLength(1) - 1);
        }

        private static int Find2DPeakRecursive(int[,] array, int startColIndex, int endColIndex)
        {
            int columnCount = endColIndex - startColIndex + 1;
            int midColumnIndex = (endColIndex + startColIndex) / 2;

            int maxValueRowIndex = FindMaxValueRowIndex(array, midColumnIndex);
            if (columnCount == 1)
            {
                return array[maxValueRowIndex, midColumnIndex];
            }

            if (array[maxValueRowIndex, midColumnIndex + 1] > array[maxValueRowIndex, midColumnIndex])
            {
                return Find2DPeakRecursive(array, midColumnIndex + 1, endColIndex);
            }

            if (array[maxValueRowIndex, midColumnIndex - 1] > array[maxValueRowIndex, midColumnIndex])
            {
                return Find2DPeakRecursive(array, startColIndex, midColumnIndex - 1);
            }

            return array[maxValueRowIndex, midColumnIndex];
        }

        private static int FindMaxValueRowIndex(int[,] array, int midColumn)
        {
            int maxValRowIndex = 0;
            int maxValue = array[0, midColumn];

            for (int i = 1; i < array.GetLength(0); i++)
            {
                if (array[i, midColumn] > maxValue)
                {
                    maxValue = array[i, midColumn];
                    maxValRowIndex = i;
                }
            }

            return maxValRowIndex;
        }
    }
}
