// detail: https://atcoder.jp/contests/abc170/submissions/14297137
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
        bool[] table = new bool[1000001];
        bool[] res = new bool[1000001];
        foreach (var item in a.OrderBy(x => x))
        {
            if (res[item]) res[item] = false;
            if (table[item]) continue;
            res[item] = true;
            for (int i = item; i < table.Length; i += item)
                table[i] = true;
        }
        Console.WriteLine(res.Count(x => x));
    }
}