using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice
{
    class StringManipulations
    {
        #region StringPemution.
        public static void DisplayPermutaions(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            int startIndex = 0;
            char[] inputArray = input.ToCharArray();
            DisplayPermutationRecursive(inputArray, startIndex);
        }

        private static void DisplayPermutationRecursive(char[] input, int startIndex)
        {
            if (startIndex < 0 || startIndex >= input.Length)
            {
                throw new ArgumentOutOfRangeException("startIndex", "should be  0 <= starIndex < input.Length");
            }

            if (startIndex == input.Length - 1)
            {
                Console.WriteLine(input);
                return;
            }

            for (int currentIndex = startIndex; currentIndex < input.Length; currentIndex++)
            {
                Swap(input, currentIndex, startIndex);
                DisplayPermutationRecursive(input, startIndex + 1);
                Swap(input, currentIndex, startIndex);
            }
        }

        private static void Swap(char[] input, int firstIndex, int secondIndex)
        {
            char temp = input[firstIndex];
            input[firstIndex] = input[secondIndex];
            input[secondIndex] = temp;
        }
        #endregion

        #region Traverse 2D string Array. AKA: Boggle

        public static void DisplayAllStringsIn2DArray(char[,] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException("inputArray");
            }

            if (inputArray.Length == 0)
            {
                return;
            }

            bool[,] traversedArr = new bool[inputArray.GetLength(0), inputArray.GetLength(1)];
            StringBuilder prefix = new StringBuilder();
            for (int i = 0; i < inputArray.GetLength(0); i++)
            {
                for (int j = 0; j < inputArray.GetLength(1); j++)
                {
                    DisplayAllStringIn2DArrayRecursive(inputArray, traversedArr, i, j, prefix);
                }
            }

        }

        private static void DisplayAllStringIn2DArrayRecursive(char[,] inputArray, bool[,] travesedArr, int ithIndex, int jthIndex, StringBuilder prefix)
        {
            prefix.Append(inputArray[ithIndex, jthIndex]);
            Console.WriteLine(prefix.ToString());

            travesedArr[ithIndex, jthIndex] = true;
            for (int i = ithIndex - 1; i <= ithIndex + 1 && i < inputArray.GetLength(0); i++)
            {
                for (int j = jthIndex - 1; j <= jthIndex + 1 && j < inputArray.GetLength(1); j++)
                {
                    if (i >= 0 && j >= 0 && !travesedArr[i, j])
                    {
                        DisplayAllStringIn2DArrayRecursive(inputArray, travesedArr, i, j, prefix);
                    }
                }
            }

            prefix.Remove(prefix.Length - 1, 1);
            travesedArr[ithIndex, jthIndex] = false;
        }

        #endregion

        #region Display all Possible Palindroms
        public static void DisplayAllPossiblePalindromePartitions(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            List<List<string>> partitions = DoPartitionRecursion(input, 0);
        }

        private static List<List<string>> DoPartitionRecursion(string input, int index)
        {
            List<List<string>> allpartitions = new List<List<string>>();
            if (index == input.Length - 1)
            {
                allpartitions.Add(new List<string>() { input[index].ToString() });
                return allpartitions;
            }

            for (int i = index; i < input.Length; i++)
            {
                string left = input.Substring(index, i - index + 1);
                if (IsPalindrome(left))
                {
                    List<List<string>> subPartitions = DoPartitionRecursion(input, i + 1);
                    foreach (List<string> partition in subPartitions)
                    {
                        List<string> newPartition = new List<string>() { left };
                        newPartition.AddRange(partition);
                        allpartitions.Add(newPartition);
                    }
                }
            }

            return allpartitions;
        }

        private static bool IsPalindrome(string input)
        {
            int start = 0;
            int end = input.Length - 1;
            while (start <= end)
            {
                if (input[start++] != input[end--])
                {
                    return false;
                }
            }

            return true;
        }


        #endregion

        #region MinimumOperationCountToTransform
        public static int GetTransformCount(string input, string output)
        {
            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(output))
            {
                throw new ArgumentException(input);
            }

            if (input.Length != output.Length)
            {
                Console.WriteLine("Cannot transform");
            }

            int[] charCountArray = new int[256];
            for (int i = 0; i < input.Length; i++)
            {
                charCountArray[input[i]]++;
            }

            for (int i = 0; i < input.Length; i++)
            {
                charCountArray[output[i]]--;
            }

            for (int i = 0; i < charCountArray.Length; i++)
            {
                if (charCountArray[i] != 0)
                {
                    return -1;
                }
            }

            int indexA = input.Length - 1;
            int indexB = output.Length - 1;
            int operationCount = 0;
            while (indexA > 0 && input[indexA] != output[indexB])
            {
                while (indexA > 0)
                {
                    operationCount++;
                    indexA--;
                }

                indexA--;
                indexB--;
            }


            return operationCount;
        }
        #endregion

        #region RemoveNonSpaceCharacters
        public static void RemoveNonSpaceCharacters(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            char[] charArray = input.ToCharArray();
            int nonSpaceCharIndex = 0;
            for (int i = 0; i < charArray.Length; i++)
            {
                if (input[i] != ' ')
                {
                    charArray[nonSpaceCharIndex++] = input[i];
                }
            }

            Console.WriteLine(charArray.ToString()); ;
        }
        #endregion

        #region GetLongestSubstingWithoutRepeatingChars
        /// <summary>
        /// Length of the longest substring without repeating characters.
        /// http://www.geeksforgeeks.org/length-of-the-longest-substring-without-repeating-characters/
        /// </summary>
        /// <returns></returns>
        public static int GetTheLengthOfTheLongestSubstringWithoutRepeatingCharcters(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            if (input.Length == 1)
            {
                return 1;
            }

            int currentLength = 1;
            int maxLength = 1;
            int maxChars = 256;
            int[] charIndexArray = new int[maxChars];

            for (int i = 0; i < maxChars; i++)
            {
                charIndexArray[i] = -1;
            }

            charIndexArray[input[0]] = 0;
            for (int i = 1; i < input.Length; i++)
            {
                int previousIndex = charIndexArray[input[i]];
                if (previousIndex == -1 || i - currentLength > previousIndex)
                {
                    currentLength++;
                    charIndexArray[input[i]] = i;
                }
                else
                {
                    if (maxLength < currentLength)
                    {
                        maxLength = currentLength;
                    }

                    currentLength = i - previousIndex;
                    charIndexArray[input[i]] = i;
                }
            }

            return maxLength;
        }
        #endregion

        #region FindTheLongestSubstringWithKUniqueCharacters
        public static string LongestStringWithKuniqueChars(string input, int k)
        {
            if (string.IsNullOrEmpty(input) || input.Length < k)
            {
                return null;
            }
            if (k <= 0)
            {
                return null;
            }

            int startIndex = 0;
            int uniqueCount = 0;
            StringBuilder currentString = new StringBuilder();
            string maxString = string.Empty;
            int[] charCountArray = new int[256];

            for (int i = 0; i < input.Length; i++)
            {
                if (charCountArray[input[i]] == 0)
                {
                    uniqueCount++;
                }

                charCountArray[input[i]]++;
                if (uniqueCount <= k)
                {
                    currentString.Append(input[i]);
                }
                else
                {
                    if (currentString.Length > maxString.Length)
                    {
                        maxString = currentString.ToString();
                    }
                    currentString.Append(input[i]);

                    while (true)
                    {
                        charCountArray[input[startIndex]]--;
                        currentString.Remove(0, 1);
                        if (charCountArray[input[startIndex++]] == 0)
                        {
                            uniqueCount--;
                            break;
                        }
                    }
                }
            }

            if (uniqueCount < k)
            {
                return null;
            }

            if (currentString.Length > maxString.Length)
            {
                maxString = currentString.ToString();
            }

            return maxString;
        }
        #endregion

        #region FindMaxDepthOfNestedParanthesis
        public static int FindMaxDepthOfNestedParanthesis_Sol1(string input)
        {
            Stack<char> charStack = new Stack<char>();
            int currentCount = 0;
            int maxCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    charStack.Push(input[i]);
                    if (currentCount > 0)
                    {
                        if (maxCount < currentCount)
                        {
                            maxCount = currentCount;
                        }

                        currentCount = 0;
                    }
                }
                else if (input[i] == ')')
                {
                    if (charStack.Count > 0)
                    {
                        char prev = charStack.Pop();
                        if (prev == '(')
                        {
                            currentCount++;
                        }
                    }
                }
            }

            if (charStack.Count > 0)
                return -1;

            if (currentCount > maxCount)
                maxCount = currentCount;

            return maxCount;
        }
        #endregion

        #region FindLongestPalindromicSubString
        /// <summary>
        /// http://www.geeksforgeeks.org/longest-palindromic-substring-set-2/
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetLongestPalindromicSubstring(string input)
        {
            int low = 0;
            int high = 1;
            int maxLength = 1;
            int start = 0;

            for (int i = 1; i < input.Length; i++)
            {
                low = i - 1;
                high = i;
                while (low >= 0 && high < input.Length && input[low] == input[high])
                {
                    int currentLength = high - low + 1;
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        start = low;
                    }

                    low--;
                    high++;
                }

                low = i - 1;
                high = i + 1;
                while (low >= 0 && high < input.Length && input[low] == input[high])
                {
                    int currentLength = high - low + 1;
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        start = low;
                    }

                    low--; high++;
                }
            }

            return input.Substring(start, maxLength);
        }
        #endregion

        #region PrintallPossibleStringsMadeUsingSpaces
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public static void PrintAllPossibleStringMadeUsingSpaces(string input)
        {
            if (input.Length == 0)
            {
                return;
            }

            List<string> allPossibleStrings = GetAllPossibleStringsRecursive(input, 0);
            foreach (var str in allPossibleStrings)
            {
                Console.WriteLine(str);
            }
        }

        private static List<string> GetAllPossibleStringsRecursive(string input, int currentIndex)
        {
            if (currentIndex == input.Length - 1)
            {
                return new List<string>() { input[currentIndex].ToString() };
            }

            List<string> subStrings = GetAllPossibleStringsRecursive(input, currentIndex + 1);
            List<string> finalStrings = new List<string>();
            foreach (string subString in subStrings)
            {
                finalStrings.Add(input[currentIndex] + subString);
                finalStrings.Add(input[currentIndex] + " " + subString);
            }

            return finalStrings;
        }
        #endregion
    }
}
