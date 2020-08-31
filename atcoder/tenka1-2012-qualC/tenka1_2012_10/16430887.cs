// detail: https://atcoder.jp/contests/tenka1-2012-qualC/submissions/16430887
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
        string s = Console.ReadLine();
        var group = Regex.Matches(s, @"[SHDC][AJQK0123456789]+").Select(x => x.Value).ToArray();
        var rsfs = "SHDC".Select(c => new[] { "10", "J", "Q", "K", "A" }.Select(x => c + x).ToArray()).ToArray();
        for (int i = 5; i <= group.Length; i++)
        {
            foreach (var rsf in rsfs)
            {
                if (group.Take(i).Intersect(rsf).Count() != 5) continue;
                var res = string.Join("", group.Take(i).Except(rsf));
                if (res.Length == 0) res = "0";
                Console.WriteLine(res);
                return;
            }
        }
    }
}
