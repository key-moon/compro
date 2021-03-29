// detail: https://codeforces.com/contest/846/submission/111320772
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
        long n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        double res = 0;
        foreach (var item in a.Select((val, ind) => (val, ind)).GroupBy(x => x.val))
        {
            var inds = item.Select(x => x.ind).Append(-1).Append((int)n).OrderBy(x => x).ToArray();
            long coCase = inds.Zip(inds.Skip(1), (x, y) => (long)(y - x - 1) * (y - x - 1)).Sum();
            res += 1 - ((double)coCase / (n * n));
        }
        Console.WriteLine(res);
    }
}
