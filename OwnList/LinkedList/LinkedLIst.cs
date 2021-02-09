using System;

namespace OwnList
{

    public class LinkedList<T> where T : IComparable
    {
        public Node<T> _root { get; private set; }
        public int _length { get; private set; }

        public LinkedList()
        {
            _root = null;
            _length = 0;
        }
        public LinkedList(T value)
        {
            _root = new Node<T>(value);
            _length = 1;
        }

        public LinkedList(T[] arr)
        {
            if(arr.Length == 0)
            {
                _root = null;
            }
            else
            {
                Node<T> curNode = new Node<T>(arr[0]);
                _root = curNode;
                for (int i = 1; i < arr.Length; ++i)
                {
                    curNode._next = new Node<T>(arr[i]);
                    curNode = curNode._next;
                }
                _length = arr.Length;
            }
        }

        public void PushBack(T value)
        {
            if(_length == 0)
            {
                _root = new Node<T>(value);
            }
            else
            {
                Node<T> curNode = _root;
                
                while(curNode._next != null)
                {
                    curNode = curNode._next;
                }

                Node<T> newNode = new Node<T>(value);
                curNode._next = newNode;
            }
            _length += 1;
        } 
        public void PushBack(T[] arr)
        {
            Node<T> curNode;

            if (_length == 0)
            {
                curNode = new Node<T>();
                _root = curNode;
            }

            else
            {
                curNode = _root;
                
                while(curNode._next != null)
                {
                    curNode = curNode._next;
                }

                curNode._next = new Node<T>();
                curNode = curNode._next;
            }

            for(int i = 0; i < arr.Length; ++i)
            {
                curNode._data = arr[i];
                if(i != arr.Length - 1)
                {
                    curNode._next = new Node<T>();
                    curNode = curNode._next;
                }
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
                Node<T> tmp = _root;
                _root = new Node<T>(value);
                _root._next = tmp;
            }
            else
            {
                Node<T> curNode = _root;
                for (int i = 0; i < index - 1; ++i)
                {
                    curNode = curNode._next;
                }
                Node<T> tmp = curNode._next;
                curNode._next = new Node<T>(value);
                curNode._next._next = tmp;
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
                    curNode._next = new Node<T>(arr[i]);
                    curNode = curNode._next;
                }
                curNode._next = _root;
                _root = tmp;
            }
            else
            {

                Node<T> curNode = _root;
                for (int i = 0; i < index - 1; ++i)
                {
                    curNode = curNode._next;
                }

                Node<T> tmp = curNode._next;

                for(int i = 0; i < arr.Length; ++i)
                {
                    curNode._next = new Node<T>(arr[i]);
                    curNode = curNode._next;
                }

                curNode._next = tmp;

            }

            _length += arr.Length;
        }

        public void PushFront(T value)
        {
            Node<T> curNode = new Node<T>(value);
            curNode._next = _root;
            _root = curNode;
            _length += 1;
        }
        

        public void PushFront(T[] arr)
        {
            Node<T> tmp = new Node<T>(arr[0]);
            Node<T> curNode = tmp;
            for(int i = 1; i < arr.Length; ++i)
            {
                curNode._next = new Node<T>(arr[i]);
                curNode = curNode._next;
            }
            curNode._next = _root;
            _root = tmp;

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
                _root = null;
            }
            else
            {
                Node<T> curNode = _root;
                for (int i = 0; i < _length - 2; ++i)
                {
                    curNode = curNode._next;
                }

                curNode._next = null;
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
                Node<T> curNode = _root;
                for (int i = 0; i < _length - amount - 1; ++i)
                {
                    curNode = curNode._next;
                }

                curNode._next = null;
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
                _root = null;
            }
            else if (index == 0)
            {
                _root = _root._next;
                
            }
            else
            {
                Node<T> curNode = _root;
                for (int i = 0; i < index - 1; ++i)
                {
                    curNode = curNode._next;
                }

                curNode._next = curNode._next._next;

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
            else if(index == 0)
            {
                Node<T> curNode = _root;
                for (int i = 0; i < amount; ++i)
                {
                    curNode = curNode._next;
                }
                _root = curNode;
            }
            else
            {
                Node<T> curNode = _root;
                for (int i = 0; i < index - 1; ++i)
                {
                    curNode = curNode._next;
                }

                Node<T> tmp = curNode;

                for (int i = 0; i < amount; ++i)
                {
                    curNode = curNode._next;
                }

                tmp._next = curNode;
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
                _root = null;
            }
            else
            {
                Node<T> curNode = _root;
                for(int i = 0; i < amount; ++i)
                {
                    curNode = curNode._next;
                }
                _root = curNode;
            }

            _length -= amount ;
        }
        public void PopByValue(T value)
        {
            if (_length == 0)
            {
                throw new NullReferenceException();
            }
            if(_root == value)
            {
                _root = _root._next;
            }
            else
            {
                Node<T> curNode = _root._next;
                Node<T> prevNode = _root;

                for (int i = 0; i < _length - 2; ++i)
                {
                    if (curNode == value)
                    {
                        prevNode._next = curNode._next;
                        break;
                    }
                    prevNode = curNode;
                    curNode = curNode._next;
                }
            }

            _length -= 1 ;
        }
        public void PopAllByValue(T value)
        {
            if (_length == 0)
            {
                throw new NullReferenceException();
            }

            int numDeletedElems = 0;
            while(_root == value)
            {
                _root = _root._next;
                ++numDeletedElems;
                if(_root == null)
                {
                    _length -= numDeletedElems;
                    return;
                }
            }
            Node<T> curNode = _root._next;
            Node<T> prevNode = _root;

            for (int i = 0; i < _length - 3; ++i)
            {
                if (curNode==value)
                {
                    prevNode._next = curNode._next;
                    ++numDeletedElems;
                }
                prevNode = curNode;
                curNode = curNode._next;
            }

            _length -= numDeletedElems;
        }
        public int Find(T value)
        {
            Node<T> curNode = _root;
            for(int i = 0; i < _length; i++)
            {
                if(curNode == value)
                {
                    return i;
                }
                curNode = curNode._next;
            }

            throw new Exception("No such value");
        }
        
        public Node<T> FindMax()
        {
            if(_length == 0)
            {
                throw new Exception("List is empty");
            }
            Node<T> crnt = _root;
            Node<T> Max = crnt; 

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
            if(_length == 0)
            {
                throw new Exception("List is empty");
            }
            Node<T> crnt = _root;
            Node<T> max = crnt;
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
            Node<T> crnt = _root;
            Node<T> min = crnt;
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
        public Node<T> FindMin()
        {
            if(_length == 0)
            {
                throw new Exception("List is empty");
            }
            Node<T> crnt = _root;
            Node<T> min = crnt; 

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

        public Node<T> GetNode(int index)
        {
            if(_root == null)
            {
                throw new NullReferenceException();
            }
            else if(index >= _length)
            {
                throw new ArgumentException(); 
            }
            else
            {
                Node<T> curNode = _root;
                for(int i = 0; i < index; ++i)
                {
                    curNode = curNode._next;
                }

                return curNode;
            }
        }

        public void Sort(Node<T> ptr1, Node<T> ptr2, int len)
        {
            if(_root == null)
            {
                throw new NullReferenceException();
            }
            else if(len == 2)
            {
                if(ptr1 > ptr2)
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
                    curNode = curNode._next;
                }

                Sort(ptr1, curNode, len / 2);
                Sort(curNode._next, ptr2, len - len / 2 );

                T[] arr = new T[len];
                curNode = curNode._next;
                Node<T> midle = curNode;
                Node<T> first = ptr1;
                int index = 0;

                while (ptr1 != midle && curNode != ptr2._next && curNode != null)
                {
                    if (ptr1 > curNode)
                    {
                        arr[index] = curNode._data;
                        curNode = curNode._next;
                    }
                    else
                    {
                        arr[index] = ptr1._data;
                        ptr1 = ptr1._next;
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
                    curNode = curNode._next;
                    ++index;
                }
                curNode = first;
                for (int i = 0; i < len; ++i)
                {
                    curNode._data = arr[i];
                    curNode = curNode._next;
                }
            }
        }


        

        public void Reverse()
        {
            if(_length == 0)
            {
                throw new NullReferenceException();
            }

            Node<T> oldHeadNode = _root;
            Node<T> temp;

            while (oldHeadNode._next != null)
            {
                temp = oldHeadNode._next;
                oldHeadNode._next = temp._next;
                temp._next = _root;
                _root = temp;
            }

        }
        public void SortReverse()
        {
            Sort(_root, GetNode(_length - 1), _length);
            Reverse();
        }
        public T this[int index]
        {
            get
            {
                if (index >= _length && index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                Node<T> curNode = _root;
                
                for(int i = 0; i < index; ++i)
                {
                    curNode = curNode._next;
                }

                return curNode._data;
                
            }
            set
            {
                if (index >= _length && index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                Node<T> curNode = _root;

                for (int i = 0; i < index; ++i)
                {
                    curNode = curNode._next;
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
                Node<T> thisCurNode = _root;
                Node<T> curNode = linkedList._root;

                for(int i = 0; i < _length; ++i)
                {
                    if(thisCurNode != curNode)
                    {
                        return false;
                    }
                    thisCurNode = thisCurNode._next;
                    curNode = curNode._next;
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
                Node<T> curNode = _root;
                for(int i = 0; i < _length; ++i)
                {
                    ans += $"{curNode._data} ";
                    curNode = curNode._next;
                }

                return ans;
            }
        }

    }
}
