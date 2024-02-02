using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp19
{
    public class ListNode<T>
    {
        private T value;
        private ListNode<T> nextValue;
        public T Value { get { return value; } set { this.value = value; } }
        public ListNode <T> NextValue { get { return nextValue; } set { nextValue = value; } }
        public ListNode(T value)
        {
            this.value = value;
        }
    }
}