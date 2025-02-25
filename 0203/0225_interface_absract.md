# interface 키워드
> 구체적인 구현이 없고, 단지 메서드 시그니처(이름, 매개변수, 반환형)만 정의 : void Speak();

> 함수 강제 구현, 다중 상속

> new로 새로 만들 수 없다, 무조건 상속

## IEnumerator, yield 상태를 기억하면서 중단 및 재개 가능
> Interator

> foreach 문(범위 기반) 사용한다

> yield return
#### 🚀 `yield return` 종류 요약

| `yield return` | 설명 | 예시 |
|--------------|--------------------------------------|--------------|
| `null` | 다음 프레임까지 대기 | yield return null; |
| `WaitForSeconds(float)` | 일정 시간 대기 (`Time.timeScale` 영향 받음) | yield return new WaitForSeconds(3f);  // 3초 대기 |
| `WaitForSecondsRealtime(float)` | 실제 시간 기준 대기 (`Time.timeScale` 영향 X) | yield return new WaitForSecondsRealtime(2f);  // 실제 시간 기준 2초 대기(Pause에서도 정확한 시간 측정 필요할 때) |
| `WaitUntil(Func<bool>)` | 특정 조건이 `true`가 될 때까지 대기 | yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space)); // 스페이스바 입력 시 실행 |
| `WaitWhile(Func<bool>)` | 특정 조건이 `false`가 될 때까지 대기 ||
| `WaitForEndOfFrame()` | 현재 프레임이 끝날 때까지 대기 ||
| `WaitForFixedUpdate()` | 다음 `FixedUpdate()`까지 대기 ||
| `StartCoroutine(다른 코루틴)` | 다른 코루틴 실행 후 대기 ||
| `yield break;` | 코루틴 강제 종료 ||


> 아래 예시처럼 'Speak()' 라는 메서드 호출을 강제하는 규약을 제공
```
public interface IAnimal //IAnimal처럼 앞에 I를 붙인다
{
    void Speak();  // 인터페이스에서 메서드 시그니처만 정의
}
public class Dog : IAnimal
{
    // IAnimal 인터페이스에서 요구하는 Speak 메서드를 구현
    public void Speak()
    {
        Console.WriteLine("Woof!");
    }
}
public class Cat : IAnimal
{
    // IAnimal 인터페이스에서 요구하는 Speak 메서드를 구현
    public void Speak()
    {
        Console.WriteLine("Meow!");
    }
}

IAnimal dog = new Dog();
dog.Speak();  // Woof!

IAnimal cat = new Cat();
cat.Speak();  // Meow!
```
### DynamicArray<T> : IEnumerable<T>, IEnumerable
```
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
```
# absract 클래스 (추상클래스)
> 공통된 기능을 제공하고 일부 메서드는 자식 클래스에서 구현하도록 강제.
