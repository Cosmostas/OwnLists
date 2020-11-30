using System;

namespace OwnList
{

    public class LinkedList<T> where T : IComparable
    {
        public Node<T> _headNode { get; private set; }
        public int _length { get; private set; }

        public LinkedList()
        {
            _headNode = null;
            _length = 0;
        }
        public LinkedList(T value)
        {
            _headNode = new Node<T>(value);
            _length = 1;
        }

        public LinkedList(T[] arr)
        {
            if(arr.Length == 0)
            {
                _headNode = null;
            }
            else
            {
                Node<T> curNode = new Node<T>(arr[0]);
                _headNode = curNode;
                for (int i = 1; i < arr.Length; ++i)
                {
                    curNode._nextNode = new Node<T>(arr[i]);
                    curNode = curNode._nextNode;
                }
                _length = arr.Length;
            }
        }

        public void PushBack(T value)
        {
            if(_length == 0)
            {
                _headNode = new Node<T>(value);
            }
            else
            {
                Node<T> curNode = _headNode;
                
                while(curNode._nextNode != null)
                {
                    curNode = curNode._nextNode;
                }

                Node<T> newNode = new Node<T>(value);
                curNode._nextNode = newNode;
            }
            _length += 1;
        } 
        public void PushBack(T[] arr)
        {
            Node<T> curNode;

            if (_length == 0)
            {
                curNode = new Node<T>();
                _headNode = curNode;
            }

            else
            {
                curNode = _headNode;
                
                while(curNode._nextNode != null)
                {
                    curNode = curNode._nextNode;
                }

                curNode._nextNode = new Node<T>();
                curNode = curNode._nextNode;
            }

            for(int i = 0; i < arr.Length; ++i)
            {
                curNode._data = arr[i];
                curNode._nextNode = new Node<T>();
                curNode = curNode._nextNode;
            }

            _length += arr.Length;
        }

        public void PushByIndex(T value, int index)
        {
            if(index > _length && index < 0)
                {
                throw new IndexOutOfRangeException();
            }

            if(index == 0)
            {
                Node<T> tmp = _headNode;
                _headNode = new Node<T>(value);
                _headNode._nextNode = tmp;
            }
            else
            {
                Node<T> curNode = _headNode;
                for (int i = 0; i < index - 1; ++i)
                {
                    curNode = curNode._nextNode;
                }
                Node<T> tmp = curNode._nextNode;
                curNode._nextNode = new Node<T>(value);
                curNode._nextNode._nextNode = tmp;
            }

            _length += 1;
        }
        public void PushByIndex(T[] arr, int index)
        {
            if(index > _length && index < 0)
                {
                throw new IndexOutOfRangeException();
            }

            if(index == 0)
            {

                Node<T> tmp = new Node<T>(arr[0]);
                Node<T> curNode = tmp;
                for (int i = 1; i < arr.Length; ++i)
                {
                    curNode._nextNode = new Node<T>(arr[i]);
                    curNode = curNode._nextNode;
                }
                curNode._nextNode = _headNode;
                _headNode = tmp;
            }
            else
            {

                Node<T> curNode = _headNode;
                for (int i = 0; i < index - 1; ++i)
                {
                    curNode = curNode._nextNode;
                }

                Node<T> tmp = curNode._nextNode;

                for(int i = 0; i < arr.Length; ++i)
                {
                    curNode._nextNode = new Node<T>(arr[i]);
                    curNode = curNode._nextNode;
                }

                curNode._nextNode = tmp;

            }

            _length += arr.Length;
        }

        public void PushFront(T value)
        {
            Node<T> curNode = new Node<T>(value);
            curNode._nextNode = _headNode;
            _headNode = curNode;
            _length += 1;
        }
        

        public void PushFront(T[] arr)
        {
            Node<T> tmp = new Node<T>(arr[0]);
            Node<T> curNode = tmp;
            for(int i = 1; i < arr.Length; ++i)
            {
                curNode._nextNode = new Node<T>(arr[i]);
                curNode = curNode._nextNode;
            }
            curNode._nextNode = _headNode;
            _headNode = tmp;

            _length += arr.Length;
        }

        public void PopBack()
        {
            if (_length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if(_length == 1)
            {
                _headNode = null;
            }
            else
            {
                Node<T> curNode = _headNode;
                for (int i = 0; i < _length - 2; ++i)
                {
                    curNode = curNode._nextNode;
                }

                curNode._nextNode = null;
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
                _headNode = null;
            }
            else
            {
                Node<T> curNode = _headNode;
                for (int i = 0; i < _length - amount - 1; ++i)
                {
                    curNode = curNode._nextNode;
                }

                curNode._nextNode = null;
            }

            _length -= amount ;

        }

        public void PopByPos(int index)
        {
            if (index >= _length && index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            
            if(_length == 1)
            {
                _headNode = null;
            }
            else if (index == 0)
            {
                _headNode = _headNode._nextNode;
                
            }
            else
            {
                Node<T> curNode = _headNode;
                for (int i = 0; i < index - 1; ++i)
                {
                    curNode = curNode._nextNode;
                }

                curNode._nextNode = curNode._nextNode._nextNode;

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
                _headNode = null;
            }
            else if(index == 0)
            {
                Node<T> curNode = _headNode;
                for (int i = 0; i < amount; ++i)
                {
                    curNode = curNode._nextNode;
                }
                _headNode = curNode;
            }
            else
            {
                Node<T> curNode = _headNode;
                for (int i = 0; i < index - 1; ++i)
                {
                    curNode = curNode._nextNode;
                }

                Node<T> tmp = curNode;

                for (int i = 0; i < amount; ++i)
                {
                    curNode = curNode._nextNode;
                }

                tmp._nextNode = curNode;
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
                _headNode = null;
            }
            else
            {
                _headNode = _headNode._nextNode;
            }

            --_length;
        }

        public void PopFrontAmount(int amount)
        {
            if (_length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if(amount > _length) {
                throw new NullReferenceException();
            }
            else if (_length == 1 || amount == _length)
            {
                _headNode = null;
            }
            else
            {
                Node<T> curNode = _headNode;
                for(int i = 0; i < amount; ++i)
                {
                    curNode = curNode._nextNode;
                }
                _headNode = curNode;
            }

            _length -= amount ;
        }
        public void PopByValue(int value)
        {
            if (_length == 0)
            {
                throw new NullReferenceException();
            }
            if((_headNode._data).CompareTo(value) == 0)
            {
                _headNode = _headNode._nextNode;
            }
            else
            {
                Node<T> curNode = _headNode._nextNode;
                Node<T> prevNode = _headNode;

                for (int i = 0; i < _length - 2; ++i)
                {
                    if ((curNode._data).CompareTo(value) == 0)
                    {
                        prevNode._nextNode = curNode._nextNode;
                        break;
                    }
                    prevNode = curNode;
                    curNode = curNode._nextNode;
                }
            }

            _length -= 1 ;
        }
        public void PopAllByValue(int value)
        {
            if (_length == 0)
            {
                throw new NullReferenceException();
            }

            int numDeletedElems = 0;
            while((_headNode._data).CompareTo(value) == 0)
            {
                _headNode = _headNode._nextNode;
                ++numDeletedElems;
                if(_headNode == null)
                {
                    _length -= numDeletedElems;
                    return;
                }
            }
            Node<T> curNode = _headNode._nextNode;
            Node<T> prevNode = _headNode;

            for (int i = 0; i < _length - 3; ++i)
            {
                if ((curNode._data).CompareTo(value) == 0)
                {
                    prevNode._nextNode = curNode._nextNode;
                    ++numDeletedElems;
                }
                prevNode = curNode;
                curNode = curNode._nextNode;
            }

            _length -= numDeletedElems;
        }
        public int Find(T value)
        {
            Node<T> curNode = _headNode;
            for(int i = 0; i < _length; i++)
            {
                if((curNode._data).CompareTo(value) == 0)
                {
                    return i;
                }
                curNode = curNode._nextNode;
            }

            throw new Exception("No such value");
        }

        public Node<T> GetNode(int index)
        {
            if(_headNode == null)
            {
                throw new NullReferenceException();
            }
            else if(index >= _length)
            {
                throw new ArgumentException(); 
            }
            else
            {
                Node<T> curNode = _headNode;
                for(int i = 0; i < index; ++i)
                {
                    curNode = curNode._nextNode;
                }

                return curNode;
            }
        }

        public void Sort(Node<T> ptr1, Node<T> ptr2, int len)
        {
            if(_headNode == null)
            {
                throw new NullReferenceException();
            }
            else if(len == 2)
            {
                if((ptr1._data).CompareTo(ptr2._data) > 0)
                {
                    T tmp = ptr1._data;
                    ptr1._data = ptr2._data;
                    ptr2._data = tmp;
                }
            }
            else if(len > 2)
            {
                Node<T> curNode = ptr1;
                
                for (int i = 0; i < len / 2 - 1 ; ++i)
                {
                    curNode = curNode._nextNode;
                }

                Sort(ptr1, curNode, len / 2);
                Sort(curNode._nextNode, ptr2, len - len / 2 );

                T[] arr = new T[len];
                curNode = curNode._nextNode;
                Node<T> midle = curNode;
                Node<T> first = ptr1;
                int index = 0;

                while (ptr1 != midle && curNode != ptr2._nextNode && curNode != null)
                {
                    if ((ptr1._data).CompareTo(curNode._data) > 0)
                    {
                        arr[index] = curNode._data;
                        curNode = curNode._nextNode;
                    }
                    else
                    {
                        arr[index] = ptr1._data;
                        ptr1 = ptr1._nextNode;
                    }

                    ++index;
                }

                if(ptr1 != midle)
                {
                    curNode = ptr1;
                }

                while(index < len)
                {
                    arr[index] = curNode._data;
                    curNode = curNode._nextNode;
                    ++index;
                }
                curNode = first;
                for (int i = 0; i < len; ++i)
                {
                    curNode._data = arr[i];
                    curNode = curNode._nextNode;
                }
            }
        }

        public void Reverse()
        {
            if(_length == 0)
            {
                throw new NullReferenceException();
            }

            Node<T> oldHeadNode = _headNode;
            Node<T> temp;

            while (oldHeadNode._nextNode != null)
            {
                temp = oldHeadNode._nextNode;
                oldHeadNode._nextNode = temp._nextNode;
                temp._nextNode = _headNode;
                _headNode = temp;
            }



        }
        public T this[int index]
        {
            get
            {
                if (index >= _length && index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                Node<T> curNode = _headNode;
                
                for(int i = 0; i < index; ++i)
                {
                    curNode = curNode._nextNode;
                }

                return curNode._data;
                
            }
            set
            {
                if (index >= _length && index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                Node<T> curNode = _headNode;

                for (int i = 0; i < index; ++i)
                {
                    curNode = curNode._nextNode;
                }

                curNode._data = value;
            }
        }

        public override bool Equals(object obj)
        {
            LinkedList<T> linkedList = (LinkedList<T>)obj;

            if(_length != linkedList._length)
            {
                return false;
            }
            else
            {
                Node<T> thisCurNode = _headNode;
                Node<T> curNode = linkedList._headNode;

                for(int i = 0; i < _length; ++i)
                {
                    if((thisCurNode._data).CompareTo(curNode._data) != 0)
                    {
                        return false;
                    }
                    thisCurNode = thisCurNode._nextNode;
                    curNode = curNode._nextNode;
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
                Node<T> curNode = _headNode;
                for(int i = 0; i < _length; ++i)
                {
                    ans += $"{curNode._data} ";
                    curNode = curNode._nextNode;
                }

                return ans;
            }
        }

    }
}
