// detail: https://yukicoder.me/submissions/329811
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;

static class P
{
    static void Main()
    {
        var nd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] pows = Enumerable.Range(1, nd[0]).Select(x => x * x).ToArray();
        var dict = pows.SelectMany(x => pows.Select(y => x - y + nd[1])).Aggregate(new int[nd[0] * nd[0] + Max(nd[1], nd[0] * nd[0] + 1)], (x, y) => {
                if (y <= 0) return x;
                x[y]++;
                return x;
            });
        Console.WriteLine(pows.SelectMany(x => pows.Select(y => x + y)).Sum(x => dict[x]));
    }
}
