// detail: https://codeforces.com/contest/1329/submission/75360315
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
        var mn = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = mn[0];
        var m = mn[1];
        var l = Console.ReadLine().Split().Select(int.Parse).ToArray();
        if (n > l.Sum(x => (long)x))
        {
            Console.WriteLine(-1);
            return;
        }
        var res = Enumerable.Range(1, m).ToArray();
        var rightestWhiteInd = n;
        for (int i = res.Length - 1; i >= 0; i--)
        {
            var lastInd = res[i] + l[i] - 1;
            if (n < lastInd)
            {
                Console.WriteLine(-1);
                return;
            }
            if (lastInd < rightestWhiteInd)
            {
                res[i] += rightestWhiteInd - lastInd;
            }
            rightestWhiteInd = res[i] - 1;
        }

        Console.WriteLine(string.Join(" ", res));
    }
}
