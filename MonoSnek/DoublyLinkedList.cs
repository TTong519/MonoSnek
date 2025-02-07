using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MonoSnek
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedNode<T> head;
        public int count;
        public DoublyLinkedList(T value, T nextValue)
        {
            DoublyLinkedNode<T> next = new(nextValue, this);
            head = new DoublyLinkedNode<T>(value, this, next);
            head.Next.Previous = head;
            count = 2;
        }
        public DoublyLinkedList()
        {
            count = 0;
        }
        public void AddAfter(T value, int index)
        {
            if (index < count)
            {
                DoublyLinkedNode<T> current = head;
                DoublyLinkedNode<T> toadd = new(value, this);
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }
                current.Next.Previous = toadd;
                toadd.Next = current.Next;
                toadd.Previous = current;
                current.Next = toadd;
                count++;
            }
        }
        public void AddFirst(T value)
        {
            head = new(value, this, head);
            if (count == 1 || count == 0)
            {
                head.Next.Previous = head;
            }
            count++;
        }
        public void Remove(T value)
        {
            DoublyLinkedNode<T> current = head;
            while(!current.Value.Equals(value))
            {
                current = current.Next;
            }
            current.Previous.Next = current.Next;
            current.Next.Previous = current.Previous;
            count--;
        }
        public void RemoveLast()
        {
            if (count != 0 && count != 1)
            {
                DoublyLinkedNode<T> current = head;
                for (int i = 1; i < count; i++)
                {
                    current = current.Next;
                }
                current.Previous.Next = null;
            }
            else
            {
                head = null;
            }
            count--;
        }
    }
}
