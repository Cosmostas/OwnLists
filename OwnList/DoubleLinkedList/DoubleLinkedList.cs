using System;
using System.Collections.Generic;
using System.Text;

namespace OwnList.DoubleLinkedList
{
    public class DoubleLinkedList<T> where T : IComparable
    {
        public DoubleLinkedNode<T> _head { get; private set; }
        public DoubleLinkedNode<T> _tail { get; private set; }
        public int _length { get; private set; }


        public DoubleLinkedList()
        {
            _head = null;
            _tail = null;
            _length = 0;
        }
        public DoubleLinkedList(T value)
        {
            _head = new DoubleLinkedNode<T>(value);
            _tail = _head;
            _length = 1;
        }

        public DoubleLinkedList(T[] arr)
        {
            if (arr.Length == 0)
            {
                _head = null;
            }
            else
            {
                DoubleLinkedNode<T> crnt = new DoubleLinkedNode<T>(arr[0]);
                _head = crnt;
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
                _head = new DoubleLinkedNode<T>(value);
                _tail = _head;
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
                crnt = new DoubleLinkedNode<T>();
                _head = crnt;
                _tail = _head;
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
            if(_head == null && index == 0)
            {
                _head = new DoubleLinkedNode<T>(value);
                _tail = _head;

            }
            else if (_head != null && index == 0)
            {
                DoubleLinkedNode<T> tmp = _head;
                _head = new DoubleLinkedNode<T>(value);
                _head._next = tmp;
                tmp._prev = _head;
                _tail = tmp;
            }
            else
            {
                if(index < _length / 2)
                {
                    DoubleLinkedNode<T> crnt = _head;
                    for (int i = 0; i < index - 1; ++i)
                    {
                        crnt = crnt._next;
                    }
                    DoubleLinkedNode<T> tmp = crnt._next;
                    crnt._next = new DoubleLinkedNode<T>(value);

                    crnt._next._prev = crnt;

                    crnt = crnt._next;

                    crnt._next = tmp;
                    tmp._prev = crnt;
                }
                else
                {
                    DoubleLinkedNode<T> crnt = _tail;
                    for (int i = 0; i < _length - index; ++i)
                    {
                        crnt = crnt._prev;
                    }
                    DoubleLinkedNode<T> tmp = crnt._prev;

                    crnt._prev = new DoubleLinkedNode<T>(value);

                    crnt._prev._next = crnt;

                    crnt = crnt._prev;
                    crnt._prev = tmp;
                    tmp._next = crnt;
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

            if(_head == null)
            {
                throw new NullReferenceException();
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
                crnt._next = _head;
                _head._prev = crnt;
                _head = tmp;
            }
            else
            {

                DoubleLinkedNode<T> crnt = _head;
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
            crnt._next = _head;
            if(_head != null)
            {
                _head._prev = crnt;
                _tail = _head;
            }
            else
            {
                _tail = crnt;
            }
            _head = crnt;
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
            crnt._next = _head;
            _head._prev = crnt;
            _head = tmp;



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
                _head = null;
            }
            else
            {
                DoubleLinkedNode<T> crnt = _head;
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
                _head = null;
            }
            else
            {
                DoubleLinkedNode<T> crnt = _head;
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
                _head = null;
            }
            else if (index == 0)
            {
                _head = _head._next;

            }
            else
            {
                DoubleLinkedNode<T> crnt = _head;
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
                _head = null;
            }
            else if (index == 0)
            {
                DoubleLinkedNode<T> crnt = _head;
                for (int i = 0; i < amount; ++i)
                {
                    crnt = crnt._next;
                }
                _head = crnt;
            }
            else
            {
                DoubleLinkedNode<T> crnt = _head;
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
                _head = null;
            }
            else
            {
                _head = _head._next;
                _head._prev = null;
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
                _head = null;
            }
            else
            {
                DoubleLinkedNode<T> crnt = _head;
                for (int i = 0; i < amount; ++i)
                {
                    crnt = crnt._next;
                }
                _head = crnt;
            }

            _length -= amount;
        }
        public void PopByValue(int value)
        {
            if (_length == 0)
            {
                throw new NullReferenceException();
            }
            if ((_head._data).CompareTo(value) == 0)
            {
                _head = _head._next;
            }
            else
            {
                DoubleLinkedNode<T> crnt = _head._next;
                DoubleLinkedNode<T> prevNode = _head;

                for (int i = 0; i < _length - 2; ++i)
                {
                    if ((crnt._data).CompareTo(value) == 0)
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
        public void PopAllByValue(int value)
        {
            if (_length == 0)
            {
                throw new NullReferenceException();
            }

            int numDeletedElems = 0;
            while ((_head._data).CompareTo(value) == 0)
            {
                _head = _head._next;
                ++numDeletedElems;
                if (_head == null)
                {
                    _length -= numDeletedElems;
                    return;
                }
            }
            DoubleLinkedNode<T> crnt = _head._next;
            DoubleLinkedNode<T> prevNode = _head;

            for (int i = 0; i < _length - 3; ++i)
            {
                if ((crnt._data).CompareTo(value) == 0)
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
            DoubleLinkedNode<T> crnt = _head;
            for (int i = 0; i < _length; i++)
            {
                if ((crnt._data).CompareTo(value) == 0)
                {
                    return i;
                }
                crnt = crnt._next;
            }

            throw new Exception("No such value");
        }

        public DoubleLinkedNode<T> GetNode(int index)
        {
            if (_head == null)
            {
                throw new NullReferenceException();
            }
            else if (index >= _length)
            {
                throw new ArgumentException();
            }

            if (index < _length / 2)
            {

                DoubleLinkedNode<T> crnt = _head;
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
            if (_head == null)
            {
                throw new NullReferenceException();
            }
            else if (len == 2)
            {
                if ((left._data).CompareTo(right._data) > 0)
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
                    if ((left._data).CompareTo(crnt._data) > 0)
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
            _tail = _head;
            _head = _tail;


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
                    DoubleLinkedNode<T> crnt = _head;

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
                    DoubleLinkedNode<T> crnt = _head;

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

        public override bool Equals(object obj)
        {
            DoubleLinkedList<T> doubleLinkedList = (DoubleLinkedList<T>)obj;

            if (_length != doubleLinkedList._length)
            {
                return false;
            }
            else
            {
                DoubleLinkedNode<T> thisCrnt = _head;
                DoubleLinkedNode<T> crnt = doubleLinkedList._head;

                for (int i = 0; i < _length; ++i)
                {
                    if ((thisCrnt._data).CompareTo(crnt._data) != 0)
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
                DoubleLinkedNode<T> crnt = _head;
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
