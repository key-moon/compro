// detail: https://atcoder.jp/contests/abc208/submissions/23955482
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
        var nk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = (int)nk[0];
        var k = nk[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var all = k / n;
        var remain = k % n;

        Console.WriteLine(string.Join("\n", a.Select((elem, ind) => (elem, ind)).OrderBy(x => x.elem).Select((elem, rank) => (cnt: rank < remain ? all + 1 : all, ind: elem.ind)).OrderBy(x => x.ind).Select(x => x.cnt)));
    }
}
