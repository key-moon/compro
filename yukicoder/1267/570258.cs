// detail: https://yukicoder.me/submissions/570258
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
public static class P
{
    public static void Main()
    {
        var nv = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = (int)nv[0];
        var v = nv[1];
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        if (a.Sum() <= v)
        {
            Console.WriteLine("Draw");
            return;
        }
        bool[] canWin = new bool[1 << n];
        for (int i = canWin.Length - 1; i >= 0; i--)
        {
            long sum = 0;
            for (int j = 0; j < n; j++)
            {
                if ((i >> j & 1) != 1) continue;
                sum += a[j];
            }
            if (v < sum)
            {
                //この状態で回ってきたら勝てるか:もう相手が溢れさせているので勝ち
                canWin[i] = true;
                continue;
            }
            for (int j = 0; j < n; j++)
            {
                if ((i >> j & 1) == 1) continue;
                canWin[i] |= !canWin[i | (1 << j)];
            }
        }
        Console.WriteLine(canWin[0] ? "First" : "Second");
    }
}