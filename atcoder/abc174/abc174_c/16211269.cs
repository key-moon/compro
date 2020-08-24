// detail: https://atcoder.jp/contests/abc174/submissions/16211269
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
        int n = int.Parse(Console.ReadLine());
        int cur = 0;
        for (int i = 0; i <= n; i++)
        {
            cur *= 10;
            cur += 7;
            cur %= n;
            if (cur == 0)
            {
                Console.WriteLine(i + 1);
                return;
            }
        }
        Console.WriteLine(-1);
    }
}