// detail: https://codeforces.com/contest/985/submission/82564061
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        //n*k個の木の棒を持ってます
        //iこめは長さaです
        //n個の樽を組みたいです
        //樽はk本ずつの木の棒が必要

        //バレルのマックスサイズの差はlを超えてはダメ
        //短いのから貪欲に取ると超えるかも知れない
        //飛ばし飛ばしで取っていき、超える一歩手前で下側に方針変更
        Random rng = new Random();
        int[] nkl = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] a = Console.ReadLine().Split().Select(int.Parse).OrderBy(_ => rng.Next()).OrderBy(x => x).ToArray();
        bool[] isUsed = new bool[a.Length];
        long curInd = 0;
        isUsed[curInd] = true;
        //既にマックスに達していて減らすだけか否か
        bool revFlag = false;
        long min = a[0];
        long res = a[0];
        for (int i = 1; i < nkl[0]; i++)
        {
            if (!revFlag && a[curInd + nkl[1]] - min > nkl[2])
            {
                revFlag = true;
                while (a[curInd] - min <= nkl[2]) curInd++;
                curInd--;
            }
            if (revFlag)
            {
                while (curInd >= 0 && isUsed[curInd]) curInd--;
                if (curInd < 0)
                {
                    res = 0;
                    break;
                }
            }
            else
            {
                curInd += nkl[1];
            }
            res += a[curInd];
            isUsed[curInd] = true;
        }
        Console.WriteLine(res);
    }
}