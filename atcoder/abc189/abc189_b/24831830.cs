// detail: https://atcoder.jp/contests/abc189/submissions/24831830
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
        var nx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nx[0];
        var x = nx[1] * 100;
        for (int i = 0; i < n; i++)
        {
            var vp = Console.ReadLine().Split().Select(int.Parse).ToArray();
            x -= vp[0] * vp[1];
            if (x < 0)
            {
                Console.WriteLine(i + 1);
                return;
            }
        }
        Console.WriteLine(-1);
    }
}