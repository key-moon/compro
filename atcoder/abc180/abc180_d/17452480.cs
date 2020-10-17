// detail: https://atcoder.jp/contests/abc180/submissions/17452480
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
        var xyab = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
        var x = xyab[0];
        var y = xyab[1];
        var a = xyab[2];
        var b = xyab[3];
        BigInteger xp = 0;
        while (true)
        {
            if (x * (a - 1) <= b && x * a < y)
            {
                x *= a;
                xp++;
            }
            else break;
        }
        xp += (y - x - 1) / b;
        Console.WriteLine(xp);
    }
}