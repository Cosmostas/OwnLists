using System;
namespace OwnList
{
    public class Node<T> where T : IComparable
    {
        public T _data { get; set; }
        public Node<T> _next { get; set; }

        public Node()
        {
            _next = null;
        }
        public Node(T value)
        {
            _data = value;
            _next = null;
        }

        public static bool operator >(Node<T> leftValue, Node<T> rightValue)
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
        public static bool operator >(Node<T> leftValue, T rightValue)
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
        public static bool operator <(Node<T> leftValue, Node<T> rightValue)
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
        public static bool operator <(Node<T> leftValue, T rightValue)
        {
            if (object.ReferenceEquals(leftValue, null) )
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
        public static bool operator ==(Node<T> leftValue, Node<T> rightValue)
        {
            if(object.ReferenceEquals(leftValue, null) && object.ReferenceEquals(rightValue, null))
            {
                return true;
            }

            if(object.ReferenceEquals(leftValue, null) || object.ReferenceEquals(rightValue, null))
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
        public static bool operator ==(Node<T> leftValue, T rightValue)
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
        public static bool operator !=(Node<T> leftValue, Node<T> rightValue)
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
        public static bool operator !=(Node<T> leftValue, T rightValue)
        {
            if (object.ReferenceEquals(leftValue, null) )
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
