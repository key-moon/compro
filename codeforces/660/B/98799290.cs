// detail: https://codeforces.com/contest/660/submission/98799290
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var bus = Enumerable.Repeat(0, n).Select(_ => new int[4]).ToArray();
        List<int> res = new List<int>();
        for (int i = 0; i < n; i++)
        {
            var order = new[]
            {
                n * 2 + i * 2 + 1, i * 2 + 1,
                n * 2 + i * 2 + 2, i * 2 + 2,
            };
            res.AddRange(order.Where(x => x <= m));
        }

        Console.WriteLine(string.Join(" ", res));
    }
}