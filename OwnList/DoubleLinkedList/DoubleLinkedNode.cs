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
        public static bool operator >(DoubleLinkedNode<T> leftValue, DoubleLinkedNode<T> rightValue)
        {
            if (object.ReferenceEquals(leftValue, null) || object.ReferenceEquals(rightValue, null))
            {
                return false;
            }
            if (leftValue._data.CompareTo(rightValue._data) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >(DoubleLinkedNode<T> leftValue, T rightValue)
        {
            if (object.ReferenceEquals(leftValue, null))
            {
                return false;
            }
            if (leftValue._data.CompareTo(rightValue) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <(DoubleLinkedNode<T> leftValue, DoubleLinkedNode<T> rightValue)
        {
            if (object.ReferenceEquals(leftValue, null) || object.ReferenceEquals(rightValue, null))
            {
                return false;
            }
            if (leftValue._data.CompareTo(rightValue._data) < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <(DoubleLinkedNode<T> leftValue, T rightValue)
        {
            if (object.ReferenceEquals(leftValue, null))
            {
                return false;
            }
            if (leftValue._data.CompareTo(rightValue) < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator ==(DoubleLinkedNode<T> leftValue, DoubleLinkedNode<T> rightValue)
        {
            if (object.ReferenceEquals(leftValue, null) && object.ReferenceEquals(rightValue, null))
            {
                return true;
            }

            if (object.ReferenceEquals(leftValue, null) || object.ReferenceEquals(rightValue, null))
            {
                return false;
            }


            if (leftValue._data.CompareTo(rightValue._data) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator ==(DoubleLinkedNode<T> leftValue, T rightValue)
        {
            if (object.ReferenceEquals(leftValue, null))
            {
                return false;
            }

            if (leftValue._data.CompareTo(rightValue) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(DoubleLinkedNode<T> leftValue, DoubleLinkedNode<T> rightValue)
        {
            if (object.ReferenceEquals(leftValue, null) && object.ReferenceEquals(rightValue, null))
            {
                return false;
            }

            if (object.ReferenceEquals(leftValue, null) || object.ReferenceEquals(rightValue, null))
            {
                return true;
            }

            if (leftValue._data.CompareTo(rightValue._data) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(DoubleLinkedNode<T> leftValue, T rightValue)
        {
            if (object.ReferenceEquals(leftValue, null))
            {
                return false;
            }

            if (leftValue._data.CompareTo(rightValue) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return $"{_data}";
        }
    }
}
