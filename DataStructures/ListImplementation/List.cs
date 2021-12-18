﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace ListImplementation
{
    public class List<T> : IList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] _items;

        public List()
            => this._items = new T[DefaultCapacity];

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this._items = new T[capacity];
        }

        public List(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            if (collection is ICollection<T> collectionAsICollection)
            {
                var count = collectionAsICollection.Count;

                if (count == 0)
                {
                    this._items = new T[0];
                }
                else
                {
                    this._items = new T[count];
                    this.Count = count;
                    collectionAsICollection.CopyTo(this._items, 0);
                }
            }
            else
            {
                this.Count = 0;

                using IEnumerator<T> collectionEnumerator = collection.GetEnumerator();

                while (collectionEnumerator.MoveNext())
                {
                    this.Add(collectionEnumerator.Current);
                }
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly
            => false;

        public T this[int index]
        {
            get
            {
                if (!this.IsValidIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }

                return this._items[index];
            }
            set
            {
                if (!this.IsValidIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }

                this._items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (this._items.Length == this.Count)
            {
                var newItemsArr = new T[this.Count * 2];
                this._items.CopyTo(newItemsArr, 0);
                this._items = newItemsArr;
            }

            this._items[this.Count] = item;

            this.Count++;
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private bool IsValidIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                return false;
            }

            return true;
        }
    }
}
