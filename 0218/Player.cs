using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0218
{
    public class Player : GameObject
    {

        public Player(int thisx, int thisy, char thisshape)
        {
            X = thisx;
            Y = thisy;
            Shape = thisshape;
        }

        public override void Update()
        {
            //wasd
            //up, down, left, right`

           
            if (Input.GetKeyDown(ConsoleKey.W) || Input.GetKeyDown(ConsoleKey.UpArrow))
                {
                Y--;
            }
            if (Input.GetKeyDown(ConsoleKey.A) || Input.GetKeyDown(ConsoleKey.DownArrow))
            {
                Y++;
            }
            if (Input.GetKeyDown(ConsoleKey.S) || Input.GetKeyDown(ConsoleKey.LeftArrow))
            {
                X--;
            }
            if (Input.GetKeyDown(ConsoleKey.D) || Input.GetKeyDown(ConsoleKey.RightArrow))
            {
                X++;
            }

        }
    }
}
