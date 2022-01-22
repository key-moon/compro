// detail: https://atcoder.jp/contests/arc133/submissions/28680953
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
        int X = a.Last();
        for (int i = 0; i < n - 1; i++)
        {
            if (a[i] > a[i + 1])
            {
                X = a[i];
                break;
            }
        }
        Console.WriteLine(string.Join(" ", a.Where(x => x != X)));
    }
}
