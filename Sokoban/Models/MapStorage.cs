using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Sokoban
{
    public static class MapStorage
    {
        private static Dictionary<int, string> maps = new Dictionary<int, string>()
        {
            {
                1, @"
BBBBB
  BF 
PBBBB"
            },
            {
                2, @"
WWWWWWWWW
       FW
        W
        W
 B      W
P       W"
            },
            {
                3, @"
    WWWWW             
    W   W             
    WB  W             
  WWW  BWWW           
  W  B  B W           
WWW W WWW W     WWWWWW
W   W WWW WWWWWWW  FF
W B  B             FFW
WWWWW WWWW WPWWWW  FFW
    W      WWW  WWWWWW
    WWWWWWWW          "
            }
        };

        public static string GetMap(int level)
        {
            if (maps.ContainsKey(level))
            {
                return maps[level];
            }
            throw new ArgumentException("Нет необходимого уровня",nameof(level));
        }
    }
}