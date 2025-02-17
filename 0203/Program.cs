using System;


namespace _20250203
{
    internal class Program
    {
        static char wall = '*';
        static char floor = ' ';
        static int playerX = 1;
        static int playerY = 1;



        static int[,] map =               {
                    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 4, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };
        static ConsoleKeyInfo keyInfo;

        static bool IsRunning = true;
        static void Main(string[] args)
        {
            while (IsRunning)
            {
                Input();
                Update();
                Render();
            }

            Console.Clear(); // Updat에서 esc까지 돌면 클리어되고 아래 문자 등장
            Console.WriteLine("Game over");
        }

        private static void Render()
        {
            Console.Clear(); //움직일때마다 새로 생성됨을 방지
          

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (x == playerX && y == playerY)
                    {
                        Console.Write('P');
                    }
                    else if (map[y, x] == 1)
                    {
                        Console.Write(wall);
                    }
                    else if (map[y, x] == 0)
                    {
                        Console.Write(floor);
                    }
                    else if (map[y, x] == 4) //map에 표시된 숫자 4에 대한
                    {
                        Console.Write('M');
                    }
                }
                Console.Write('\n'); //'\n'줄바꿈
            }
        }

        private static void Update()
        {
            if (keyInfo.Key == ConsoleKey.W ||
                keyInfo.Key == ConsoleKey.UpArrow)
            {
                playerY--;
            }
            else if (keyInfo.Key == ConsoleKey.S ||
                keyInfo.Key == ConsoleKey.DownArrow)
            {
                playerY++;
            }
            else if (keyInfo.Key == ConsoleKey.A ||
                keyInfo.Key == ConsoleKey.LeftArrow)
            {
                playerX--;
            }
            else if (keyInfo.Key == ConsoleKey.D ||
                keyInfo.Key == ConsoleKey.RightArrow)
            {
                playerX++;
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                IsRunning = false;
            }
        }

        private static void Input()
        {
            keyInfo = Console.ReadKey();
        }
    }



    /*   static int Calculate(int num1, int num2)   //Main자리 : 동사로 적는다 그리고 시작글자 대문자 + () 는 함수, 괄호가 없으면 클래스
         //반환형 함수명(자료형 인자1, 자료형 인자2
         //{
         // return 자료 반환 ;
         //} 

         {
             return num1 * num2 ;
         }
         static void Main(string[] args) 
         {

             Console.WriteLine(Calculate(2,3));
         }
    */

    /* 
       //*****
       //*****
       //*****
       //*****
       //*****

       for (int i = 1; i <= 5; i++) //int i = 0; i < 5 
       {
           for (int j = 1; j <= 5; j++) 
           {
               Console.Write('*');
           }
           Console.WriteLine();
       }
    */

    /* 
      //*
      //**
      //***
      //****
      //*****.....

      int size= 10;

      for (int i = 1; i <= size ; i++) 
      {
          for (int j = 1; j <= i; j++)
          {
              Console.Write('*');
          }
          Console.WriteLine();
      }

    int[,] map = new int[5, 5];

    for (int j = 0; j < 5; j++)
    {
        for (int i = 0; i < 5; i++)
        {
         
            map[j, i] = i + 1;
        }
        
    }

     */


    /*
    //    *
    //   **
    //  ***
    // ****
    //*****

    //----*
    //---**
    //--***
    //-****
    //*****
    
                int size = 10;

                for (int j = 1; j <= size; j++)
                {
                    for (int i = 1; i <= size - j; i++)
                    {
                        Console.Write(' ');
                    }
                    for (int i = 1; i <= j; i++)
                    {
                        Console.Write('*');
                    }
                    Console.WriteLine();
                }
    */


    /*
      
     //12345678910
     int[] data = new int[10];//개수가 열개

     string s = "Hi";
     Console.WriteLine(s);

     for (int i = 0; i < 10; i++)
     {
         data[i] = i + 1;
     }
     for (int i = 0; i < 10; i++)
     { 
         Console.Write(data[i] + ",");
     }
    */



    /*
        //[][][][][][][][][][]
        //[][][][][][][][][][]
        //[][][][][][][][][][]
        //[][][][][][][][][][]
        //[][][][][][][][][][]
        //[][][][][][][][][][]
        //[][][][][][][][][][]
        //[][][][][][][][][][]
        //[][][][][][][][][][]
        //[][][][][][][][][][]

                    int[,] data = new int[10, 10];

                    int number = 1;
                    for (int j = 0; j < 10; j++)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            data[j, i] = number++;
                        }
                    }

                    for (int j = 0; j < 10; j++)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Console.Write(data[j, i].ToString() + "\t");
                        }
                        Console.WriteLine();
                    }
    */


    /* string i = "*";
     int size = 10;

     for (int j = 0; j < size; j++)
     {
         for (int z = 1; z <= j; z++)
         {
             Console.Write(i);

         }
         Console.WriteLine();
     }*/
}



