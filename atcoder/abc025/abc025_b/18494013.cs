// detail: https://atcoder.jp/contests/abc025/submissions/18494013
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
        var nab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = nab[1];
        var b = nab[2];
        long cur = 0;
        for (int i = 0; i < nab[0]; i++)
        {
            var s = Console.ReadLine().Split();
            var elem = Clamp(int.Parse(s[1]), a, b);
            if (s[0] == "East") elem *= -1;
            cur += elem;
        }
        if (cur == 0)
        {
            Console.WriteLine(0);
            return;
        }
        string dir = "West";
        if (cur < 0)
        {
            dir = "East";
            cur *= -1;
        }
        Console.WriteLine($"{dir} {cur}");
    }
}