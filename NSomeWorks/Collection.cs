using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NSomeWorks
{
    class Collection<T> : ICollection<T>, IComparable<T>
    {
        private T[] _collection;

        public Collection()
        {
            _collection = new T[0];
        }

        public int Count => _collection.Length;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (_collection.Length == 0)
            {
                _collection = new T[1] { item };
            }
            else
            {
                T[] tempArray = _collection;
                _collection = new T[_collection.Length + 1];
                for (int i = 0; i < tempArray.Length; i++)
                {
                    _collection[i] = tempArray[i];
                }

                _collection[_collection.Length - 1] = item;
            }
        }

        public void AddRange(T[] collection)
        {
            T[] tempArray = _collection;
            _collection = new T[_collection.Length + collection.Length];
            for (int i = 0; i < tempArray.Length; i++)
            {
                _collection[i] = tempArray[i];
            }

            for (int i = tempArray.Length; i < _collection.Length; i++)
            {
                _collection[i] = collection[i - tempArray.Length];
            }
        }

        public void Clear()
        {
            _collection = new T[0];
        }

        public bool Contains(T item)
        {
            foreach (var item2 in _collection)
            {
                if (item.GetHashCode() == item2.GetHashCode())
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CollectionEnumerator<T>(_collection);
        }

        public bool Remove(T item)
        {
            int numberRemove = -1;
            for (int i = 0; i < _collection.Length; i++)
            {
                if (_collection[i].GetHashCode() == item.GetHashCode())
                {
                    numberRemove = i;
                    break;
                }
            }

            if (numberRemove > -1)
            {
                T[] tempArray = _collection;

                _collection = new T[_collection.Length - 1];

                int curentItem = -1;

                for (int i = 0; i < tempArray.Length; i++)
                {
                    curentItem++;
                    if (i == numberRemove)
                    {
                        curentItem--;
                        continue;
                    }

                    _collection[curentItem] = tempArray[i];
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            if (index > _collection.Length || index < 0)
            {
                return;
            }

            T[] tempArray = _collection;

            _collection = new T[_collection.Length - 1];

            int curentItem = -1;

            for (int i = 0; i < tempArray.Length; i++)
            {
                curentItem++;
                if (i == index)
                {
                    curentItem--;
                    continue;
                }

                _collection[curentItem] = tempArray[i];
            }
        }

        public T[] GetColection()
        {
            return _collection;
        }

        public int CompareTo([AllowNull] T other)
        {
            if (other is string)
            {
                return CompareTo(other);
            }
            else
            {
                throw new ArgumentException("Некорректное значение параметра");
            }
        }
    }
}