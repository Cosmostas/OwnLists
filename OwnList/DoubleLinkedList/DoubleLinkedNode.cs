using System;
using System.Collections.Generic;
using System.Text;

namespace OwnList.DoubleLinkedList
{
    public class DoubleLinkedNode<T> where T : IComparable
    {
        public T _data { get; set; }
        public DoubleLinkedNode<T> _next { get; set; }
        public DoubleLinkedNode<T> _prev{ get; set; }

        public DoubleLinkedNode()
        {
            _next= null;
            _next= null;
        }
        public DoubleLinkedNode(T value)
        {
            _data = value;
            _next = null;
            _prev = null;

        }

        public override string ToString()
        {
            return $"{_data}";
        }
    }
}
