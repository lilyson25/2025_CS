# OOP로 게임엔진 만들기
```
Engine (>World>GameObject)
while(true)
{
Input();
Update();
Render();
}
```
# 회전값
> x축을 롤(roll): 옆으로 돈다, y축을 피치(pitch): 끄덕이다, z축을 요(yaw)
# Mathf.SmoothDamp
> 카메라 설정시 플레이어를 따라가는 부드러운 움직임을 위해 Mathf.Lerp 보다는 Mathf.SmoothDamp으로 부드럽게 따라가게 설정
# FOV(Field Of View) 시야각
> 값이 커지면-> 멀리있는 것 처럼 다 보이게
![image](https://github.com/user-attachments/assets/c8bbe20e-819e-4c69-8160-422b345fb3c8)
> 센서를 상하좌우로 움직였을 때 얻을 수 있는 최대한의 범위를 의미하며, IFOV(Instantaneous Field Of View)
![image](https://github.com/user-attachments/assets/913fc280-0795-4e52-94a6-3c08f7ec87c5)

# Unity> texture (이미지)
> Texture Type : Sprite
> Max Size : 최대 크기를 정해놓는다
> Format : 손실률을 고려해서 
> Compression : 


