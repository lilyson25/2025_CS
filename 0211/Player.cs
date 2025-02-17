using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//플레이어는 공격 할 수 있고 이동 할 수 있습니다.
namespace _0211
{

    public class Player : Character
    {
        public Player()//생성자를 만들면서 동시에 변수를 초기화하는 과정
        {
            hp = 100;
            gold = -10;
            Console.WriteLine("플레이어 생성자");
        }

        public Player(int hp, int gold)
        {
            this.hp = hp;
            this.gold = gold;
        }

        ~Player()
        {
            //Network, DB 종료
            Console.WriteLine("플레이어 소멸자");
        }

        public void Attack()
        {

        }

        public void Move()
        {
            Console.WriteLine("플레이어 뛰어다닌다.");
        }

        public void Pickup()
        {

        }

        public void Die()
        {

        }


        public int hp;
        public int gold;

    }
}
