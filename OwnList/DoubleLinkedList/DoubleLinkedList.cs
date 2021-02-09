using System;
using System.Collections.Generic;
using System.Text;

namespace OwnList.DoubleLinkedList
{
    public class DoubleLinkedList<T> where T : IComparable
    {
        public DoubleLinkedNode<T> _root { get; private set; }
        public DoubleLinkedNode<T> _tail { get; private set; }
        public int _length { get; private set; }


        public DoubleLinkedList()
        {
            _root = null;
            _tail = null;
            _length = 0;
        }
        public DoubleLinkedList(T value)
        {
            _root = new DoubleLinkedNode<T>(value);
            _tail = _root;
            _length = 1;
        }

        public DoubleLinkedList(T[] arr)
        {
            if (arr.Length == 0)
            {
                _root = null;
            }
            else
            {
                DoubleLinkedNode<T> crnt = new DoubleLinkedNode<T>(arr[0]);
                _root = crnt;
                for (int i = 1; i < arr.Length; ++i)
                {
                    crnt._next = new DoubleLinkedNode<T>(arr[i]);
                    crnt._next._prev = crnt;
                    crnt = crnt._next;
                }
                _tail = crnt;
                _length = arr.Length;
            }
        }

        public void PushBack(T value)
        {
            if (_length == 0)
            {
                _root = new DoubleLinkedNode<T>(value);
                _tail = _root;
            }
            else
            {

                DoubleLinkedNode<T> newNode = new DoubleLinkedNode<T>(value);
                _tail._next = newNode;
                newNode._prev = _tail;
                _tail = newNode;
            }
            _length += 1;
        }
        public void PushBack(T[] arr)
        {
            DoubleLinkedNode<T> crnt;

            if (_length == 0)
            {
                crnt = new DoubleLinkedNode<T>(arr[0]);
                _root = crnt;
                _tail = _root;

                for (int i = 1; i < arr.Length; ++i)
                {

                    crnt._next = new DoubleLinkedNode<T>(arr[i]);
                    crnt._next._prev = crnt;
                    crnt = crnt._next;
                }
                _tail = crnt;
            }

            else
            {
                crnt = _tail;
                for (int i = 0; i < arr.Length; ++i)
                {

                    crnt._next = new DoubleLinkedNode<T>(arr[i]);
                    crnt._next._prev = crnt;
                    crnt = crnt._next;
                }
                _tail = crnt;
            }
            _length += arr.Length;
        }

        public void PushByIndex(T value, int index)
        {
            if (index > _length && index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if(_root == null && index == 0)
            {
                _root = new DoubleLinkedNode<T>(value);
                _tail = _root;

            }
            else if (_root != null && index == 0)
            {
                DoubleLinkedNode<T> tmp = _root;
                _root = new DoubleLinkedNode<T>(value);
                _root._next = tmp;
                tmp._prev = _root;
                _tail = tmp;
            }
            else
            {
                if(index <= _length / 2)
                {
                    DoubleLinkedNode<T> crnt = _root;
                    for (int i = 0; i < index - 1; ++i)
                    {
                        crnt = crnt._next;
                    }
                    DoubleLinkedNode<T> tmp = crnt._next;
                    crnt._next = new DoubleLinkedNode<T>(value);

                    crnt._next._prev = crnt;

                    crnt = crnt._next;

                    crnt._next = tmp;
                    if(tmp != null)
                    {
                        tmp._prev = crnt;
                    }
                }
                else
                {
                    DoubleLinkedNode<T> crnt = _tail;
                    for (int i = 0; i < _length - index; ++i)
                    {
                        crnt = crnt._prev;
                    }
                    DoubleLinkedNode<T> tmp = crnt._next;
                    crnt._next = new DoubleLinkedNode<T>(value);

                    crnt._next._prev = crnt;

                    crnt = crnt._next;

                    crnt._next = tmp;
                    if (tmp != null)
                    {
                        tmp._prev = crnt;
                    }
                }
            }

            _length += 1;
        }
        public void PushByIndex(T[] arr, int index)
        {
            if (index > _length && index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if(_root == null && index == 0)
            {

                DoubleLinkedNode<T> tmp = new DoubleLinkedNode<T>(arr[0]);
                DoubleLinkedNode<T> crnt = tmp;
                for (int i = 1; i < arr.Length; ++i)
                {
                    crnt._next = new DoubleLinkedNode<T>(arr[i]);
                    crnt._next._prev = crnt;
                    crnt = crnt._next;
                }
                crnt._next = _root;
                if(_root != null)
                {
                    _root._prev = crnt;
                }
                _root = tmp;
            }
            if (index == 0)
            {

                DoubleLinkedNode<T> tmp = new DoubleLinkedNode<T>(arr[0]);
                DoubleLinkedNode<T> crnt = tmp;
                for (int i = 1; i < arr.Length; ++i)
                {
                    crnt._next = new DoubleLinkedNode<T>(arr[i]);
                    crnt._next._prev = crnt;
                    crnt = crnt._next;
                }
                crnt._next = _root;
                _root._prev = crnt;
                _root = tmp;
            }
            else
            {

                DoubleLinkedNode<T> crnt = _root;
                for (int i = 0; i < index - 1; ++i)
                {
                    crnt = crnt._next;
                }

                DoubleLinkedNode<T> tmp = crnt._next;

                for (int i = 0; i < arr.Length; ++i)
                {
                    crnt._next = new DoubleLinkedNode<T>(arr[i]);
                    crnt._next._prev = crnt._prev; 
                    crnt = crnt._next;
                }

                crnt._next = tmp;
                if(tmp != null)
                {
                    tmp._prev = crnt;
                }
                else
                {
                    _tail = crnt;
                }

            }

            _length += arr.Length;
        }

        public void PushFront(T value)
        {
            DoubleLinkedNode<T> crnt = new DoubleLinkedNode<T>(value);
            crnt._next = _root;
            if(_root != null)
            {
                _root._prev = crnt;
                _tail = _root;
            }
            else
            {
                _tail = crnt;
            }
            _root = crnt;
            _length += 1;
        }


        public void PushFront(T[] arr)
        {
            DoubleLinkedNode<T> tmp = new DoubleLinkedNode<T>(arr[0]);
            DoubleLinkedNode<T> crnt = tmp;
            for (int i = 1; i < arr.Length; ++i)
            {
                crnt._next = new DoubleLinkedNode<T>(arr[i]);
                crnt._next._prev = crnt;
                crnt = crnt._next;
            }
            if(_root != null)
            {
                crnt._next = _root;
                _root._prev = crnt;
            }
            _root = tmp;



            _length += arr.Length;
        }

        public void PopBack()
        {
            if (_length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (_length == 1)
            {
                _root = null;
            }
            else
            {
                DoubleLinkedNode<T> crnt = _root;
                for (int i = 0; i < _length - 2; ++i)
                {
                    crnt = crnt._next;
                }

                crnt._next = null;
            }

            --_length;

        }
        public void PopBackAmount(int amount)
        {
            if (_length == 0 || amount > _length || amount < -1)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (_length == 1 || amount == _length)
            {
                _root = null;
            }
            else
            {
                DoubleLinkedNode<T> crnt = _root;
                for (int i = 0; i < _length - amount - 1; ++i)
                {
                    crnt = crnt._next;
                }

                crnt._next = null;
            }

            _length -= amount;

        }

        public void PopByPos(int index)
        {
            if (index >= _length && index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (_length == 1)
            {
                _root = null;
            }
            else if (index == 0)
            {
                _root = _root._next;

            }
            else
            {
                DoubleLinkedNode<T> crnt = _root;
                for (int i = 0; i < index - 1; ++i)
                {
                    crnt = crnt._next;
                }

                crnt._next = crnt._next._next;

            }

            --_length;
        }

        public void PopByPosAmount(int amount, int index)
        {
            if (_length == 0 || index + amount > _length || amount < -1 || index < -1)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (_length == 1)
            {
                _root = null;
            }
            else if (index == 0)
            {
                DoubleLinkedNode<T> crnt = _root;
                for (int i = 0; i < amount; ++i)
                {
                    crnt = crnt._next;
                }
                _root = crnt;
            }
            else
            {
                DoubleLinkedNode<T> crnt = _root;
                for (int i = 0; i < index - 1; ++i)
                {
                    crnt = crnt._next;
                }

                DoubleLinkedNode<T> tmp = crnt;

                for (int i = 0; i < amount; ++i)
                {
                    crnt = crnt._next;
                }

                tmp._next = crnt;
            }

            _length -= amount;

        }

        public void PopFront()
        {
            if (_length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (_length == 1)
            {
                _root = null;
            }
            else
            {
                _root = _root._next;
                _root._prev = null;
            }

            --_length;
        }

        public void PopFrontAmount(int amount)
        {
            if (_length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (amount > _length)
            {
                throw new NullReferenceException();
            }
            else if (_length == 1 || amount == _length)
            {
                _root = null;
            }
            else
            {
                DoubleLinkedNode<T> crnt = _root;
                for (int i = 0; i < amount; ++i)
                {
                    crnt = crnt._next;
                }
                _root = crnt;
            }

            _length -= amount;
        }
        public void PopByValue(T value)
        {
            if (_length == 0)
            {
                throw new NullReferenceException();
            }
            if (_root == value)
            {
                _root = _root._next;
            }
            else
            {
                DoubleLinkedNode<T> crnt = _root._next;
                DoubleLinkedNode<T> prevNode = _root;

                for (int i = 0; i < _length - 2; ++i)
                {
                    if (crnt==value)
                    {
                        prevNode._next = crnt._next;
                        break;
                    }
                    prevNode = crnt;
                    crnt = crnt._next;
                }
            }

            _length -= 1;
        }
        public void PopAllByValue(T value)
        {
            if (_length == 0)
            {
                throw new NullReferenceException();
            }

            int numDeletedElems = 0;
            while (_root == value)
            {
                _root = _root._next;
                ++numDeletedElems;
                if (_root == null)
                {
                    _length -= numDeletedElems;
                    return;
                }
            }
            DoubleLinkedNode<T> crnt = _root._next;
            DoubleLinkedNode<T> prevNode = _root;

            for (int i = 0; i < _length - 3; ++i)
            {
                if (crnt == value)
                {
                    prevNode._next = crnt._next;
                    ++numDeletedElems;
                }
                prevNode = crnt;
                crnt = crnt._next;
            }

            _length -= numDeletedElems;
        }
        public int Find(T value)
        {
            DoubleLinkedNode<T> crnt = _root;
            for (int i = 0; i < _length; i++)
            {
                if (crnt == value)
                {
                    return i;
                }
                crnt = crnt._next;
            }

            throw new Exception("No such value");
        }

        public DoubleLinkedNode<T> GetNode(int index)
        {
            if (_root == null)
            {
                throw new NullReferenceException();
            }
            else if (index >= _length)
            {
                throw new ArgumentException();
            }

            if (index < _length / 2)
            {

                DoubleLinkedNode<T> crnt = _root;
                for (int i = 0; i < index; ++i)
                {
                    crnt = crnt._next;
                }

                return crnt;
            }
            else
            {
                DoubleLinkedNode<T> crnt = _tail;
                for (int i = 0; i < _length - index - 1; ++i)
                {
                    crnt = crnt._prev;
                }

                return crnt;
            }
        }

        public void Sort(DoubleLinkedNode<T> left, DoubleLinkedNode<T> right, int len)
        {
            if (_root == null)
            {
                throw new NullReferenceException();
            }
            else if (len == 2)
            {
                if (left > right)
                {

                    T tmp = left._data;
                    left._data = right._data;
                    right._data = tmp;
                }
            }
            else if (len > 2)
            {
                DoubleLinkedNode<T> crnt = left;

                for (int i = 0; i < len / 2 - 1; ++i)
                {
                    crnt = crnt._next;
                }

                Sort(left, crnt, len / 2);
                Sort(crnt._next, right, len - len / 2);

                T[] arr = new T[len];
                crnt = crnt._next;
                DoubleLinkedNode<T> midle = crnt;
                DoubleLinkedNode<T> first = left;
                int index = 0;

                while (left != midle && crnt != right._next && crnt != _tail._next)
                {
                    if (left>crnt._data)
                    {
                        arr[index] = crnt._data;
                        crnt = crnt._next;
                    }
                    else
                    {
                        arr[index] = left._data;
                        left = left._next;
                    }

                    ++index;
                }

                if (left != midle)
                {
                    crnt = left;
                }

                while (index < len)
                {
                    arr[index] = crnt._data;
                    crnt = crnt._next;
                    ++index;
                }

                crnt = first;
                for (int i = 0; i < len; ++i)
                {
                    crnt._data = arr[i];
                    crnt = crnt._next;
                }
            }
        }

        public void Reverse()
        {
            if (_length == 0)
            {
                throw new NullReferenceException();
            }

            DoubleLinkedNode<T> crnt = _tail;
            DoubleLinkedNode<T> tmp;
            
            for(int i = 0; i < _length; ++i)
            {
                tmp = crnt._next;
                crnt._next = crnt._prev;
                crnt._prev = tmp;

                crnt = crnt._next;
            }

            tmp = _tail;
            _tail = _root;
            _root = tmp;


        }  
        public T this[int index]
        {
            get
            {
                if (index >= _length && index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                if(index < _length / 2)
                {
                    DoubleLinkedNode<T> crnt = _root;

                    for (int i = 0; i < index; ++i)
                    {
                        crnt = crnt._next;
                    }

                    return crnt._data;
                }
                else
                {
                    DoubleLinkedNode<T> crnt = _tail;

                    for (int i = 0; i < _length - index - 1; ++i)
                    {
                        crnt = crnt._prev;
                    }

                    return crnt._data;
                }

            }
            set
            {
                if (index >= _length && index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                if (index < _length / 2)
                {
                    DoubleLinkedNode<T> crnt = _root;

                    for (int i = 0; i < index; ++i)
                    {
                        crnt = crnt._next;
                    }

                    crnt._data = value;
                }
                else
                {
                    DoubleLinkedNode<T> crnt = _tail;

                    for (int i = 0; i < _length - index; ++i)
                    {
                        crnt = crnt._prev;
                    }

                    crnt._data = value;
                }
            }
        }

        public DoubleLinkedNode<T> FindMax()
        {
            if (_length == 0)
            {
                throw new Exception("List is empty");
            }
            DoubleLinkedNode<T> crnt = _root;
            DoubleLinkedNode<T> Max = crnt;

            for (int i = 0; i < _length - 1; ++i)
            {
                crnt = crnt._next;
                if (crnt > Max)
                {
                    Max = crnt;
                }
            }

            return Max;
        }
        public int FindMaxIndex()
        {
            if (_length == 0)
            {
                throw new Exception("List is empty");
            }
            DoubleLinkedNode<T> crnt = _root;
            DoubleLinkedNode<T> max = crnt;
            int IndexOfMax = 0;
            for (int i = 0; i < _length - 1; ++i)
            {
                crnt = crnt._next;
                if (crnt > max)
                {
                    max = crnt;
                    IndexOfMax = i + 1;
                }

            }

            return IndexOfMax;
        }
        public int FindMinIndex()
        {
            if (_length == 0)
            {
                throw new Exception("List is empty");
            }
            DoubleLinkedNode<T> crnt = _root;
            DoubleLinkedNode<T> min = crnt;
            int IndexOfMin = 0;
            for (int i = 0; i < _length - 1; ++i)
            {
                crnt = crnt._next;
                if (crnt < min)
                {
                    min = crnt;
                    IndexOfMin = i + 1;
                }

            }

            return IndexOfMin;
        }
        public DoubleLinkedNode<T> FindMin()
        {
            if (_length == 0)
            {
                throw new Exception("List is empty");
            }
            DoubleLinkedNode<T> crnt = _root;
            DoubleLinkedNode<T> min = crnt;

            for (int i = 0; i < _length - 1; ++i)
            {
                crnt = crnt._next;
                if (crnt < min)
                {
                    min = crnt;
                }
            }

            return min;
        }
        public override bool Equals(object obj)
        {
            DoubleLinkedList<T> doubleLinkedList = (DoubleLinkedList<T>)obj;

            if (_length != doubleLinkedList._length)
            {
                return false;
            }
            else
            {
                DoubleLinkedNode<T> thisCrnt = _root;
                DoubleLinkedNode<T> crnt = doubleLinkedList._root;

                for (int i = 0; i < _length; ++i)
                {
                    if (thisCrnt!=crnt)
                    {
                        return false;
                    }
                    thisCrnt = thisCrnt._next;
                    crnt = crnt._next;
                }
            }

            return true;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {

            if (_length == 0)
            {
                return "";
            }
            else
            {
                string ans = "";
                DoubleLinkedNode<T> crnt = _root;
                for (int i = 0; i < _length; ++i)
                {
                    ans += $"{crnt._data} ";
                    crnt = crnt._next;
                }

                return ans;
            }
        }
    }
}
