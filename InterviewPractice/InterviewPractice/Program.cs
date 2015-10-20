using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringOperations.Go();
            ArrayOperations.Go();
        }

        private class TreeOperations
        {
            public static void Go()
            {
                BinaryTree binaryTree = BinaryTree.CreateFromList(new List<int> { 10, 20, 5, 2, 100, 70, 34 });

            }
        }
        private class StringOperations
        {

            public static void Go()
            {
                // StringManipulations.DisplayPermutaions("ABCD");

                // char[,] inputArray = { { 'a', 'b', 'c'}, {'0', 'd','0' }, {'e', 'f', '0' } };
                // StringManipulations.DisplayAllStringsIn2DArray(inputArray);

                //StringManipulations.DisplayAllPossiblePalindromePartitions("nitin");

                // StringManipulations.GetTransformCount("EACBD", "EABCD");

                //StringManipulations.GetTheLengthOfTheLongestSubstringWithoutRepeatingCharcters("GEEKSFORGEEKS");

                // string longestSubString = StringManipulations.LongestStringWithKuniqueChars("aabacbebebe", 3);

                //int maxbracketCount = StringManipulations.FindMaxDepthOfNestedParanthesis_Sol1("( ((X)) (((Y))) )");

                //string longestPalindrome = StringManipulations.GetLongestPalindromicSubstring("forgeeksskeegfor");

                StringManipulations.PrintAllPossibleStringMadeUsingSpaces("ABCD");
            }
        }

        private class ArrayOperations
        {
            public static void Go()
            {
                // Array.FindFourElementsMatchesTheSum(new int[] { 3, 4, 7, 1, 12, 9 });

                // Array.FindLongestPathInmatrix(new int[,] { { 1, 2, 9 }, { 5, 3, 8 }, { 4, 6, 7 } });

                // Array.MaxSumWhileRotating(new int[] { 10, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

                Array.FindSymmetricPair_2(new int[,] { { 11, 20 }, { 30, 40 }, { 5, 10 }, { 40, 30 }, { 10, 5 } });//
            }
        }
    }
}
