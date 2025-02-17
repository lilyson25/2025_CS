/*using System.Data;

namespace _0210
{
    public class Pixel //클래스 뒤엔 아무것도 붙지 않는다
    {
        //생성자
        //를 만들어서 값을 초기화 한다 (생략해도 자동생성은 됨)
        public Pixel() 
        { 
        x= 0; y = 0; r= 0; g= 0; b= 0;
        }

        //소멸자
        ~Pixel()
        {
            Console.WriteLine("소멸자");

        }

        public int x;
        public int y;
        public int r;
        public int g;
        public int b;
}
    internal class Program
    {
        static void Main(string[] args)
            {

            Pixel[] pixels = new Pixel[1980 * 720];
            pixels[0] = new Pixel();
            pixels[1] = new Pixel();



        }
    }
}
*/

using System.Data;

namespace _0210
{
  

    internal class Program
    {
        static void Main(string[] args)
        {

            World world = new World();


        }
    }
}
