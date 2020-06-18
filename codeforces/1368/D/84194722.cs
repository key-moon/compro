// detail: https://codeforces.com/contest/1368/submission/84194722
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
        //bitの総数は変わらなくて、
        int[] eachBitCount = new int[20];
        foreach (var item in a)
        {
            for (int i = 0; i < 20; i++)
            {
                if ((item >> i & 1) == 1) eachBitCount[i]++;
            }
        }
        long res = 0;
        for (int i = 0; i < n; i++)
        {
            long num = 0;
            for (int j = 0; j < 20; j++)
            {
                if (eachBitCount[j] == 0) continue;
                eachBitCount[j]--;
                num |= (1 << j);
            }
            res += num * num;
        }
        Console.WriteLine(res);
    }
}