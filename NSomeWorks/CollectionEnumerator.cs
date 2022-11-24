using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class CollectionEnumerator<T> : IEnumerator<T>
    {
        int _position = -1;
        T[] _collectionBase;

        public CollectionEnumerator(T[] collection)
        {
            _collectionBase = collection;
        }

        public T Current
        {
            get
            {
                if (_position == -1 || _position >= _collectionBase.Length)
                {
                    throw new InvalidOperationException();
                }

                return _collectionBase[_position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool MoveNext()
        {
            if (_position < _collectionBase.Length - 1)
            {
                _position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
