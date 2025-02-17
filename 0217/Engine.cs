using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _0217
{
    public class Engine
    {
        /*
         Engine.Instance.Load() → 맵을 로드하고 객체들을 생성한다.
         Engine.Instance.Run() → 게임 루프를 실행한다.
         ProcessInput() → 사용자 입력을 처리한다.
         Update() → 게임 내의 모든 객체를 업데이트한다.
         Render() → 게임 화면을 다시 그린다.
         */

        /*
        1️ 클래스 : Engine, World, Player, Monster 등 다양한 클래스로 구성됨.

        2️ 상속 : Monster, Player, Wall, Floor 등은 GameObject 클래스를 상속받아 X, Y 좌표 및 Update() 같은 공통 기능을 사용 가능.

        3️다형성 : GameObject의 Update()를 Monster, Player 등에서 다르게 구현하여 각 객체가 다르게 행동함.
         */

        private Engine()  //private 생성자 (외부에서 객체 생성 방지) 
        {
        }
       
        static protected Engine instance; // 싱글톤 패턴: 하나의 Engine 객체만 존재하도록 보장

        static public Engine Instance
        {
            get
            {
                if (instance == null)  // 최초 호출 시 Engine 객체 생성
                {
                    instance = new Engine();
                }
                return instance;
            }
        }

       
        protected bool isRunning = true;  // 게임 실행 상태 변수

       
        public World world;  // 게임 월드를 관리할 객체

        
        public void Load() // Load() : 게임 맵을 초기화하는 함수
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

          
            world = new World();   // World 객체 생성

            // 2D 배열을 순회하면서 객체 생성
            for (int y = 0; y < scene.Length; y++)
            {
                for (int x = 0; x < scene[y].Length; x++)
                {
                    char tile = scene[y][x];

                    if (tile == '*')
                    {
                        // 벽 생성 후 월드에 추가
                        Wall wall = new Wall(x, y, tile);
                        world.Instanciate(wall);
                    }
                    else if (tile == ' ')
                    {
                        // 바닥 생성
                        Floor floor = new Floor(x, y, tile);
                        world.Instanciate(floor);
                    }
                    else if (tile == 'P')
                    {
                        // 플레이어 생성
                        Player player = new Player(x, y, tile);
                        world.Instanciate(player);
                    }
                    else if (tile == 'M')
                    {
                        // 몬스터 생성
                        Monster monster = new Monster(x, y, tile);
                        world.Instanciate(monster);
                    }
                    else if (tile == 'G')
                    {
                        // 목표 지점(Goal) 생성
                        Goal goal = new Goal(x, y, tile);
                        world.Instanciate(goal);
                    }
                }
            }
        }

        // 사용자 입력을 처리하는 함수
        public void ProcessInput()
        {
            Input.Process();  // 입력 클래스에서 키 입력 처리
        }

        // 게임 상태를 업데이트하는 함수
        protected void Update()
        {
            world.Update();  // 월드 내의 모든 객체 업데이트
        }

        //게임 화면을 렌더링하는 함수
        protected void Render()
        {
            Console.Clear();  // 콘솔 화면을 지움
            world.Render();   // 월드의 객체들을 화면에 출력
        }

        // 게임 루프를 실행하는 함수
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