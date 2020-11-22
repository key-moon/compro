// detail: https://atcoder.jp/contests/abc184/submissions/18323307
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
        var abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = abc[0];
        var b = abc[1];
        var c = abc[2];
        double[][][] prob = Enumerable.Repeat(0, 101).Select(_ => Enumerable.Repeat(0, 101).Select(_ => new double[101]).ToArray()).ToArray();
        prob[a][b][c] = 1;

        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                for (int k = 0; k < 100; k++)
                {
                    double sum = i + j + k;
                    if (sum == 0) continue;
                    var nxti = prob[i][j][k] * i / sum;
                    var nxtj = prob[i][j][k] * j / sum;
                    var nxtk = prob[i][j][k] * k / sum;
                    prob[i + 1][j][k] += nxti;
                    prob[i][j + 1][k] += nxtj;
                    prob[i][j][k + 1] += nxtk;
                }
            }
        }
        double res = 0;
        for (int i = 0; i <= 100; i++)
        {
            for (int j = 0; j <= 100; j++)
            {
                for (int k = 0; k <= 100; k++)
                {
                    if (i == 100 || j == 100 || k == 100)
                    {
                        res += ((i + j + k) - (a + b + c)) * prob[i][j][k];
                    }
                }
            }
        }


        Console.WriteLine(res);
    }
}