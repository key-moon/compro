// detail: https://yukicoder.me/submissions/319239
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Int = System.Int64;
using Debug = System.Diagnostics.Debug;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int res = 0;
        int miss = 0;
        for (int i = 0; i < n; i++)
        {
            var s = Console.ReadLine().Split();
            int type = Min(int.Parse(s[0]) * 12 / 1000, s[1].Length);
            res += type;
            miss += s[1].Length - type;
        }
        Console.WriteLine($"{res} {miss}");
    }
}
