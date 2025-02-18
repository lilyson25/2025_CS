using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _0218_Generic
{
    public class Engine
    {
        public Engine()  //생성자
        { 
        }

        static protected Engine instance; // 싱글톤 패턴: 하나의 Engine 객체만 존재하도록 보장

        static Engine Instance
        {
            get
            {
                if (instance == null)
                { 
                    instance = new Engine();
                }
               return instance;
            }
        }

        public void Load()
        {
            string[] scene = {           
            "**********",
            "*P       *",
            "*        *",
            "*        *",
            "*        *",
            "*   M    *",
            "*        *",
            "*        *",
            "*       G*",
            "**********"  };

            World world = new World();

            for(int y=0; y<scene.Length; y++)
            {

                for (int x = 0; x < scene.Length; x++)
                {
                   // world scene[x, y]; 
                }
            }

            
            
        }
        public void Inputprocess()
        {

        }
        
       

        public void Update()
        {

            for (int i = 0; i < gameObject.Length; i++)
            {
                gameobject[i].Update();
            }




        }


        static void Main(string[] args)
        {
           
        }        
    }
}
