using System;
using _03_GenericList.Interfaces;
using _03_GenericList.Attributes;

namespace _03_GenericList
{
    [Version(42,0)]
    public class GenericList<T>:IGenericList<T> where T:IComparable
    {
        private const int DefaultCapacity = 16;
        private T[] elements;
        private int count = 0;

        public GenericList(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }

        public void Add(T newElement)
        {
            if (this.elements.Length == this.count)
            {
                this.ExtendArray();
            }
            this.elements[this.count] = newElement;
            this.count++;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0} while retrieving list element.", index));
                }

                T result = this.elements[index];

                return result;
            }
            set
            {
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0} while setting list element.", index));
                }

                this.elements[index] = value;

            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Invalid index: {0} while removing element.", index));
            }

            T[] newElements = new T[this.elements.Length];
            Array.Copy(this.elements, newElements, index);
            if (index < this.elements.Length - 1)
            {
                Array.Copy(this.elements, index + 1, newElements, index, 
                    this.elements.Length - index - 1);
            }
            
            this.elements = newElements;
            this.count--;
        }

        public void Insert(T newElement, int index)
        {
            if (index < 0 || index > this.count)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Invalid index: {0} while inserting element.", index));
            }

            if (this.elements.Length == this.count)
            {
                this.ExtendArray();
            }

            T[] newElements = new T[this.elements.Length];
            Array.Copy(this.elements, newElements, index);
            newElements[index] = newElement;
            this.count++;
            if (index < this.elements.Length - 1)
            {
                Array.Copy(this.elements, index, newElements, index+1,
                    this.elements.Length - index - 1);
            }
            this.elements = newElements;
        }

        public void Clear()
        {
            this.elements = new T[DefaultCapacity];
            this.count = 0;
        }

        public int FindIndex(T val)
        {
            int result = -1;
            for (int i = 0; i < this.count; i++)
            {
                if (this.elements[i].CompareTo(val) == 0)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        public bool Contains(T val)
        {
            return (this.FindIndex(val) != -1);
        }

        public T Min()
        {
            T min = this.elements[0];
            for (int i = 1; i < this.count; i++)
            {
                if (this.elements[i].CompareTo(min) == -1)
                {
                    min = this.elements[i];
                }
            }
            return min;
        }

        public T Max()
        {
            T max = this.elements[0];
            for (int i = 1; i < this.count; i++)
            {
                if (this.elements[i].CompareTo(max) == 1)
                {
                    max = this.elements[i];
                }
            }
            return max;
        }

        public override string ToString()
        {
            //string will contain only elements that have been initialized:
            T[] initializedArr = new T[this.count];
            Array.Copy(this.elements, initializedArr, this.count);
            return "[" + String.Join(", ", initializedArr) + "]";
        }

        private void ExtendArray()
        {
            int newCapacity = 2 * this.elements.Length;
            T[] newElements = new T[newCapacity];
            Array.Copy(this.elements, newElements, this.elements.Length);
            this.elements = newElements;
        }
    }
}