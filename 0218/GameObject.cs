using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0218
{
    public class GameObject
    {
        public int X;
        public int Y;
        public char Shape;

        public virtual void Update() //virtual
        {

        }

        public virtual void Render()
        {
            // 출력할 내용
            //X,Y 위치에 Shape 출력
            Console.SetCursorPosition(X, Y);
            Console.Write(Shape);
        }




    }
}
