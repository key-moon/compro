// detail: https://atcoder.jp/contests/abc236/submissions/28749829
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
        List<int> curBasis = new List<int>();
        var a = Console.ReadLine().Split().Select((elem, ind) => (elem: int.Parse(elem), ind + 1)).OrderBy(x => x.elem).ToArray();
        long cost = 0;
        foreach (var (elem, ind) in a)
        {
            var reduced = ind;
            foreach (var b in curBasis)
            {
                if ((b ^ reduced) < reduced) reduced ^= b;
            }
            if (reduced == 0) continue;
            curBasis.Add(reduced);
            cost += elem;
        }
        Console.WriteLine(cost);
    }
}
