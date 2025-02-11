# 오늘의 수업 Class, 상속 
> class로 구조잡기 : 시나리오를 가지고 명사, 동사 등의 구분으로 class를 형성한다

## 다향성 (재정의)
> 다향성으로 부모 타입으로 선언해도 자식 클래스의 메서드를 실행할 수 있음!
> public 'override' or 'virtual' void ~

#### virtual
- 부모 클래스에서 재정의할 수 있도록 허용하는 키워드
- virtual function table 배열로 바뀌면서 성능이저하
  
#### override
- 자식 클래스에서 부모의 메서드를 덮어쓰기(재정의)하는 키워드

### 캡술화 Encapsulation
|     |캡술화|상속|
|:----|---:|:--:|
|public | 0 | o  |
|protected| x |o|
|private| x | x |
 
