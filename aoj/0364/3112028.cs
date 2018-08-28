// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/0364/judge/3112028/C#
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int[] whn = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] maxH = new int[whn[0]];
        int[] maxW = new int[whn[1]];
        for (int i = 0; i < whn[2]; i++)
        {
            int[] xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
            maxH[xy[0]] = Max(maxH[xy[0]], xy[1]);
            maxW[xy[1]] = Max(maxW[xy[1]], xy[0]);
        }
        int[] ruisekiMH = new int[whn[0] + 1];
        for (int i = whn[0] - 1; i >= 0; i--)
        {
            ruisekiMH[i] = Max(ruisekiMH[i + 1], maxH[i]);
        }
        int[] ruisekiWH = new int[whn[1] + 1];
        for (int i = whn[1] - 1; i >= 0; i--)
        {
            ruisekiWH[i] = Max(ruisekiWH[i + 1], maxW[i]);
        }
        int res = int.MaxValue;
        for (int i = 0; i < whn[0]; i++)
        {
            res = Min(res, i + ruisekiMH[i + 1]);
        }
        for (int i = 0; i < whn[1]; i++)
        {
            res = Min(res, i + ruisekiWH[i + 1]);
        }
        Console.WriteLine(res);
    }
}
