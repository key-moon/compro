// detail: https://atcoder.jp/contests/abc064/submissions/27484558
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
        var s = Console.ReadLine();
        int depth = 0;
        int minDepth = 0;
        foreach (var c in s)
        {
            if (c == '(') depth++;
            if (c == ')') depth--;
            minDepth = Min(minDepth, depth);
        }
        var res = new string('(', Abs(minDepth)) + s + new string(')', depth - minDepth);
        Console.WriteLine(res);
    }
}