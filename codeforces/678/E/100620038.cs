// detail: https://codeforces.com/contest/678/submission/100620038
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
        //mat[i][j] := i kill j
        var mat = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(double.Parse).ToArray()).ToArray();
        double[][] probs = Enumerable.Repeat(0, 1 << n).Select(_ => new double[n]).ToArray();
        probs[1][0] = 1;
        for (int b = 1; b < (1 << n); b++)
        {
            for (int i = 0; i < n; i++)
            {
                if ((b >> i & 1) != 1) continue;
                for (int j = 0; j < n; j++)
                {
                    if ((b >> j & 1) != 1) continue;
                    double cur = probs[b - (1 << j)][i] * mat[i][j] + probs[b - (1 << i)][j] * mat[j][i];
                    probs[b][i] = Max(probs[b][i], cur);
                }
            }
        }
        Console.WriteLine(probs.Last().Max());
    }
}