// detail: https://codeforces.com/contest/1394/submission/89679020
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
        Random rng = new Random();
        var ndm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = ndm[0];
        var d = ndm[1];
        var m = ndm[2];
        var a = Console.ReadLine().Split().Select(long.Parse).OrderBy(_ => rng.Next()).OrderByDescending(x => x).ToArray();
        var normal = a.Where(x => x <= m).ToArray();
        var ban = a.Where(x => m < x).ToArray();
        
        long curRes = 0;

        int normalPtr = -1;
        while (normalPtr + 1 < normal.Length)
        {
            curRes += normal[++normalPtr];
        }
        int banPtr = -1;
        for (int i = normal.Length; i < n && banPtr + 1 < ban.Length; i += d + 1)
        {
            curRes += ban[++banPtr];
        }

        banPtr++;
        long res = curRes;
        //殺すのは使えないやつ→小さいやつ
        for (; banPtr < ban.Length; banPtr++)
        {
            var use = banPtr * (d + 1) + 1;
            var unusedNormal = use - ban.Length;
            if (normal.Length < unusedNormal) break;
            for (; normalPtr >= normal.Length - unusedNormal; normalPtr--)
                curRes -= normal[normalPtr];
            curRes += ban[banPtr];
            res = Max(res, curRes);
        }

        Console.WriteLine(res);
    }
}
