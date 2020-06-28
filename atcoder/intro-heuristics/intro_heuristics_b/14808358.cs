// detail: https://atcoder.jp/contests/intro-heuristics/submissions/14808358
#define B
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

public static class P
{
    static int d;
    static int[] c;
    static int[][] s;
    public static void Main()
    {
        d = int.Parse(Console.ReadLine());
        c = Console.ReadLine().Split().Select(int.Parse).ToArray();
        s = Enumerable.Repeat(0, d).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var t = Enumerable.Repeat(0, d).Select(_ => int.Parse(Console.ReadLine()) - 1).ToArray();
        Score(t);
    }

    static int Score(int[] t)
    {
        int score = 0;
        int[] last = new int[26];
        for (int i = 0; i < t.Length; i++)
        {
            score += s[i][t[i]];
            last[t[i]] = i + 1;
            for (int j = 0; j < last.Length; j++)
                score -= (i - last[j] + 1) * c[j];
#if B
            Console.WriteLine(score);
#endif
        }
        return score;
    }
}

