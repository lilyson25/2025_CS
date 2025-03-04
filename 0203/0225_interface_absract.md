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
## absract 클래스 (추상클래스)
> 공통된 기능을 제공하고 일부 메서드는 자식 클래스에서 구현하도록 강제.

## 더블 버퍼링 :  backBuffer, frontBuffer사용해서 화면 깜빡임(flickering) 현상을 줄이고 부드러운 렌더링을 위해 사용하는 기법
> backBuffer(백 버퍼): 연산 중인 임시 버퍼 (보이지 않음)
> frontBuffer(프론트 버퍼): 실제 화면에 출력하는 버퍼

> 📌 더블 버퍼링(Flip) 과정
* 1. backBuffer에 새로운 프레임 데이터를 저장
* 2. frontBuffer와 backBuffer를 비교
* 3. 값이 다르면 frontBuffer를 갱신하고 콘솔에 출력
* 4. 이 과정을 반복하여 화면 깜빡임 없이 부드럽게 갱신
```
 for (int Y = 0; Y < 20; ++Y)
 {
     for (int X = 0; X < 40; ++X)
     {
         if (Engine.frontBuffer[Y, X] != Engine.backBuffer[Y, X])
         {
             Engine.frontBuffer[Y, X] = Engine.backBuffer[Y, X];
             Console.SetCursorPosition(X, Y);
             Console.Write(backBuffer[Y, X]);
         }
     }
 }
```
## Time 클래스
> 이전 프레임과 현재 프레임 사이의 시간차이(Delta Time)을 계산하여 게임이나 애니메이션 업데이트 시 활용 할 수 있다

> 게임 내의 물체를 시간에 따라 일정 속도로 이동시키기 위해 사용하는 코드 
```
Time을 활용하는 주요 방법
1. 프레임 간 이동량 조절 (위 예제처럼 speed * deltaTime 활용)
2. 애니메이션 타이밍 조정 (일정 시간 후 실행하는 기능 만들 때)
3. 시간 제한 기능 (예: if (Time.deltaTime > 5000) { 실행 })
4. 물리 연산을 일정하게 유지 (컴퓨터 성능에 따라 움직임 속도가 달라지는 문제 방지)
```
> 예시
```
class Program
{
    static float position = 0f;
    static float speed = 50f;  // 초당 이동 속도

    static void Main()
    {
        Time.Update();  // 초기화    
        while (true)  // 무한 루프 (게임 루프처럼 사용)
        {
            Time.Update();  // 매 프레임 시간 업데이트
            MoveObject();
            Console.WriteLine($"Position: {position}");
            System.Threading.Thread.Sleep(100);  // 100ms마다 업데이트→ 루프 속도를 조절 (100ms 마다 실행)
        }
    }

    static void MoveObject()
    {
        position += speed * (Time.deltaTime / 1000f);  
        // deltaTime이 ms 단위이므로 초 단위로 변환
    }
}
```
> Time.deltaTime을 이용하는 이유 -> 💡 프레임 속도(FPS)가 달라도 같은 속도로 이동하기 위해!
  >> 프레임(FPS)이 다르면 Time.deltaTime 값도 달라지지만, speed * Time.deltaTime 방식으로 보정하면 동일한 속도를 유지할 수 있음!
