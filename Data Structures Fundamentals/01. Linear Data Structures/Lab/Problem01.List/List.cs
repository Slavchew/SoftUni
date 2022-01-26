namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List()
            : this(DEFAULT_CAPACITY) {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this._items[index];
            }
            set
            {
                ValidateIndex(index);
                this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            GrowIfNecessary();
            this._items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            bool isExist = false;
            for (int i = 0; i < this._items.Length; i++)
            {
                if (object.Equals(item, _items[i]))
                {
                    isExist = true;
                }
            }

            return isExist;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < this._items.Length; i++)
            {
                if (object.Equals(item, _items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            GrowIfNecessary();

            for (int i = Count; i > index; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < this._items.Length; i++)
            {
                if (object.Equals(item, _items[i]))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = index; i < this.Count - 1; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this._items[this.Count - 1] = default;
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();

        private T[] Grow(T[] items)
        {
            T[] newArr = new T[this.Count * 2];

            for (int i = 0; i < items.Length; i++)
            {
                newArr[i] = items[i];
            }

            return newArr;
        }

        private void GrowIfNecessary()
        {
            if (this._items.Length == Count)
            {
                _items = Grow(_items);
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }
    }
}