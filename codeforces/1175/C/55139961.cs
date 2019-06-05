// detail: https://codeforces.com/contest/1175/submission/55139961
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        int q = int.Parse(Console.ReadLine());
        int[] res = new int[q];
        for (int qNum = 0; qNum < q; qNum++)
        {
            var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = nk[0];
            var k = nk[1];
            var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //k番目に小さいxとの距離を最小化しなさい
            //k個塊で見て
            var min = int.MaxValue;
            var minPoint = 0;
            for (int i = 0; i < n - k; i++)
            {
                var dist = (a[i + k] - a[i] + 1) / 2;
                if (dist < min)
                {
                    min = dist;
                    minPoint = a[i] + dist;
                }
            }
            res[qNum] = minPoint;
        }
        Console.WriteLine(string.Join("\n", res));
    }
}
