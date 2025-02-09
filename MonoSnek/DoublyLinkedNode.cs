using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoSnek
{
    //https://eishaaya.itch.io/tetris-boogaloo
    public class DoublyLinkedNode<T>
    {
        public T Value;
        public DoublyLinkedNode<T> Next;
        public DoublyLinkedNode<T> Previous;
        public DoublyLinkedList<T> Owner { get; internal set; }
        public DoublyLinkedNode(T value, DoublyLinkedList<T> Owner, DoublyLinkedNode<T> next = null, DoublyLinkedNode<T> previous = null)
        {
            Value = value;
            Next = next;
            this.Owner = Owner;
            Previous = previous;
        }
    }
}
