using System;

namespace OwnList
{
    
    public class ArrayList<T> where T : IComparable
    {
        private int _length { get; set; }

        private T[] _arr;


        
        public ArrayList()
        {
            _arr = new T[1];
            _length = 0;
        }

        public ArrayList(T value)
        {
            _arr = new T[2];
            _arr[0] = value;
            _length = 1;
        }

        public ArrayList(T[] arr)
        {
            int len = 1;
            while(len <= arr.Length)
            {
                len *= 2;
            }

            _length = arr.Length;
            _arr = new T[len];

            for(int i = 0; i < arr.Length; ++i)
            {
                _arr[i] = arr[i];
            }
        }

        public void PushBack(T value)
        {
            if(_length + 1 >= _arr.Length)
            {
                IncreaseLength(_arr.Length + 1);
            }

            _arr[_length] = value;
            ++_length;
        }
        public void PushBack(T[] arr)
        {
            if(_length + arr.Length >= _arr.Length)
            {
                IncreaseLength(_arr.Length + arr.Length);
            }

            for(int i = 0; i < arr.Length; ++i)
            {
                _arr[i + _length] = arr[i];
            }

            _length += arr.Length;
        }
        public void PushByIndex(T value, int num)
        {
            if (num > _length || num < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (_length + 1 >= _arr.Length)
            {
                IncreaseLength(_arr.Length + 1);
            }

            for (int i = _length; i > num; --i)
            {
                _arr[i] = _arr[i - 1];
            }

            _arr[num] = value;

            _length += 1;
        }
        
        public void PushByIndex(T[] arr, int num)
        {

            if (num > _length || num < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (_length + arr.Length >= _arr.Length)
            {
                IncreaseLength(_arr.Length + arr.Length);
            }

            for (int i = _length + arr.Length; i > num + arr.Length - 1; --i)
            {
                _arr[i] = _arr[i - arr.Length];
            }

            for(int i = 0; i < arr.Length; ++i)
            {
                _arr[i + num] = arr[i];
            }

            _length += arr.Length;
        }

        public void PushFront(T value)
        {
            if(_length + 1 >= _arr.Length)
            {
                IncreaseLength(_arr.Length + 1);
            }

            for(int i = _length; i > 0; --i)
            {
                _arr[i] = _arr[i - 1];
            }

            _arr[0] = value;
            ++_length;
        }
        public void PushFront(T[] arr)
        {
            if(_length + arr.Length >= _arr.Length)
            {
                IncreaseLength(_arr.Length + arr.Length);
            }

            for (int i = _length + arr.Length; i >  arr.Length - 1; --i)
            {
                _arr[i] = _arr[i - arr.Length];
            }

            for (int i = 0; i < arr.Length; ++i)
            {
                _arr[i] = arr[i];
            }

            _length += arr.Length;
        }

        public void PopBack()
        {
            if(_length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            T result = _arr[_length - 1];

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
                _length = 0;
            }
            else
            {
                _length -= amount;
            }
        }

        public void PopByPos(int num)
        {
            if( num >= _length || num < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            T result = _arr[num];

            for (int i = num; i < _length - 1; ++i)
            {
                _arr[i] = _arr[i + 1];
            }

            --_length;

        }
        

        public void PopByPosAmount(int index, int amount)
        {
            if (_length == 0 || index + amount > _length || amount < -1 || index < -1)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (_length == 1 || amount == _length)
            {
                _length = 0;
            }
            else if(index == 0)
            {
                PopFrontAmount(amount);
            }
            else
            {
                for (int i = index; i < index + amount; ++i)
                {
                    for (int j = i; j < _length - 1; ++j)
                    {
                        _arr[j] = _arr[j + 1];
                    }
                    --_length;
                }
            }
        }


        public void PopFront()
        {
            if (_length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            T result = _arr[0];

            for (int i = 0; i < _length - 1; ++i)
            {
                _arr[i] = _arr[i + 1];
            }

            --_length;
        }

        public void PopFrontAmount(int amount)
        {
            if (_length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (amount > _length || amount < 0)
            {
                throw new NullReferenceException();
            }

            while(amount != 0)
            {
                for(int i = 0; i < _length - 1; ++i)
                {
                    _arr[i] = _arr[i + 1];
                }
                --amount;
                --_length;
            }

        }   

        public void PopByValue(int value)
        {

            for(int i = 0; i < _length; ++i)
            {
                if(_arr[i].CompareTo(value) == 0)
                {
                    for (int j = i; j < _length - 1; ++j)
                    {
                        _arr[j] = _arr[j + 1];
                    }
                    --_length;
                    return;
                }
            }
        }
        public void PopByValueAll(int value)
        {

            for(int i = 0; i < _length; ++i)
            {
                if(_arr[i].CompareTo(value) == 0)
                {
                    for (int j = i; j < _length - 1; ++j)
                    {
                        _arr[j] = _arr[j + 1];
                    }
                    --i;
                    --_length;
                }
            }
        }

        public int GetLength()
        {
            return _length;
        }
        public int Find(T value)
        {
            for(int i = 0; i < _length; ++i)
            {
                if(_arr[i].CompareTo(value) == 0)
                {
                    return i;
                }
            }
            throw new Exception();
        }

        public void Reverse()
        {
            T temp;

            for(int i = 0; i < _length / 2; ++i)
            {
                temp = _arr[i];
                _arr[i] = _arr[_length - 1 - i];
                _arr[_length - 1 - i] = temp;
            }

        }

        public void Sort(int l, int r)
        {
            if (r - l == 2)
            {
                if(_arr[l].CompareTo(_arr[r - 1]) > 0)
                {
                    T tmp = _arr[r - 1];
                    _arr[r - 1] = _arr[l];
                    _arr[l] = tmp;
                }
            }
            else if(r - l > 2)
            {
                int midle = (l + r) / 2;
                Sort(l, midle);
                Sort(midle, r);

                T[] tmpArr = new T[r - l];

                int amountLeft = midle - l;
                int amountRight = r - midle;

                int leftIndex = l;
                int rightIndex = midle;

                int index = 0;

                while(amountLeft != 0 && amountRight !=0)
                {
                    if (_arr[leftIndex].CompareTo(_arr[rightIndex]) > 0)
                    {
                        tmpArr[index] = _arr[rightIndex];
                        ++rightIndex;
                        ++index;
                        --amountRight;
                    }
                    else
                    {
                        tmpArr[index] = _arr[leftIndex];
                        ++leftIndex;
                        ++index;
                        --amountLeft;
                    }
                }
                
                if(amountLeft == 0)
                {
                    leftIndex = rightIndex;
                }

                while(index < r - l)
                {
                    tmpArr[index] = _arr[leftIndex];
                    ++leftIndex;
                    ++index;
                }

                for(int i = 0; i < r - l; ++i)
                {
                    _arr[l + i] = tmpArr[i];
                }
                
            }

        }
        public T FindMax()
        {
            if (_length == 0)
            {
                throw new Exception("List is empty");
            }
            T max = _arr[0];

            for (int i = 0; i < _length; ++i)
            {
                if(_arr[i].CompareTo(max) > 0)
                {
                    max = _arr[i];
                }
            }

            return max;
        }
        public int FindMaxIndex()
        {
            if (_length == 0)
            {
                throw new Exception("List is empty");
            }
            T max = _arr[0];
            int indexOfMax = 0;
            for (int i = 0; i < _length; ++i)
            {
                if (_arr[i].CompareTo(max) > 0)
                {
                    max = _arr[i];
                    indexOfMax = i;
                }
            }

            return indexOfMax;
        }
        public int FindMinIndex()
        {
            if (_length == 0)
            {
                throw new Exception("List is empty");
            }
            T min = _arr[0];
            int indexOfMin = 0;
            for (int i = 0; i < _length; ++i)
            {
                if (_arr[i].CompareTo(min) < 0)
                {
                    min = _arr[i];
                    indexOfMin = i;
                }
            }

            return indexOfMin;
        }
        public T FindMin()
        {
            if (_length == 0)
            {
                throw new Exception("List is empty");
            }
            T min = _arr[0];

            for (int i = 0; i < _length; ++i)
            {
                if (_arr[i].CompareTo(min) < 0)
                {
                    min = _arr[i];
                }
            }

            return min;
        }
        public T this[int index]
        {
            get
            {
                if (index > _length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _arr[index];
            }
            set
            {
                if (index > _length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                _arr[index] = value;
            }
        }
        private void IncreaseLength(int necessaryLength)
        {
            int Length = 1;
            while(Length <= necessaryLength)
            {
                Length *= 2;
            }

            T[] arr = new T[Length];
            Array.Copy(_arr, arr, _length);
            _arr = arr;
        }

        public override string ToString()
        {
            string str = "";

            for(int i = 0; i < _length; ++i)
            {
                str += _arr[i] + " ";
            }

            return str;
        }



        public override bool Equals(object obj)
        {
            ArrayList<T> arrayList = (ArrayList<T>)obj;

            if (_length != arrayList._length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < _length; i++)
                {


                    if (_arr[i].CompareTo(arrayList._arr[i]) != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
