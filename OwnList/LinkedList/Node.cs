using System;
namespace OwnList
{
    public class Node<T> where T : IComparable
    {
        public T _data { get; set; }
        public Node<T> _nextNode { get; set; }

        public Node()
        {
            _nextNode = null;
        }
        public Node(T value)
        {
            _data = value;
            _nextNode = null;
        }
    }
}
