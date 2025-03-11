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

# 연산자
### 산술/ 비교/ 논리/ 연산자
### 삼향연산자 : 불_표현식 ? 참 : 거짓
> if 조건문과 switch 조건문 이외에도 조건을 구분할 때 사용할 수 있는 삼항 연산자
> 참 : 거짓 = 참일경우 실행할 것 : 거짓일 경우 실행할 것
```
// 참과 거짓 위치에 불 자료형 사용
Console.WriteLine(number % 2 == 0 ? true : false);

// 참과 거짓 위치에 문자열 자료형 사용
Console.WriteLine(1 > 0 ? "가나다" : "ABC");
```
# 배열
### Array -> 탐색
```
static void Main(string[] arg)
{
    int[] intArray = { 10, 11, 19, 200, -100 };
    float[] floatArray = { 1.0F, 2.0F, 5.0F };
    string[] stringArray = { "조건문", "반복문", "자료형" };
}
```
### for -> 배열을 처음부터 끝까지 
### foreach(var element in data) : 자료형을 꺼내달라 
### if, switch

# class를 만들때 동사를 method, 명사를 field로 
### class를 추상화(상위)하기 위해 부모와 자식, 즉 상속의 관계가 만들어짐
> 부모 형태 메모리공간 자식을 형태로 연결하고 싶다
> class생성하면 참조형

### 다형성
> 부모형태에 변수에 다 연결할 수 있고 실제 내용이 몬지에 따라 실행결과가 달라진다. : virtual, override
> 여기서 생겨난 패턴 그리고 디자인패턴, 예) 제네릭 function Add<T>(T, T) where T : new, Component

# Array를 확장하면 **자료구조**
> 자료를 어떻게 효율적으로 저장하고 크기를 늘이고 탐색을 빠르게 할 것인가?
> Sort 순서(예:동적배열, 트리)/ Saarch 알고리즘

# Custom Component -> Script : 고려사항
> 한가지 일만한다
> 다른 컴포넌트랑 상관없이 동작하게 만든다 (결합성이 낮게 한다)

# delegate (람다식이 있으면, delegate가 쓰이고 잇다..)
> 익명함수() => {}

