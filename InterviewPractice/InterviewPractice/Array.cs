using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice
{
    class Array
    {
        #region FindFourElement with A+B = C+D
        /// <summary>
        /// http://www.geeksforgeeks.org/find-four-elements-a-b-c-and-d-in-an-array-such-that-ab-cd/
        /// </summary>
        /// <param name="intArray"></param>
        public static void FindFourElementsMatchesTheSum(int[] intArray)
        {
            if(intArray.Length < 4)
            {
                return;
            }

            Dictionary<int, int[]> sumAndIndexes = new Dictionary<int, int[]>();
            for(int i =0; i< intArray.Length; i++)
            {
                for(int j = i+1; j< intArray.Length; j++)
                {
                    int sum = intArray[i] + intArray[j];
                    if(sumAndIndexes.ContainsKey(sum))
                    {
                        Console.WriteLine("{0} + {1} = {2} + {3}",
                            sumAndIndexes[sum][0],
                            sumAndIndexes[sum][1],
                            intArray[i],
                            intArray[j]);
                        return;
                    }

                    sumAndIndexes.Add(sum, new int[] { intArray[i], intArray[j] });                    
                }
            }
        }
        #endregion

        #region Find the longest path in a matrix with given constraints
        /// <summary>
        /// http://www.geeksforgeeks.org/find-the-longest-path-in-a-matrix-with-given-constraints/
        /// </summary>
        /// <param name="input"></param>
        public static void FindLongestPathInmatrix(int[,] input)
        {
            string currentPath = string.Empty;
            bool[,] visitedNodes = new bool[input.GetLength(0), input.GetLength(1)];
            for(int i=0; i< input.GetLength(0); i++)
            {
                for(int j=0; j< input.GetLength(1); j++)
                {
                    string path = FindLongestPathInmatrixRecursive(input, visitedNodes, i, j, input[i,j].ToString());
                    if(currentPath.Length < path.Length)
                    {
                        currentPath = path;
                    }
                }
            }

            Console.WriteLine(currentPath);
        }

        private static string FindLongestPathInmatrixRecursive(
            int[,] input,
            bool[,] visited,
            int ith,
            int jth,
            string currentPath)
        {

            visited[ith, jth] = true;
            int currentVal = input[ith, jth];
            string maxPath = currentPath;

            string str1 = currentPath;
            string str2 = currentPath;
            string str3 = currentPath;
            string str4 = currentPath;

            if(ith-1 >= 0 && input[ith-1, jth] == currentVal + 1 && !visited[ith-1, jth])
            {
                str1 = FindLongestPathInmatrixRecursive(input, visited, ith - 1, jth, currentPath + input[ith - 1, jth]);
            }

            if (ith + 1 < input.GetLength(0) && input[ith + 1, jth] == currentVal + 1 && !visited[ith + 1, jth])
            {
                str2 = FindLongestPathInmatrixRecursive(input, visited, ith + 1, jth, currentPath + input[ith + 1, jth]);
            }

            if(jth - 1 >=0 && input[ith, jth-1] == currentVal + 1 && !visited[ith, jth - 1])
            {
                str3 = FindLongestPathInmatrixRecursive(input, visited, ith, jth - 1, currentPath + input[ith, jth - 1]);
            }

            if (jth + 1 < input.GetLength(1) && input[ith, jth + 1] == currentVal + 1 && !visited[ith, jth + 1])
            {
                str3 = FindLongestPathInmatrixRecursive(input, visited, ith, jth + 1, currentPath + input[ith, jth + 1]);
            }

            if (str1.Length > maxPath.Length)
                maxPath = str1;
            if (str2.Length > maxPath.Length)
                maxPath = str2;
            if (str3.Length > maxPath.Length)
                maxPath = str3;
            if (str4.Length > maxPath.Length)
                maxPath = str4;

            visited[ith, jth] = false;
            return maxPath;                   
                        
        }

        #endregion

        #region Find maximum value of Sum( i*arr[i]) with only rotations on given array allowed
        /// <summary>
        /// http://www.geeksforgeeks.org/find-maximum-value-of-sum-iarri-with-only-rotations-on-given-array-allowed/
        /// Rj-Rj-1 = Sum - N * arr[N-j]
        /// </summary>
        /// <param name="input"></param>
        public static void MaxSumWhileRotating(int[] input)
        {
            int sum = 0;
            int r0 = 0;
            for(int i=0; i< input.Length; i++)
            {
                r0 = r0 + i * input[i];
                sum += input[i];
            }

            int currentMax = r0;
            int current = r0;
            for(int i=1; i< input.Length-1; i++)
            {
                current = current + sum - input.Length * input[input.Length - i];
                if (current > currentMax)
                {
                    currentMax = current;
                }
            }

            Console.WriteLine(currentMax);
        }
        #endregion

        #region Given an array of pairs, find all symmetric pairs in it - Method1
        public static void FindSymmetricPair_1(int[,] input)
        {
            // Sort by first value 
            // foreach, search the second value, in the first values using binary search.
            // Complexity is nlogN.
        }

        public static void FindSymmetricPair_2(int[,] input)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            for(int i=0; i< input.GetLength(0); i++)
            {
                int first = input[i, 0];
                int second = input[i, 1];
                if(dictionary.ContainsKey(second))
                {
                    if(dictionary[second] == first)
                    {
                        Console.WriteLine("Symmetric pairs are:{0},{1} & {1},{0}", first, second);
                        return;
                    }
                }

                dictionary.Add(first, second);
            }
        }
        #endregion

        #region Find the largest subarray with 0 sum
        public static void FindLargestSubArrayWithSum0(int[] input)
        {
            int startIndex = 0;
            int Maxlength = 0;
            Dictionary<int, int> sumDictionary = new Dictionary<int, int>();
            int sum = 0;
            int currentLength = 0;
            for(int i=0; i< input.Length; i++)
            {
                sum += input[i];
                if(i== 0 && input[i] == 0)
                {
                    startIndex = 0;
                    currentLength = 1;
                }

                if(sum == 0)
                {
                    currentLength = i + 1;
                    if(currentLength > Maxlength)
                    {
                        Maxlength = currentLength;
                    }
                }

                else if(sumDictionary.ContainsKey(sum))
                {
                    int previousIndex = sumDictionary[sum] + 1;
                    currentLength = i - previousIndex + 1 ;
                    if(Maxlength < currentLength)
                    {
                        startIndex = previousIndex;
                        Maxlength = currentLength;
                    }
                }
                else
                {
                    sumDictionary.Add(sum, i);
                }
            }

            Console.WriteLine("Elements are ");
            for (int i = startIndex, j = 1; j < Maxlength; j++)
            {
                Console.Write(input[i++] + ",");
            }
        }
        #endregion

        #region Find maximum average subarray of k length
        public static void FindMaxSubArrayWithKLength(int[] array, int k)
        {
            int[] newArray = new int[array.Length - k + 1];
            int sum = 0;
            for(int i=0; i< array.Length; i++)
            {
                sum += array[i];
                if(i >= k -1 )
                {
                    if(i-k >= 0)
                    {
                        sum -= array[i - k];
                    }
                    
                    newArray[i - k + 1] = sum;
                }
            }

            int startIndex = 0;
            int currentMaxSum = newArray[0];
            for(int i=1; i< newArray.Length; i++)
            {
                if(newArray[i] > currentMaxSum)
                {
                    currentMaxSum = newArray[i];
                    startIndex = i;
                }
            }

            for(int i= startIndex; i< startIndex + k; i++)
            {
                Console.Write(array[i] + ", ");
            }
        }
        #endregion
    }
}
