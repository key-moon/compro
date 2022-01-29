// detail: https://atcoder.jp/contests/arc134/submissions/28862084
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
        var s = Console.ReadLine().ToArray();
        int[] afterCnt = new int[128];
        foreach (var c in s) afterCnt[c]++;

        int p1 = 0, p2 = n - 1;
        afterCnt[s[p1]]--;
        while (p1 < p2)
        {
            char minC = '~';
            for (char c = 'a'; c < s[p1]; c++)
            {
                if (afterCnt[c] == 0) continue;
                minC = c;
                break;
            }
            if (s[p1] <= minC)
            {
                p1++;
                afterCnt[s[p1]]--;
                continue;
            }
            if (s[p2] == minC)
            {
                afterCnt[s[p2]]--;
                (s[p1], s[p2]) = (s[p2], s[p1]);
                afterCnt[s[p2]]++;

                afterCnt[s[p2]]--;
                p1++; p2--;
                afterCnt[s[p1]]--;
                continue;
            }
            {
                afterCnt[s[p2]]--;
                p2--;
                continue;
            }
        }
        Console.WriteLine(s);
    }
}