// detail: https://atcoder.jp/contests/agc051/submissions/19015438
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
        HashSet<int> a = new HashSet<int>();
        HashSet<int> b = new HashSet<int>();
        HashSet<int> c = new HashSet<int>();
        HashSet<int> d = new HashSet<int>();
        //Dがmax(a,b,c)の10倍n
        IEnumerable<string> Gen(int y, int x)
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    var py = y + i * 10;
                    var px = x + j;
                    a.Add(py);
                    b.Add(py - px);
                    c.Add(px);
                    d.Add(py + px);
                    yield return $"{py} {px}";
                }
            }
        }

        int n = (int)1e5 / (100 * 100);
        int y = 0;
        int x = 0;
        List<string> res = new List<string>();
        for (int i = 0; i < n; i++)
        {
            res.AddRange(Gen(y, x));
            y += 1000;
            x += 1000;
        }
        //Console.WriteLine($"{a.Count} {b.Count} {c.Count} {d.Count}");
        Console.WriteLine(res.Count);
        Console.WriteLine(string.Join("\n", res));
    }
}
