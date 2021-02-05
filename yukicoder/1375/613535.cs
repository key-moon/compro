// detail: https://yukicoder.me/submissions/613535
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
        var nxy = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var x = nxy[1];
        var y = nxy[2];
        var c = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var accumX = new long[c.Length + 1];
        for (int i = 0; i < c.Length; i++)
            accumX[i + 1] = accumX[i] + (x - c[i]);
        var accumY = new long[c.Length + 1];
        for (int i = c.Length - 1; i >= 0; i--)
            accumY[i] = accumY[i + 1] + (y - c[i]);
        var maxProfitX = new long[c.Length];
        maxProfitX[0] = long.MinValue / 2;
        {
            var minReduce = 0L;
            for (int i = 1; i < maxProfitX.Length; i++)
            {
                maxProfitX[i] = Max(maxProfitX[i - 1], accumX[i] - minReduce);
                minReduce = Min(minReduce, accumX[i]);
            }
        }
        var maxProfitY = new long[c.Length];
        maxProfitY[c.Length - 1] = long.MinValue / 2;
        {
            var minReduce = 0L;
            for (int i = maxProfitY.Length - 2; i >= 0; i--)
            {
                maxProfitY[i] = Max(maxProfitY[i + 1], accumY[i + 1] - minReduce);
                minReduce = Min(minReduce, accumY[i + 1]);
            }
        }
        var sum = c.Sum();
        for (int i = 1; i < c.Length - 1; i++)
        {
            Console.WriteLine(sum + maxProfitX[i] + maxProfitY[i]);
        }
    }
}