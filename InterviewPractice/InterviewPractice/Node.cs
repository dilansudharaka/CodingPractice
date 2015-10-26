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
        public T Value { get; set; }
    }


}
