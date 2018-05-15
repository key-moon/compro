// detail: https://atcoder.jp/contests/chokudai002/submissions/2514456
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        //5000点ギリギリ狙うチャレンジ!

        //100要素あるので、均等だとすると一つひとつは50個持つ(48でいいかな、めんどいので)
        //48:2^4*3 -> 4^2*3
        //ということはn^3*m^3*k^2
        //2*2*2*3*3*3*5*5 = 5400
        //5400*素数100個 -> 48*(100+1)
        //48*104、作りたくない? -> 作ってみる
        //一つの要素を48*4にしてみる
        //48*(98+1)+(48*5) + (3^2-1)

        //5400*(n^5) + p1^2*p2^2
        var p = prime(1000);
        Console.WriteLine(string.Join("\n", p.Skip(4 + 2).Take(98).Select(x => x * 5400).Concat(new int[] { 5400 * power(7, 5), p.Skip(4).Take(2).Aggregate((x, y) => x * y * y) })));
    }

    static int power(int n, int m)
    {
        const int mod = 1000000007;
        long pow = n;
        long res = 1;
        while (m > 0)
        {
            if ((m & 1) == 1) res = (res * pow) % mod;
            pow = (pow * pow) % mod;
            m >>= 1;
        }
        return (int)res;
    }

    static int[] prime(int max)
    {
        if (max < 2) return new int[0];
        List<int> res = new List<int>();
        int sqrtMax = (int)Math.Sqrt(max);
        List<int> sieve = Enumerable.Range(2, max - 2).ToList();
        while (sieve.Count != 0)
        {
            int p = sieve[0];
            if (p > sqrtMax) break;
            res.Add(p);
            sieve.RemoveAll(x => x % p == 0);
        }
        res.AddRange(sieve);
        return res.ToArray();
    }
}
