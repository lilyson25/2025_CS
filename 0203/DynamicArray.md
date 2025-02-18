# Generic 일반화프로그램 (meta programming)
> 함수 이름은 같은데, 인자가 다를때 : overloading

> class 에서 쓸수 있음
```
class TDynamicArray<T> where T : class {}. struct{} ...
// (where ~ )를 추가할 수 있다
```
> 장점
  - 코드 중복 제거 → 여러 자료형을 지원하면서 같은 코드를 재사용 가능
  - 유연성 증가 → int, string, float 등 다양한 타입을 지원
  - 안전성 증가 → 컴파일러가 자료형을 체크해줘서 오류 방지
### Equals
> string -> == 사용X 대신 .Equals 표현

> int, float, char == 사용가능
