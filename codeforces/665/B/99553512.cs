// detail: https://codeforces.com/contest/665/submission/99553512
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
        var nmk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nmk[0];
        var m = nmk[1];
        var k = nmk[2];
        var a = Console.ReadLine().Split().Select(int.Parse).ToList();
        long res = 0;
        for (int i = 0; i < n; i++)
        {
            foreach (var q in Console.ReadLine().Split().Select(int.Parse))
            {
                var ind = a.IndexOf(q);
                a.RemoveAt(ind);
                a.Insert(0, q);
                res += ind + 1;
            }
        }
        Console.WriteLine(res);
    }
}
