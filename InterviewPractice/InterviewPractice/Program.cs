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
            StringOperations.Go();
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
    }
}
