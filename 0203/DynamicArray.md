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
###  "인덱서" 문법 this[int index]
> myArray[1] 처럼 배열처럼 사용할 수 있게 해주는 것이 인덱서
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

     //데이터 삭제(값을 찾아서)
      public bool Remove(T removeObject)
      {
        for (int i = 0; i < count; ++i)
          if(removeObject.Equals(objects[i])) //값이 일치하면
          {
          return RemoveAt(i);
          }
       }
        return false; //값을 찾지 못하면 삭제 실패
      }
    //특정위치 데이터삭제(앞으로 당겨서 빈공간 없앰)
    public bool RemoveAt(int index)
    {
      if(index >= 0 && index < count) //인덱스가 유용한 경우
      {
        for (int i = index; i < count -1; ++i)
        {
          objects[i] = objects[i+1]; //한칸씩 앞으로 이동
        }
        count--; //데이터개수감소
        return true;
      }
      return false; //잘못된 인덱스면 삭제 실행
    }
   // 특정위치에 데이터 삽입
    public void Insert(int insertIndex, T value)
    {
      if (count >= objects.Legnth)//공간부족하면 확장
      {
        ExtendSpace();
      }
      for (int i = count; i> insertIndex; --i)
      {
        objects[i] = objects[i-1]; //뒤쪽 데이터를 한칸씩 뒤로 이동
      }
      objects[insertIndex] = value; //지정된 위치에 값 삽입
      count++;
    }
    // 현재 데이터 개수 반환(읽기 전용 속성)
    public int Count
    {
      get
      {
        return count;
      }
    }
    //인덱서(배열처럼 객체를 사용 가능하게 만듦)
    public T this[int index]
    {
    get
    {
    if (index >= count || index < 0)
    {
     throw new IndexOutOfRangeException("잘못된 인덱스 접근");
    }
    return objects[index];
    }
    set
    {
    if(index >=0 && index < count)
    {
    objects[index] = value; //특정위치에 값 설정가능
    }
    }
    }
    }
    //실행테스트 
    class Program
    {
      static void Main()
      {
      TDynamicArray<int> myArray = new TDynamicArray<int>();
      //정수형 데이터를 저장하는 동적 배열 생성
      myArray.Add(5);
      myArray.Add(10);
      myArray.Add(15);
      myArray.Remove(10);
      myArray.Insert(1,99);//1번 인덱스에 99 삽입
  
      //배열출력
      for (int i = 0; i<myArray.Count; i++)
      {
      Console.write(myArray[i] + ", "); //출력 5, 99, 15
      
      }
  }
}

```
