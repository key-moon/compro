// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_6_A/judge/4774953/C#
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] bucket = new int[10001];
        foreach (var item in a) bucket[item]++;
        int ptr = 0;
        for (int i = 0; i < bucket.Length; i++)
            for (int j = 0; j < bucket[i]; j++)
                a[ptr++] = i;
        Console.WriteLine(string.Join(" ", a));
    }
}
