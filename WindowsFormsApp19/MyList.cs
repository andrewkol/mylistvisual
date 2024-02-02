using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp19
{
    public class MyList<T> : IEnumerable<T>
    {
        private int count;
        private ListNode<T> first;
        private ListNode<T> last;
        public int Count { get { return count; } }
        public void Add(T itemToAdd)
        {
            ListNode<T> base_node = new ListNode<T>(itemToAdd);
            if (first == null)
            {
                first = base_node;
                last = base_node;
            }
            else
            {
                last.NextValue = base_node;
                last = base_node;
            }
            count++;
        }
        public int Add(T itemToAdd, int positionToAdd)
        {
            if (positionToAdd > count - 1 || positionToAdd < 0)
                return -1;
            ListNode<T> base_node = new ListNode<T>(itemToAdd);
            if (positionToAdd == 0)
            {
                base_node.NextValue = first;
                first = base_node;
            }
            else
            {
                ListNode<T> temp_node = first;
                for (int i = 0; i < positionToAdd - 1; i++)
                {
                    temp_node = temp_node.NextValue;
                }
                base_node.NextValue = temp_node.NextValue;
                temp_node.NextValue = base_node;
            }
            count++;
            return 1;
        }
        public int Remove(int positionToDell)
        {
            if (positionToDell > count - 1 || positionToDell < 0)
                return -1;
            ListNode<T> temp_node = first;
            if(positionToDell == 0)
            {
                first = temp_node.NextValue;
                count--;
                return 1;
            }

            for (int i = 0; i < positionToDell - 1; i++)
            {
                temp_node = temp_node.NextValue;
            }
            if (positionToDell == count - 1)
                last = temp_node;
            else
                temp_node.NextValue = temp_node.NextValue.NextValue;
            count--;
            return 1;
        }
        public void RemoveLast()
        {
            ListNode<T> temp_node = first;
            while (temp_node != null && temp_node.NextValue != last)
            {
                temp_node = temp_node.NextValue;
            }
            if(temp_node != null)
            {
                temp_node.NextValue = null;
                last = temp_node;
                count--;
            }
            if(temp_node == null)
            {
                first = null;
                last = null;
                count = 0;
            }
        }
        public int Remove(T itemToDell, int a)
        {
            ListNode<T> temp_node = first;
            if (temp_node == first && EqualityComparer<T>.Default.Equals(temp_node.Value, itemToDell))
            {
                first = temp_node.NextValue;
                count--;
                return 1;
            }
            while (temp_node != null && !EqualityComparer<T>.Default.Equals(temp_node.NextValue.Value, itemToDell))
            {
                temp_node = temp_node.NextValue;
                if (temp_node.NextValue == last)
                {
                    last = temp_node;
                    count--;
                    return 1;
                }
            }
            if (temp_node != null)
            {
                temp_node.NextValue = temp_node.NextValue.NextValue;
                count--;
            }
            return 1;
        }

        public void RemoveAll(T itemToDell)
        {
            ListNode<T> temp_node = first;
            int countToDell = 0;
            for (int i = 0; i < count - 1; i++)
            {
                if (temp_node == first && EqualityComparer<T>.Default.Equals(temp_node.Value, itemToDell))
                {
                    first = temp_node.NextValue;
                    countToDell++;
                }
                if (temp_node != null && temp_node.NextValue != null && !EqualityComparer<T>.Default.Equals(temp_node.NextValue.Value, itemToDell))
                {
                    temp_node = temp_node.NextValue;
                    last = temp_node;
                }
                else
                {
                    temp_node.NextValue = temp_node.NextValue.NextValue;
                    countToDell++;
                }
            }
            count -= countToDell;
        }
        public int Find(T itemToFind, int different)
        {
            ListNode<T> temp_node = first;
            int i = 0;
            while (temp_node != null && !EqualityComparer<T>.Default.Equals(temp_node.Value, itemToFind))
            {
                temp_node = temp_node.NextValue;
                i++;
            }
            if (temp_node == null) return -1;
            return i;
        }

        public T Find(int positionToFind)
        {
            if (positionToFind > count - 1)
                return default;
            ListNode<T> temp_node = first;
            for (int i = 0; i < positionToFind; i++)
            {
                temp_node = temp_node.NextValue;
            }
            return temp_node.Value;
        }

        public void Clear()
        {
            first = null;
            last = null;
            count = 0;
        }
        public void Set(T valueToSet, int positionToSet)
        {
            ListNode<T> tmp = first;
            for (int i = 0; i < positionToSet; i++)
            {
                tmp = tmp.NextValue;
            }
            tmp.Value = valueToSet;
        }
        public T this[int index]
        {
            get { return Find(index); }
            set { Set(value, index); }
        }
        IEnumerator IEnumerable.GetEnumerator() 
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            ListNode<T> temp_node = first;
            while (temp_node != last)
            {
                yield return temp_node.Value;
                temp_node = temp_node.NextValue;
            }
            yield return temp_node.Value;
        }
    }
}

