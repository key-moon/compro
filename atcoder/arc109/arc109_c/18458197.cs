// detail: https://atcoder.jp/contests/arc109/submissions/18458197
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        string s = Console.ReadLine();
        int[] pow = new int[300];
        pow[0] = 1;
        for (int i = 1; i < pow.Length; i++) pow[i] = (pow[i - 1] * 2) % n;
        char[][] memo = Enumerable.Repeat(0, k + 1).Select(_ => new char[n]).ToArray();
        char Solve(int round, int start)
        {
            start %= s.Length;
            if (memo[round][start] != '\0') return memo[round][start];
            if (round == 0) return memo[round][start] = s[start];
            var a = Solve(round - 1, start);
            var b = Solve(round - 1, start + pow[round - 1]);
            if (a == 'R')
            {
                if (b == 'R') return memo[round][start] = 'R';
                if (b == 'P') return memo[round][start] = 'P';
                if (b == 'S') return memo[round][start] = 'R';
            }
            if (a == 'P')
            {
                if (b == 'R') return memo[round][start] = 'P';
                if (b == 'P') return memo[round][start] = 'P';
                if (b == 'S') return memo[round][start] = 'S';
            }
            if (a == 'S')
            {
                if (b == 'R') return memo[round][start] = 'R';
                if (b == 'P') return memo[round][start] = 'S';
                if (b == 'S') return memo[round][start] = 'S';
            }
            throw new Exception();
        }
        Console.WriteLine(Solve(k, 0));
    }
}