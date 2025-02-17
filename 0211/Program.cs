namespace _0211
{
    /*
    우리가 하는 게임에는 플레이어가 있습니다. 
    플레이어는 공격 할 수 있고 이동 할 수 있습니다.
    또한 몬스터는 3종류가 있습니다. 고블린은 
    공격 할 수가 있고 걸어서 이동 할 수 있습니다.
    슬라임도 공격 할 수가 있고 미끄러져 이동합니다.
    멧돼지는 뛰어서 이동하고 공격 할 수 있습니다.
    그리고 플레이어는 몬스터를 사냥해서 골드를
     모을 수 있습니다. 모든 캐릭터는 HP를 가지고 있고
     HP가 0이하면 죽습니다.                                                                                                                                                                                                                                                                            
     */
         public class Program
        {

        static void Main(string[] args)
        {
            Monster monster = new Goblin();
            int currentHP = monster.hp;
            monster.hp = 10;

            currentHP = monster.hp;
            Console.WriteLine(currentHP);
            // monster.GetHP();
            //monster.SetHP(100);

        }



        /* Player player = new Player();

         Random rand = new Random();

         int mgoblinCount = rand.Next(1, 3);
         MGoblin[] mgoblins = new MGoblin[mgoblinCount];
         for (int i = 0; i < mgoblins.Length; i++)
         {
             mgoblins[i] = new MGoblin();
         }


         int mslimeCount = rand.Next(1, 5);
         MSlime[] mslimes = new MSlime[mslimeCount];
         for (int i = 0; i < mslimes.Length; i++)
         {
             slimes[i] = new Slime();
         }

         int mboarCount = rand.Next(1, 3);
         Boar[] mboars = new Boar[mboarCount];
         for (int i = 0; i < boars.Length; i++)
         {
             boars[i] = new Boar();
         }

         while (true)
         {
             //Input();
             Console.ReadKey();
             Console.Clear();

             //Update();
             player.Move();
             for (int i = 0; i < goblins.Length; i++)
             {
                 goblins[i].Move();
             }
             for (int i = 0; i < slimes.Length; i++)
             {
                 slimes[i].Move();
             }
             for (int i = 0; i < boars.Length; i++)
             {
                 boars[i].Move();
             }

             //Render();*/



        }
    }
