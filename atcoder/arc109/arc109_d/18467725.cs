// detail: https://atcoder.jp/contests/arc109/submissions/18467725
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        var input = Console.ReadLine().Split().Select(long.Parse).ToArray();
        //var sY = 0;
        //var sX = 0;
        var sPosId = 0;

        var ys = input.Where((_, ind) => ind % 2 == 1).GroupBy(x => x).OrderBy(x => x.Count()).Select(x => x.Key).ToArray();
        var smallY = ys[0];
        var largeY = ys[1];
        var xs = input.Where((_, ind) => ind % 2 == 0).GroupBy(x => x).OrderBy(x => x.Count()).Select(x => x.Key).ToArray();
        var smallX = xs[0];
        var largeX = xs[1];

        if (Min(smallX, largeX) < 0) { smallX = -smallX + 1; largeX = -largeX + 1; sPosId |= 1; }
        if (Min(smallY, largeY) < 0) { smallY = -smallY + 1; largeY = -largeY + 1; sPosId |= 2; }

        var gX = (smallX + largeX) / 2;
        var gY = (smallY + largeY) / 2;
        var gPosId = (smallX < largeX ? 1 : 0) | (smallY < largeY ? 2 : 0);

        if (gY < gX)
        {
            (gX, gY) = (gY, gX);
            int[] posTable = { 0, 2, 1, 3 };
            sPosId = posTable[sPosId];
            gPosId = posTable[gPosId];
        }
        //gX <= gY

        long res = 0;
        if (gX == 0 && gY == 0)
        {
            var dist = sPosId ^ gPosId;
            if (dist == 0) res = 0;
            else res = 1;
        }
        else if (gX == 0)
        {
            res = gY + (gY + 1) - ((sPosId & 2) != 0 ? 1 : 0) - ((gPosId & 2) == 0 ? 1 : 0);
        }
        else
        {
            //先に合わせる
            res = gX + gX + 1 - (sPosId != 0 ? 1 : 0);
            //(gX, gX) pos = sPos & 2
            if (gY == gX)
            {
                res += 1;
                if (gPosId == 2 && sPosId != 1) res -= 1; 
                if (gPosId == 1 && sPosId != 2) res -= 1;
                if (gPosId == 0) res -= 1;
            }
            else
            {
                var diff = gY - gX;
                //sPosが0の時は最初に支払う時に上に動ける
                res += diff + (diff + 1) - (sPosId != 1 ? 1 : 0) - ((gPosId & 2) == 0 ? 1 : 0);
            }
        }
        Console.WriteLine(res);
    }
}