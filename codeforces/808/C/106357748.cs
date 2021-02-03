// detail: https://codeforces.com/contest/808/submission/106357748
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
        var nw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var order = a.Select((elem, ind) => (elem, ind)).OrderByDescending(x => x.elem).Select(x => x.ind).ToArray();
        var res = a.Select(x => (x + 1) / 2).ToArray();
        var w = nw[1] - res.Sum();
        if (w < 0)
        {
            Console.WriteLine(-1);
            return;
        }
        foreach (var item in order)
        {
            var amount = Min(w, a[item] - res[item]);
            w -= amount;
            res[item] += amount;
        }
        Console.WriteLine(string.Join(" ", res));
    }
}
