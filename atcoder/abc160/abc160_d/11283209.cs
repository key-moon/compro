// detail: https://atcoder.jp/contests/abc160/submissions/11283209
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var nxy = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nxy[0];
        var x = nxy[1] - 1;
        var y = nxy[2] - 1;
        int[] res = new int[n];
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                var dist = j - i;
                dist = Min(dist, Abs(i - x) + 1 + Abs(j - y));
                res[dist]++;
            }
        }

        Console.WriteLine(string.Join("\n", res.Skip(1)));
    }
}
