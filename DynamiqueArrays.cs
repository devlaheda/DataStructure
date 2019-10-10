using System;
using System.Data;
using System.Diagnostics;

namespace DataStructures
{
    class DynamiqueArrays <T>
    {
        private T[] arr;
        private int capacity = 0;
        private int len = 0;

        public DynamiqueArrays()
        : this(16)
        {
        }

        public DynamiqueArrays(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Illegal Capcity for an array");
            }

            this.capacity = capacity;
            arr = new T[capacity];
        }

        public int Size => this.capacity;
        public bool IsEmpty => (this.Size == 0);

        public T GetElementAt(int index)
        {
            if (!(index > this.len || IsEmpty))
            {
                return arr[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException("index out of range");
            }
        }

        public void SetElementAt(int index , T element)
        {
            if (!(index > this.len || IsEmpty))
            {
                arr[index] = element;
            }
            else
            {
                throw new ArgumentOutOfRangeException("index out of range");
            }
        }


    }

}