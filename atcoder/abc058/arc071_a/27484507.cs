// detail: https://atcoder.jp/contests/abc058/submissions/27484507
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
        int[] cntMin = new int[256];
        Array.Fill(cntMin, int.MaxValue);
        for (int i = 0; i < n; i++)
        {
            int[] cnt = new int[256];
            string s = Console.ReadLine();
            foreach (var c in s) cnt[c]++;
            for (int j = 0; j < cnt.Length; j++)
            {
                cntMin[j] = Min(cntMin[j], cnt[j]);
            }
        }
        string res = "";
        for (int i = 0; i < cntMin.Length; i++)
        {
            res += new string((char)i, cntMin[i]);
        }
        Console.WriteLine(res);
    }
}