// detail: https://atcoder.jp/contests/zone2021/submissions/22214579
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
        var a = m == 0 ? new int[0] : Console.ReadLine().Split().Select(int.Parse).ToArray();

        bool[] achivable = new bool[n];
        achivable[0] = true;
        List<string> edges = new List<string>();
        var validVec = Enumerable.Range(0, n).Except(a).ToArray();
        foreach (var vec in validVec)
        {
            if (achivable[vec]) continue;
            for (int i = 0; i < n; i++)
            {
                if (achivable[i ^ vec] || !achivable[i]) continue;
                achivable[i ^ vec] |= achivable[i];
                edges.Add($"{i} {i ^ vec}");
            }
        }
        if (achivable.Any(x => !x))
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine(string.Join("\n", edges));
        }
    }
}
