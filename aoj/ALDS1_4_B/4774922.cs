// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_4_B/judge/4774922/C#
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
        var s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var q = int.Parse(Console.ReadLine());
        var t = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(s.Intersect(t).Count());
    }
}
