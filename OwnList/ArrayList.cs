using System;

namespace OwnList
{
    public class ArrayList<T> where T : IComparable
    {
        public int _length { get; private set; }

        public T[] _arr;


        
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
        public void PushPos(T value, int num)
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
        
        public void PushPos(T[] arr, int num)
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

        public T PopBack()
        {
            if(_length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            T result = _arr[_length - 1];

            --_length;

            return result;
        }

        public T PopPos(int num)
        {
            if( num >= _length || num < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            T result = _arr[num];

            for (int i = _length - 1; i > num; --i)
            {
                _arr[i - 1] = _arr[i];
            }

            --_length;

            return result;
        }


        public T PopFront()
        {
            if (_length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            T result = _arr[0];

            for (int i = _length - 1; i >= 0; ++i)
            {
                _arr[i - 1] = _arr[i];
            }

            --_length;

            return result;
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
                str += _arr[i] + "; ";
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
