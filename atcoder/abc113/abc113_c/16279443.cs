// detail: https://atcoder.jp/contests/abc113/submissions/16279443
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
        int[] count = new int[n + 1];
        var py = Enumerable.Repeat(0, m).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        string[] res = new string[m];
        foreach (var (elem, ind) in py.Select((elem, ind) => (elem, ind)).OrderBy(x => x.elem[1]))
        {
            var p = elem[0];
            res[ind] = $"{p:000000}{++count[p]:000000}";
        }

        Console.WriteLine(string.Join("\n", res));
    }
}