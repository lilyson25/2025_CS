using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Engine
    {
        private Engine()
        {

        }

        static protected Engine instance;

        //더블 버퍼링
        static public char[,] backBuffer = new char[20, 40];
        static public char[,] frontBuffer = new char[20, 40];

        static public Engine Instance
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


        public void Load(string filename)
        {
            List<string> scene = new List<string>();

            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                scene.Add(sr.ReadLine());
            }
            sr.Close();


            world = new World();

            for (int y = 0; y < scene.Count; y++)
            {
                for (int x = 0; x < scene[y].Length; x++)
                {
                    if (scene[y][x] == '*')
                    {
                        Wall wall = new Wall(x, y, scene[y][x]);
                        world.Instanciate(wall);
                    }
                    else if (scene[y][x] == ' ')
                    {
             
                    }
                    else if (scene[y][x] == 'P')
                    {
                        Player player = new Player(x, y, scene[y][x]);
                        world.Instanciate(player);
                    }
                    else if (scene[y][x] == 'M')
                    {
                        Monster monster = new Monster(x, y, scene[y][x]);
                        world.Instanciate(monster);
                    }
                    else if (scene[y][x] == 'G')
                    {
                        Goal goal = new Goal(x, y, scene[y][x]);
                        world.Instanciate(goal);
                    }

                    Floor floor = new Floor(x, y, ' ');
                    world.Instanciate(floor);
                }
            }

           
            world.Sort();
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
            //IO 제일 느려, 모니터 출력, 메모리
            //Console.Clear();
            world.Render();

            //메모리에 있는걸 한방에 붙여줘
            //back <-> front (flip)
            for (int Y = 0; Y < 20; ++Y)
            {
                for (int X = 0; X < 40; ++X)
                {
                    if (Engine.frontBuffer[Y, X] != Engine.backBuffer[Y, X])
                    {
                        Engine.frontBuffer[Y, X] = Engine.backBuffer[Y, X];
                        Console.SetCursorPosition(X, Y);
                        Console.Write(frontBuffer[Y, X]);
                    }
                }
            }
        }

        public DateTime lastTime;

        public void Run()
        {
            float frameTime = 1000.0f / 60.0f;
            float elapsedTime = 0;
            Console.CursorVisible = false;
            while (isRunning)
            {
                Time.Update();

                ProcessInput();
                Update();
                Render();
                Input.ClearInput();
                elapsedTime = 0;

            }
        }


        public World world;
    }
}