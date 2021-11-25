// detail: https://atcoder.jp/contests/arc035/submissions/27484962
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var mat = Enumerable.Range(0, n).Select(_ => Enumerable.Repeat(int.MaxValue / 2, n).ToArray()).ToArray();
        for (int i = 0; i < n; i++) mat[i][i] = 0;
        for (int i = 0; i < m; i++)
        {
            var abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            mat[abc[0] - 1][abc[1] - 1] = abc[2];
            mat[abc[1] - 1][abc[0] - 1] = abc[2];
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    mat[j][k] = Min(mat[j][k], mat[j][i] + mat[i][k]);
                }
            }
        }
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                sum += mat[i][j];
            }
        }
        int K = int.Parse(Console.ReadLine());
        for (int i = 0; i < K; i++)
        {
            var abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var a = abc[0] - 1;
            var b = abc[1] - 1;
            sum -= mat[a][b];
            sum -= mat[b][a];
            mat[a][b] = Min(mat[a][b], abc[2]);
            mat[b][a] = Min(mat[b][a], abc[2]);
            sum += mat[a][b];
            sum += mat[b][a];
            for (int s = 0; s < n; s++)
            {
                for (int t = 0; t < n; t++)
                {
                    sum -= mat[s][t];
                    sum -= mat[t][s];
                    mat[s][t] = Min(mat[s][t], mat[s][a] + mat[a][b] + mat[b][t]);
                    mat[s][t] = Min(mat[s][t], mat[s][b] + mat[b][a] + mat[a][t]);
                    mat[t][s] = mat[s][t];
                    sum += mat[s][t];
                    sum += mat[t][s];
                }
            }
            Console.WriteLine(sum / 2);
        }
    }
}