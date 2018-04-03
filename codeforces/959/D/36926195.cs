// detail: https://codeforces.com/contest/959/submission/36926195
using System;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static int[] primes = new int[0];
    static bool[] isUsed = new bool[2000000];
    static void Main()
    {
        //要素数nの配列a
        //bは辞書順でa以上
        //任意のbの要素は2以上
        //bは互いに素
        //となる辞書順最小のbを求めてね。
        //次に出てくる他の要素と互いに素でない奴
        int n = int.Parse(Console.ReadLine());
        primes = prime(2000000);
        int[] res = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool isDictAllign = true;
        int min = 2;
        for (int i = 0; i < res.Length; i++)
        {
            bool firstAllignState = isDictAllign;
            if (!isDictAllign || res[i] < 2) res[i] = min;
            while (true)
            {
                int[] factor = factors(res[i]);
                if (factor.All(x => !isUsed[x]))
                {
                    foreach (var item in factor)
                    {
                        isUsed[item] = true;
                    }
                    break;
                }
                res[i]++;
                isDictAllign = false;
            }
            if (!firstAllignState)
            {
                min = res[i];
            }
        }
        Console.WriteLine(string.Join(" ", res));
    }
    static int[] factors(int n)
    {
        int i = 0;
        List<int> res = new List<int>();
        while (primes[i] * primes[i] <= n)
        {
            if (n % primes[i] == 0)
            {
                res.Add(primes[i]);
                n /= primes[i];
            }
            else
            {
                i++;
            }
        }
        if (n != 1) res.Add(n);
        return res.ToArray();
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