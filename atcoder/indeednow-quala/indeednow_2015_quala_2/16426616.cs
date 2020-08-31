// detail: https://atcoder.jp/contests/indeednow-quala/submissions/16426616
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
        var s = "indeednow".OrderBy(x => x).ToArray();
        for (int i = 0; i < n; i++)
        {
            var t = Console.ReadLine();
            Console.WriteLine(s.Length == t.Length && t.OrderBy(x => x).Zip(s, (x, y) => x == y).All(x => x) ? "YES" : "NO");
        }
    }
}
