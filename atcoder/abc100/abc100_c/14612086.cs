// detail: https://atcoder.jp/contests/abc100/submissions/14612086
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(a.Sum(x =>
        {
            int count = 0;
            while (x % 2 == 0)
            {
                x /= 2;
                count++;
            }
            return count;
        }));
    }
}