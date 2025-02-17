# C# Class(힙에 저장)
> 공간 > 자료형 기본형

> 형변환
 >> int
 >> float
 >> string
 >> bool

> 연산자 , 순위는 ()부터

> array [ , ]

> for, while

> if 
---
### 커스텀 자료형 Class
> public private의 중간-> pretected 상속은 되지만 비공개

> 캡슐화 encapsulation
```
class AData
{
  public AData()
  {
  }

  ~AData()
  {
  }
}
```
---
### 다형성 Virtual, Override
> public 'override' or 'virtual' void ~

##### virtual
- 부모 클래스에서 재정의할 수 있도록 허용하는 키워드
- virtual function table 배열로 바뀌면서 성능이저하
- 덮어서 인식하지 X, 자식이 있을 수 있다, 자식이 재정의할 수 있다
  
##### override
- 자식 클래스에서 부모의 메서드를 덮어쓰기(재정의)하는 키워드, 덮어서 써라, 부모함수가 있다

#### 캡술화 Encapsulation
|     |캡술화|상속|
|:----|---:|:--:|
|public | 0 | o  |
|protected| x |o|
|private| x | x |

> 다형성(polymorphism)은 글자 그대로 object 가 여러가지 모양을 가진다는 의미이고 upcasting/downcasting 으로 이루어지며

> 부모형식 공간에 자식 자료를 넣을 수 있다, 실행시 알아서 부모와 자식 함수를 실행한다

> 목적 : 짧은 반복문안에 모든걸 다 넣어서 단순화되어 작업하기 편해짐
   ![image](https://github.com/user-attachments/assets/1d42c1ae-6d05-49ca-b3ca-27b2a43b0937)

> is 키워드 : 반복문에 if(monster[i] is Goblin) 이렇게 사용

> as 키워드 : as 키워드는 앞에 있는 참조변수가 가리키는 object 를 뒤의 타입으로 casting 해주는 역할을 한다.
```
Parent pa = new Child();
Child ch = pa as Child;
//pa 에서는 Parent에 있는 멤버 접근 가능
//ch 에서는 Child에 있는 멤버 접근 가능
//as Child를 빼먹을시 컴파일 에러 발생 ( downcasting 은 implicit 하게 되지 않음 )
``` 
> Down casting, 동적변환 : 부모를 자식형태로 바꾼다 (성능은 떨어진다)
```
static void Main(string[] args)
{
monster[] monsters = new Monster[3];
monster[0] = new Monster();
monster[1] = new Slime();
monster[2] = new Goblin();

for (int i = 0; i <_,monsters.Length; i++) //Down casting
{
  Slime s = monster[i] as Slime; 
  if (s ! = null)
  {
  s.Sticky();
  }
}
}
```
---
### 데이터 모델링
> 문서든 이미지든 모든 정보를 명사하고 동사로 나눈다 : 명사-> 클래스, 동사 -> 클래스 메소드

