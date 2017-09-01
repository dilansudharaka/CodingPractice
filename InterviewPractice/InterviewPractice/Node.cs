using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice
{
    public class ListNode<T> where T :IComparable
    {
        public ListNode<T> Next { get; set; }

        public ListNode<T> Previous { get; set; }
        public T Value { get; set; }

        public ListNode()
        {
        }

        public ListNode(T value)
        {
            ListNode<T> temp = new ListNode<T>();
            temp.Value = value;            
        }
    }


}
