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
FFBFF
PBBBB"
            },
            {
                2, @"
TTTGTT TS
T T  TSTT
T TTTTSTT
T TSTS TT
TPTTTG ST
TSTSTT TT"
            },
            {
                3, @"
P      TST
TST  TSTTM
TTT TTSTTT
T TSTS TTT
T TTTG STS
T TMT M TS
SSTSTTMTTT
  TTST  TG
 TGST MTTT
MT  TMTTTT"
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