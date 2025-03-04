using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


//iterator
//c memcpy
//[][][][][][][][][][][]
namespace L20250225
{
    public class DynamicArray<T> : IEnumerable<T>, IEnumerable
    {
        protected T[] data;
        protected int count;

        public DynamicArray()
        {
            data = new T[10];
            count = 0;
        }

        public void Add(T newData)
        {
            if (count >= data.Length)
            {
                T[] newArray = new T[data.Length * 2];
                Array.Copy(data, newArray, data.Length);
                data = newArray;
            }
            data[count] = newData;
            count++;
        }

        //[][][2][][][]
        public void RemoveAt(int index)
        {
            for (int i = index + 1; i < data.Length; ++i)
            {
                data[i - 1] = data[i];
            }
            count--;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; ++i)
            {
                yield return data[i];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 0; i < count; ++i)
            {
                yield return data[i];
            }
        }
    }

    class Program
    {
        //  
        //[][][][][][]
        //   ^ //yield return 1;
        static void Main(string[] args)
        {
            DynamicArray<int> dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);
            dynamicArray.Add(4);

            foreach (var value in dynamicArray)
            {
                Console.WriteLine(value);
            }
        }

        class Component
        {
            public virtual void OnTriggerEnter() { }
            public virtual void OnTriggerExt() { }
        }
    }
}