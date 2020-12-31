// detail: https://yukicoder.me/submissions/598618
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        long curT = 0;
        long pos = 0;
        for (int i = 0; i < m; i++)
        {
            var tp = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var t = tp[0];
            var p = tp[1];
            if (Abs(curT - t) < Abs(pos - p))
            {
                Console.WriteLine("No");
                return;
            }
            curT = t;
            pos = p;
        }
        Console.WriteLine("Yes");
    }
}
