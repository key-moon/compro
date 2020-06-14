// detail: https://atcoder.jp/contests/abc170/submissions/14284198
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
        var xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i <= xy[0]; i++)
        {
            if (xy[1] == xy[0] * 2 + (i * 2))
            {
                Console.WriteLine("Yes");
                return;
            }
        }
        Console.WriteLine("No");
    }
}
