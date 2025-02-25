# interface  
> 구체적인 구현이 없고, 단지 메서드 시그니처(이름, 매개변수, 반환형)만 정의.

> 함수 강제 구현, 다중 상속 
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


# absract 클래스
> 공통된 기능을 제공하고 일부 메서드는 자식 클래스에서 구현하도록 강제.
