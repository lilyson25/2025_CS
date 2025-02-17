using _0211;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0211
{
    public class Monster : Character
    {
        public Monster()
        {
            Console.WriteLine("몬스터 생성자");
        }

        ~Monster()
        {
            Console.WriteLine("몬스터 소멸자");
        }

        //protected int hp;
        //public int Hp
        //{
        //    get
        //    { 
        //        return hp;
        //    }
        //    set
        //    { 
        //        hp = value;
        //    }
        //}

        public int hp
        {
            get;
            set;
        }

        public int gold;

        //public int GetHP()
        //{
        //    return hp;
        //}

        //public void SetHP(int value)
        //{
        //    if (value >= 0)
        //    {
        //        hp = value;
        //    }
        //}


        public void ApplyDamage(int damage)
        {
            if (hp < 0)
            {
                Die();
            }
            else
            {
                hp -= damage;
            }
        }

        public void Attack()
        {
            Console.WriteLine("공격한다.");
        }

        public void Die()
        {

        }

        //virtual function table
        public virtual void Move()
        {
            Console.WriteLine("몬스터 걷는다.");
        }
    }
}