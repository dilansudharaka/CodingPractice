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
            int x = Convert.ToInt32("11011", 2);
            int count = 0;
            while(x > 0)
            {
                x = x & (x - 1);
                count++;
            }

            //StringOperations.Go();
            //ArrayOperations.Go();
            // LinkListOperations.Go();
            TreeOperations.Go();
        }

        private class TreeOperations
        {
            public static void Go()
            {
                BinaryTree binaryTree = BinaryTree.CreateFromList(new List<int> { 10, 20, 5, 2, 100, 70, 34 });
                int k = 3;
                BinaryTree.GetKthLargestElement(binaryTree, ref k);
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

                //StringManipulations.PrintAllPossibleStringMadeUsingSpaces("ABCD");

                // StringManipulations.PrintAllPermutationsOfSmallerString("abbc", "cbabadcbbabbcbabaabccbabc");

                StringManipulations.ConverToHex("Hello World");
            }
        }

        private class LinkListOperations
        {
            public static void Go()
            {
                //ListNode<int> root = Linklist<int>.CreateListUsingArray(new List<int> { 1, 2, 3, 4,5 });

                ////Linklist.ReverseList(ref root);
                //Linklist<int>.RemapToEnd(root);
                //Linklist<int>.DisplayList(root);

                ListNode<int> root = Linklist<int>.CreateListUsingArray(new List<int> { 10,40,52,30,67,12,89 });
                ListNode<int> newRoot = Linklist<int>.Rearrange(root);
                Linklist<int>.DisplayList(newRoot);
            }
        }

        private class ArrayOperations
        {
            public static void Go()
            {
                // Array.FindFourElementsMatchesTheSum(new int[] { 3, 4, 7, 1, 12, 9 });

                // Array.FindLongestPathInmatrix(new int[,] { { 1, 2, 9 }, { 5, 3, 8 }, { 4, 6, 7 } });

                // Array.MaxSumWhileRotating(new int[] { 10, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

                // Array.FindSymmetricPair_2(new int[,] { { 11, 20 }, { 30, 40 }, { 5, 10 }, { 40, 30 }, { 10, 5 } });//

                //Array.FindMaxSubArrayWithKLength(new int[] { 1, 12, -5, -6, 50, 3 }, 4);

               // Array.QuickSort(new int[] { 10, 7, 8, 9, 1, 5 });

               // Array.QuickSortIterative(new int[] { 10, 7, 8, 9, 1, 5 }, 0, 5);

                //Array.MergeSort(new int[] { 12, 11, 13, 5, 6, 7 });

               // Array.MergeSortIterative(new int[] { 12, 11, 13, 5, 6, 7 });

                Array.IsValueFoundInSortedArray(new int[,] { { 1, 3, 5 }, { 7, 9, 11 }, { 13, 15, 17 } }, 17);
            }
        }
    }
}
