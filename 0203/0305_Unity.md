#  OOP를 이용한 2D 렌더링 엔진 만들기

- Component 로 엔진 변경 베이스 변경
- 유니티 카메라 제어
- 쿼터니언 이해
- 보간



### 개념정리
> 방향벡터 : 두 점 사이의 방향 벡터는 두 점의 차이로 계산
```
Vector3 direction = targetPosition - currentPosition;
direction.Normalize();  // 벡터를 정규화하여 단위 벡터로 만듬
```
> normalized : 벡터의 방향은 그대로 유지하면서 길이(크기)를 1로 만드는 과정

> velocity -> 물체의 속도와 방향을 동시에 나타내는 벡터로, 물체의 상태를 묘사
```
public class SimpleMovement : MonoBehaviour
{
    public Vector3 velocity = new Vector3(2, 0, 0);  // X 방향으로 2 단위/초 속도로 이동

    void Update()
    {
        // 시간에 따라 물체의 위치 업데이트
        transform.position += velocity * Time.deltaTime;  // Time.deltaTime을 곱해서 프레임 독립적으로 만듬
    }
}
```
> s = v*t -> speed=direction * time : 속도(v) 벡터와 시간(t)을 곱하여 이동한 거리나 위치 변화(s)를 계산
```
public class SimpleMovement : MonoBehaviour
{
    public Vector3 velocity = new Vector3(2, 0, 0);  // X 방향으로 2 단위/초 속도로 이동

    void Update()
    {
        // 's = v * t'로 표현한 물체의 이동
        Vector3 displacement = velocity * Time.deltaTime;  // 이동 거리 (s = v * t)
        
        // 위치 업데이트
        transform.position += displacement;  // 물체의 새로운 위치로 이동
    }
}
```

### Unity 개념정리
> Instance : Hierarchy에 있는 오브젝트들

> Physics.Raycast > cast는 충돌체크의 의미

>  transform.Translate(인자) : 내 기준의 좌표
>  transform.position() : 세상기준 좌표
 ```
transform.Translate(Vector3.up * Time.deltaTime * bulletSpeed, Space.Self);
transform.Translate(transform.up * Time.deltaTime * bulletSpeed, Space.World);

월드 좌표계 : 세상을 중심으로 어느 위치에 있느냐를 의미하는 것
로컬 좌표계 : 한 오브젝트를 중심으로 어느 위치에 있느냐 하는 것
```

> gameObject자신을 쌓이지 않게 일정시간 뒤 지우기
```
private void Awake()
 {
     //c# 가비지 컬렉터(바로 지우지 않음)
     Destroy(gameObject, 3.0f); //쌓이지 않게 일정시간 뒤 지우기
 }
```
> 오브젝트 찾기 : 탐색함수
```
void Awake()
{
SpawnPoint = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
SpawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint").GetComponentsInChildren<Transform>();
//같은 방식 transform.GetChild()
//여러개라 배열일때s를 붙이면 됨
}
```
