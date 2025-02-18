# Generic (meta programming)
> 자료형(data type)을 Generalize하는 문법
  
> 함수 이름은 같은데, 인자가 다를때 : overloading

> class 에서 쓸수 있음
```
using System.Collections.Generic;

class TDynamicArray<T> where T : class {}. struct{} ...
// (where ~ )를 추가할 수 있다
```
> 장점
  - 코드 중복 제거 → 여러 자료형을 지원하면서 같은 코드를 재사용 가능
  - 유연성 증가 → int, string, float 등 다양한 타입을 지원
  - 안전성 증가 → 컴파일러가 자료형을 체크해줘서 오류 방지
---
### 캡슐화(Encapsulation) 
> 데이터를 보호하고, 외부에서 함부로 변경하지 못하게 하는 개념

> protected 키워드 사용 : 해당 클래스와 상속받은 클래스에서만 접근 가능하도록 접근제한자
---
### Equals
> string -> == 사용X 대신 .Equals 표현

> int, float, char == 사용가능
---
c# : 기본예약어, 객체 프로그래밍, Collection사용, Arraym DynamicArray
---
> 아래 코드 선언순서
  - 데이터 설계: 무엇을 저장할지 먼저 생각 -> objects(배열), count(현재 개수)
  - 기본 구조 작성: 변수, 생성자 먼저 만들기
  - 주요 기능 추가: 하나씩 순서대로 작성 (Add(), ExtendSpace(), Remove() 등)
  - Main()에서 테스트: 직접 실행하며 오류 확인
```
using System;
using System.Collections.Generic; //제네릭
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0217
{
  class TDynamicArray<T>
  {
     protected T[] objects;
     protected int count;
      public TDynamicArray()//생성자
      {
      objects = new T[10];
      count = 0;
       }
      ~TDynamicArray()//소멸자
      {}


    //데이터 추가하기(add)
    public void Add(T inObject)
    {
    if(count >= objects.Legnth)
    {
    ExtendSpace();
    }
    objects[count] = inObject; //현재 위치에 데이터 저장
    count++;
    }

     // 배열확장하기
      protected void ExtendSpace()//배열 확장 메서드, protected로 내부에서만 사용 제한
      {
      T[] newObject = new T[Objects.Length * 2];
      for(int i = 0; i< objects.Length; ++i)
      {
      newObject[i] = objects[i];
      }
      objects = null; //기존 배열에 null을 넣어 삭제
      objects = newObject; //새 배열을 기존 배열로 교체      
      }

   

  
  
  }
}

```
