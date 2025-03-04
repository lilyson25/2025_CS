﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Input
    {
        public Input()
        {

        }

        static public void Process()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
            }
        }

        static protected ConsoleKeyInfo keyInfo;

        static public bool GetKeyDown(ConsoleKey key)
        {
            return (keyInfo.Key == key);
        }

        public static void ClearInput()
        {
            keyInfo = new ConsoleKeyInfo();
        }
    }
}
