using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0218
{
    public class Floor : GameObject
    {
       public Floor(int thisx, int thisy, char thisshape)
        {
            X = thisx;
            Y = thisy;
            Shape = thisshape;
        }
        public override void Render()
        {
        }
    }
}
