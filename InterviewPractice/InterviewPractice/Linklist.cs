using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice
{
    public class Linklist<T> where T :IComparable
    {
        public static ListNode<T> CreateListUsingArray(List<T> input)
        {
            ListNode<T> root = new ListNode<T> { Value = input[0] };
            ListNode<T> temp = root;
            for(int i=1; i< input.Count; i++)
            {
                temp.Next = new ListNode<T> { Value = input[i] };
                temp = temp.Next;
            }

            return root;
        }

        public static void DisplayList (ListNode<T> root)
        {
            Console.Write("{0}", root.Value);
            root = root.Next;
            while (root != null)
            {
                Console.Write("-> {0}", root.Value);
                root = root.Next;
            }
        }

       # region Rearrange a given linked list in-place
        /// http://www.geeksforgeeks.org/rearrange-a-given-linked-list-in-place/
        public static ListNode<T> RemapToEnd(ListNode<T> root)
        {
            ListNode<T> slow = root;
            ListNode<T> fast = slow.Next;
            while( fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }

            ListNode<T> end = slow.Next;
            ReverseList(ref end);
            slow.Next = null;

            ListNode<T> firstHalf = root;
            ListNode<T> reversedSecondHalf = end;
            ListNode<T> temp = null;
            while(firstHalf != null && reversedSecondHalf != null)
            {
                temp = reversedSecondHalf.Next;
                reversedSecondHalf.Next = firstHalf.Next;
                firstHalf.Next = reversedSecondHalf;
                firstHalf = reversedSecondHalf.Next;
                reversedSecondHalf = temp;
                
            }

            return root;
        }
        #endregion

        #region Sort a linked list that is sorted alternating ascending and descending orders?
        public static ListNode<T> Rearrange(ListNode<T> root)
        {
            ListNode<T> firstRoot = root;
            ListNode<T> secondRoot = root.Next;

            ListNode<T> firstTemp = firstRoot;
            ListNode<T> secondTemp = secondRoot;

            while(firstTemp != null && firstTemp.Next != null && secondTemp != null && secondTemp.Next != null)
            {
                firstTemp.Next = secondTemp.Next;
                firstTemp = firstTemp.Next;
                secondTemp.Next = firstTemp.Next;
                secondTemp = secondTemp.Next;                
            }

            ReverseList(ref secondRoot);
            return MergeTwoSortedLinklists(firstRoot, secondRoot);            
        }

        private static ListNode<T> MergeTwoSortedLinklists(ListNode<T> first, ListNode<T> second)
        {
            if(first == null)
            {
                return second;
            }

            if(second == null)
            {
                return first;
            }

            ListNode<T> newRoot = null;
            ListNode<T> firstTemp = first;
            ListNode<T> secondTemp = second;
            if(firstTemp.Value.CompareTo(secondTemp.Value) <= 0)
            {
                newRoot = firstTemp;
                firstTemp = firstTemp.Next;
            }
            else
            {
                newRoot = secondTemp;
                secondTemp = secondTemp.Next;
            }

            ListNode<T> temp = newRoot;

            while (firstTemp != null && secondTemp != null)
            {
                if(firstTemp.Value.CompareTo(secondTemp.Value) <= 0)
                {
                    temp.Next = firstTemp;
                    firstTemp = firstTemp.Next;                    
                }
                else
                {
                    temp.Next = secondTemp;
                    secondTemp = secondTemp.Next;
                }

                temp = temp.Next;
            }

            if(firstTemp != null)
            {
                temp.Next = firstTemp;
            }
            else if(secondTemp != null)
            {
                temp.Next = secondTemp;
            }

            return newRoot;
        }

        #endregion

        public static void ReverseList(ref ListNode<T> root)
        {
            ListNode<T> prev = null, current, next;
            current = root;

            while(current != null)
            {
                next = current.Next;
                current.Next = prev;                
                prev = current;
                current = next;
            }

            root = prev;
        }

        public static void PartitionOverX(ListNode<T> root, T x)
        {
            if(root == null)
            {
                return;
            }

            ListNode<T> tail = root;
            while(tail != null && tail.Next != null)
            {
                tail = tail.Next;
            }

            ListNode<T> current = root;
            ListNode<T> prev = null;
            while(current != null && current.Next != null)
            {
                if(current.Value.CompareTo(x) >= 0)
                {
                    if(current == root)
                    {
                        root = current.Next;
                        tail.Next = current;
                        current.Next = null;
                        current = root;
                        tail = tail.Next;                    
                    }
                    else
                    {
                        prev.Next = current.Next;
                        tail.Next = current;
                        tail = tail.Next;
                        current.Next = null;
                        current = prev.Next;
                    }
                }
                else
                {
                    prev = current;
                    current = current.Next;
                }
            }
        }

        #region Convert BST into DLL
        private static ListNode<int> ConvertBSTintoDLLRecursive(BinaryTree root)
        {
            if (root == null)
            {
                return null;
            }

            ListNode<int> temp = new ListNode<int>(root.Value);
            if (root.Left != null)
            {
                ListNode<int> leftDLL = ConvertBSTintoDLLRecursive(root.Left);
                if (leftDLL != null)
                {
                    leftDLL.Next = temp;
                }

                temp.Previous = leftDLL;
            }

            if (root.Right != null)
            {
                ListNode<int> rightDLL = ConvertBSTintoDLLRecursive(root.Right);
                temp.Next = rightDLL;
                if (rightDLL != null)
                {
                    rightDLL.Previous = temp;
                }

            }

            return temp;
        }
        #endregion
    }
}
