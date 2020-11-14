// detail: https://atcoder.jp/contests/agc049/submissions/18098847
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
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(long.Parse).ToArray();

        long res = long.MaxValue;
        long curDenger = 0;
        long coveredUntil = long.MaxValue;
        foreach (var (num, cnt) in a.Zip(b).OrderByDescending(x => x.First))
        {
            //超えうる
            if (num <= cnt)
            {
                //脅威でなくとも適当に減らして壊していいよね
                //if (coveredUntil <= num) continue;

                //何個供出すると脅威を抹消できるか
                var needMove = cnt - num + 1;
                
                //後ろの脅威に対して配る数と減らすべき数のmaxがres
                var curRes = Max(needMove, curDenger);
                res = Min(res, curRes);

                //脅威でない
                if (coveredUntil <= num) continue;
                //脅威
                curDenger++;
                continue;
            }
            else
            {
                //超えない 最初から動かしまくって良い
                coveredUntil = Min(coveredUntil, num - cnt);
            }
        }
        res = Min(res, curDenger);
        Console.WriteLine(res);
    }
}