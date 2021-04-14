// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1154/judge/5374327/C#
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
        bool[] isNotPrime = new bool[300001];
        isNotPrime[0] = true;
        isNotPrime[1] = true;
        for (int i = 2; i < isNotPrime.Length; i++)
        {
            isNotPrime[i] |= i % 7 != 1 && i % 7 != 6;
            if (isNotPrime[i]) continue;
            for (int j = i * 2; j < isNotPrime.Length; j += i)
                isNotPrime[j] = true;
        }
        while (true)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> factors = new List<int>();
            if (n == 1) break;
            for (int i = 1; i * i <= n; i++)
            {
                if (n % i != 0) continue;
                if (!isNotPrime[i]) factors.Add(i);
                if (i * i != n && !isNotPrime[n / i]) factors.Add(n / i);
            }
            factors.Sort();
            Console.WriteLine($"{n}: {string.Join(" ", factors)}");
        }
    }
}
