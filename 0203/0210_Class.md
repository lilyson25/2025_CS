# 오늘 수업

* int
* float
* byte
* char = ' '
* string -> c#에만 존재 
* bool -> false != 0, 1 != true (c#에서는 에러남) ex)while(true) 라고 써야지 while(1)이라고 쓰면 에러남
--- 
* 변수 선언 -> 메모리에 공간 잡기 (배열로)
  * int[] A; 자료를 저장, 화면 맵핑[2,2]
* for(;;);
* if()
---
### 함수
> 함수의 실행단계 : 입력 > 처리> 출력
```
반환형 함수명(인자)
{
 return 반환형;
}
``` 
---
### 메모리 구조
> "스택에 할당된 변수에 접근하는 것이 힙에 할당된 변수에 접근하는 것보다 빠르다"

![image](https://github.com/user-attachments/assets/a0cf4230-20ca-4e09-afb9-5ee35389b421)

#### code 영역
- 소스코드가 기계어 형태로 저장된다.
- CPU가 여기에 저장된 명령어를 하나씩 가져가 처리하게 된다.
- 프로그램 시작~종료까지 메모리에 있게 된다.

#### data 영역
- global변수, static변수가 저장된다.
- 프로그램 시작과 동시에 할당, 종료되면 메모리를 해제하게 된다.

#### heap 영역
- heap 영역은 동적할당영역
- 런타임에 크기가 결정 된다.
- Reference Type

#### stack 영역
- 지역변수, 매개변수, 포인터 등이 저장됨
- 컴파일타임에 크기 결정
- Value Type

- | 구분         | 값 형식 (Value Type) | 참조 형식 (Reference Type) |
|-------------|-------------------|----------------------|
| 저장 위치    | **Stack** (스택)   | **Heap** (힙)       |
| 데이터 저장 방식 | **직접 값 저장**   | **메모리 주소(참조) 저장** |
| 크기 관리    | 크기가 고정됨      | 크기가 가변적        |
| 성능        | 빠름 (Stack에서 바로 접근) | 상대적으로 느림 (Heap에서 참조 후 접근) |
| 복사 방식    | 값 자체를 복사     | 참조(주소)를 복사    |
| 가비지 컬렉션 | 영향 없음        | **GC의 대상** (더 이상 참조되지 않으면 해제됨) |
| 대표적인 예  | `int`, `float`, `bool`, `struct`, `char` | `string`, `class`, `object`, `array`, `delegate` |
| 사용 방식    | `int a = 10; int b = a;` (값 자체 복사) | `MyClass obj1 = new MyClass(); MyClass obj2 = obj1;` (참조 복사) |

##### 정리
- **값 형식(Value Type)**: 변수를 복사할 때 **값 자체가 복사**됨. (독립적인 데이터)
- **참조 형식(Reference Type)**: 변수를 복사할 때 **메모리 주소가 복사**됨. (같은 데이터 참조)
- **Stack (스택)**: 빠르게 할당되고, 함수가 끝나면 자동 해제됨.
- **Heap (힙)**: 크기가 동적이며, 가비지 컬렉션(GC)에 의해 관리됨.
---
### 재귀함수
---
### Class : custom data type
> 절차지향 프로그래밍(입력>처리>출력) -> 객체지향 프로그래밍(물체를 지향으로 본다> class를 설계한다)  : sturct vs class

```
    class Apple
    {
        public static void Die() //전역함수, 미리 Code로 선언된 것이기때문에 main에서 바로 호출가능
        {
            Console.WriteLine("죽었ㄷ");
        }
        static void Main(string[] args)
        {
        Apple.Die();
        }
}
```
---
## 데이터 모델링
### Class 설계하기
> 명사는 class를 만들고, 동사로 함수(메소드)를 만든다
---
### 삼항 연산자: if-else의 축약형
> (조건식) ? 참일 때 반환 값 : 거짓일 때 반환 값;
```
return (x>y) ? x : y; 
```
```
if (x > y)
{
    return x;
}
else
{
    return y;
}
```
