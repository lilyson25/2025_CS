﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0217
{
    class DynamicArray
    {
        public DynamicArray()
        {

        }

        ~DynamicArray()
        {

        }

        //objects
        //[1][2][3]
        // ^  ^  ^  ^
        //newObjects
        //[1][2][3][][][]
        //          ^
        //objects <- newObjects 
        //[1][2][3][4][][]
        //          ^
        public void Add(Object inObject)
        {
            if (count >= objects.Length)
            {
                ExtendSpace();
            }
            objects[count] = inObject;
            count++;
        }

        protected void ExtendSpace()
        {
            //배열 늘이기
            //이전 정보 옮기기
            Object[] newObject = new Object[objects.Length * 2];
            //이전값 이동
            for (int i = 0; i < objects.Length; ++i)
            {
                newObject[i] = objects[i];
            }
            objects = null;
            objects = newObject;
        }

        //[][][][][]
        public bool Remove(Object removObject)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (removObject == objects[i])
                {
                    return RemoveAt(i);
                }
            }

            return false;
        }

        //[][][][][][]
        public bool RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                for (int i = index; i < Count - 1; ++i)
                {
                    objects[i] = objects[i + 1];
                }

                count--;
                return true;
            }

            return false;
        }

        //[1][2][3]
        //Insert(2, 5);
        //[1][2][3][4]
        public void Insert(int insertIndex, Object value)
        {
            //3 == 3  + 1 -> [1][2][3] - >[1][2][3][][][]
            //1. object.length == count
            //확장
            //추가 
            //3 == 2 + 1     [1][2][3][][][]
            //2. object.length < count
            //확장 X
            //추가
            if (objects.Length == count)
            {
                ExtendSpace();
            }


            for (int i = count; i > insertIndex; --i)
            {
                objects[i] = objects[i - 1];
            }
            objects[insertIndex + 1] = value;
            count++;
        }

        protected Object[] objects = new Object[10];

        protected int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public Object this[int index]
        {
            get
            {
                return objects[index];
            }
            set
            {
                if (index < objects.Length)
                {
                    objects[index] = value;
                }
            }
        }
    }

    //Generic
    //형태가 동일 해져서 버그 발생이 적어짐
 


    class Program
    {
        //C# 기본예약어, 객체 프로그래밍 해요, Collection 사용 할줄 알아요. Array, DynamicArray -> 만들어 봤어?
        // 최적화
        //Byte -> BitArray

        //oveloading
        //Generic Progrmmaing -> meta programming
        static public void Print<T>(T[] data)
        {
            for (int i = 0; i < data.Length; ++i)
            {
                Console.WriteLine(data[i]);
            }
        }


        //static public T Add<T>(T A, T B) where T : struct {}
        //{
        //    return A + B;
        //}

        //static public void Print(char[] data)
        //{
        //    for (int i = 0; i < data.Length; ++i)
        //    {
        //        Console.WriteLine(data[i]);
        //    }
        //}

        //static public void Print(string[] data)
        //{
        //    for (int i = 0; i < data.Length; ++i)
        //    {
        //        Console.WriteLine(data[i]);
        //    }
        //}

        class A : IComparable
        {
            public int CompareTo(object obj)
            {
                throw new NotImplementedException();
            }
        }

        static void Main(string[] args)
        {

            //int[] numbers = { 1, 2, 3, 4 };
            //char[] numbersToChar = { 'A', 'B', 'C', 'D' };
            //string[] numbersToString = { "1111", "2222", "3333", "4444" };
            //GameObject[] gameObjects = new GameObject[3];

            //gameObjects[0] = new GameObject();
            //gameObjects[1] = new GameObject();
            //gameObjects[2] = new GameObject();

            //return;

            //[] ->                  variable
            //[][][][][]             array -> Array
            //[][][][][][][][][][]   DynamicArray
            //DataStructure          자료구조
            //
            TDynamicArray<int> a = new TDynamicArray<int>();
            for (int i = 0; i < 10; ++i)
            {
                a.Add(i);
            }

            a[1] = 11;
            a[9] = 29;

            a.RemoveAt(9);
            a.RemoveAt(1);
            a.RemoveAt(3);
            a.Insert(2, 11);

            a.Remove(7);

            TDynamicArray<GameObject> gameObjects = new TDynamicArray<GameObject>();

            GameObject testObject = new GameObject();
            gameObjects.Add(testObject);
            Console.WriteLine(gameObjects.Count);

            gameObjects.Remove(testObject);
            Console.WriteLine(gameObjects.Count);

            //for (int i = 0; i < a.Count; ++i)
            //{
            //    Console.Write(a[i] + ", ");
            //}
        }
    }
}
