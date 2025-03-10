# OOP로 게임엔진 만들기
```
Engine (>World>GameObject)
while(true)
{
Input();
Update();
Render();
}
```
# 회전값
> x축을 롤(roll): 옆으로 돈다, y축을 피치(pitch): 끄덕이다, z축을 요(yaw)
# Mathf.SmoothDamp
> 카메라 설정시 플레이어를 따라가는 부드러운 움직임을 위해 Mathf.Lerp 보다는 Mathf.SmoothDamp으로 부드럽게 따라가게 설정
# FOV(Field Of View) 시야각
> 값이 커지면-> 멀리있는 것 처럼 다 보이게
![image](https://github.com/user-attachments/assets/c8bbe20e-819e-4c69-8160-422b345fb3c8)
> 센서를 상하좌우로 움직였을 때 얻을 수 있는 최대한의 범위를 의미하며, IFOV(Instantaneous Field Of View)
![image](https://github.com/user-attachments/assets/913fc280-0795-4e52-94a6-3c08f7ec87c5)

# Unity> texture (이미지)
> Texture Type : Sprite
> Max Size : 최대 크기를 정해놓는다
> Format : 손실률을 고려해서 
> Compression :

# Sprite sheets
# Invoke 지연함수
# 리플렉션 Reflection : 컴포넌트 기반 아키텍쳐에서 사용
```
﻿using System;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace L20250217
{
    public class Program
    {
        class Data
        {
            public void Count()
            {
                Console.WriteLine("Count");
            }

            private void FuncA()
            {
                Console.WriteLine("private FuncA by 태규");
            }

            protected void Sum()
            {
                Console.WriteLine("protected Sum by 명찬");
            }

            public static void StaticFunction()
            {
                Console.WriteLine("StaticFunction");
            }

            public static void Add(int A, int B)
            {
                Console.WriteLine($"{A} + {B} = {A + B}");
            }

            public int Gold = 1;

            protected int Money = -1000;

            private float HP = -10.5f;

            public int MP
            {
                get;
                set;
            }
        }

        static void Main(string[] args)
        {
            Data d = new Data();
            Type classType = d.GetType();

            MethodInfo[] methods = classType.GetMethods(BindingFlags.Public |
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (MethodInfo info in methods)
            {
                //Console.WriteLine($"{info.Name}");
                if (info.Name.CompareTo("Add") == 0)
                {
                    ParameterInfo[] paramInfos = info.GetParameters();
                    foreach (ParameterInfo paramInfo in paramInfos)
                    {
                        Console.WriteLine(paramInfo.Name);
                    }

                    Object[] param = { 3, 5 };
                    info.Invoke(d, param);
                }
            }

            FieldInfo[] fields = classType.GetFields(BindingFlags.Public |
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (FieldInfo field in fields)
            {
                Console.WriteLine($"{field.FieldType} {field.Name} {field.GetValue(d)}");
                field.SetValue(d, 10);
                Console.WriteLine($"{field.FieldType} {field.Name} {field.GetValue(d)}");
            }

            PropertyInfo[] propertyInfos = classType.GetProperties(BindingFlags.Public |
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Console.WriteLine($"{propertyInfo.Name} {propertyInfo.GetValue(d)}");

            }
        }
    }
}
```
# C# 메소드 기본인자 
> 기본 매게변수 : 안쓰면 기본값 적용됨


