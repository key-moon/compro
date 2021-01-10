// detail: https://atcoder.jp/contests/abc188/submissions/19320049
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
        var a = Console.ReadLine().Split().Select((x, y) => (int.Parse(x), y + 1)).ToList();
        while (2 < a.Count)
        {
            var seq = new List<(int, int)>();
            for (int i = 0; i < a.Count; i += 2)
            {
                if (a[i].Item1 > a[i + 1].Item1) seq.Add(a[i]);
                else seq.Add(a[i + 1]);
            }
            a = seq;
        }
        Console.WriteLine(a[0].Item1 < a[1].Item1 ? a[0].Item2 : a[1].Item2);
    }
}