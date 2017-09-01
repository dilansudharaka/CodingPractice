using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice
{
    public class BinaryTree
    {
        public BinaryTree(int val)
        {
            this.Value = val;
        }

        public BinaryTree Left { get; private set; }
        public BinaryTree Right { get; private set; }
        public int Value { get; private set; }

        public void Add(int value)
        {
            if (value >= this.Value)
            {
                if (this.Left != null)
                {
                    this.Left.Add(value);
                }
                else
                {
                    this.Left = new BinaryTree(value);
                }
            }
            else
            {
                if (this.Right != null)
                {
                    this.Right.Add(value);
                }
                else
                {
                    this.Right = new BinaryTree(value);
                }
            }
        }

        public static BinaryTree CreateFromList(List<int> inputArray)
        {
            if (inputArray == null || inputArray.Count() == 0)
            {
                throw new ArgumentNullException("inputArray");
            }

            BinaryTree head = new BinaryTree(inputArray[0]);
            for (int i = 1; i < inputArray.Count(); i++)
            {
                head.Add(inputArray[i]);
            }

            return head;
        }

        public static void InOrderTraversal(BinaryTree root)
        {
            if (root == null)
            {
                throw new ArgumentNullException("root");
            }

            Queue<BinaryTree> treeQueue = new Queue<BinaryTree>();
        }

        #region RemoveHalfNodes
        /// <summary>
        /// http://www.geeksforgeeks.org/given-a-binary-tree-how-do-you-remove-all-the-half-nodes/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static BinaryTree RemoveHalfNodes(BinaryTree root)
        {
            if (root == null)
            {
                return null;
            }

            root.Left = RemoveHalfNodes(root.Left);
            root.Right = RemoveHalfNodes(root.Right);

            if ((root.Left == null && root.Right == null)
            || (root.Left != null && root.Right != null))
            {
                return root;
            }
            else if (root.Left == null)
            {
                return root.Right;
            }
            else return root.Left;
        }
        #endregion

#region Get Kth Largest
        public static void GetKthLargestElement(BinaryTree root, ref int k)
        {
            if (root == null || k < 0)
            {
                return;
            }

            if (root.Left != null)
            {
                GetKthLargestElement(root.Left, ref k);
            }

            if (--k == 0)
            {
                Console.WriteLine(root.Value);
                return;
            }

            if (root.Right != null)
            {
                GetKthLargestElement(root.Right, ref k);
            }
        }
        #endregion;
    }
}
