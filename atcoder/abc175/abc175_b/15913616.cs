// detail: https://atcoder.jp/contests/abc175/submissions/15913616
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
        var l = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        long res = 0;
        for (int i = 0; i < l.Length; i++)
        {
            for (int j = i + 1; j < l.Length; j++)
            {
                for (int k = j + 1; k < l.Length; k++)
                {
                    if (l[i] != l[j] && l[j] != l[k] &&  l[i] + l[j] > l[k]) res++;
                }
            }
        }
        Console.WriteLine(res);
    }
}
