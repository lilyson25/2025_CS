# Generic 일반화프로그램 (meta programming)
> 함수 이름은 같은데, 인자가 다를때 : overloading

> class 에서 쓸수 있음
```
class TDynamicArray<T> where T : class 클래스명
// where 뒤를 가감할 수 있다
```
### Equals
> string -> == 사용X 대신 .Equals 표현

> int, float, char == 사용가능
