// detail: https://atcoder.jp/contests/aising2020/submissions/15160362
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
        int[] reses = new int[114514];
        for (int i = 1; i <= 100; i++)
        {
            for (int j = 1; j <= 100; j++)
            {
                for (int k = 1; k <= 100; k++)
                {
                    reses[i * i + j * j + k * k + i * j + j * k + k * i]++;
                }
            }
        }
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
            Console.WriteLine(reses[i]);
    }
}
