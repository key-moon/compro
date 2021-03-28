// detail: https://atcoder.jp/contests/arc116/submissions/21354489
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            var n = long.Parse(Console.ReadLine());
            if (n % 2 != 0) Console.WriteLine("Odd");
            else if (n % 4 != 0) Console.WriteLine("Same");
            else Console.WriteLine("Even");
        }
    }
}
