using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _0218
{
    public class Engine
    {
        private Engine() { }

        static protected Engine instance; // 싱글톤 패턴: 하나의 Engine 객체만 존재하도록 보장
        public World world;  // 게임 월드를 관리할 객체

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
        protected bool isRunning = true;
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

            for (int y = 0; y < scene.Length; y++)
            {
                for (int x = 0; x < scene[y].Length; x++)
                {
                    char tile = scene[y][x];
                    if (tile == '*')
                    {
                        Wall wall = new Wall(x, y, scene[y][x]);
                        world.Instanciate(wall);
                    }
                    else if (tile == ' ')
                    {
                        Floor floor = new Floor(x, y, scene[y][x]);
                        world.Instanciate(floor);
                    }
                    else if (tile == 'P')
                    {
                        Player player = new Player(x, y, scene[y][x]);
                        world.Instanciate(player);
                    }
                    else if (tile == 'M')
                    {
                        Monster monster = new Monster(x, y, scene[y][x]);
                        world.Instanciate(monster);
                    }
                    else if (tile == 'G')
                    {
                        Goal goal = new Goal(x, y, tile);
                        world.Instanciate(goal);
                    }
                }
            }
        }
        
        public void ProcessInput()
        {
            Input.Process();
        }


        protected void Update()
        {
            world.Update();
        }

        protected void Render()
        {
            Console.Clear();
            world.Render();
        }


        public void Run()
        {
            while (isRunning)
            {
                ProcessInput();
                Update();
                Render();
            }
        }
    }
}