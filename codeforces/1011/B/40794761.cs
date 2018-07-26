// detail: https://codeforces.com/contest/1011/submission/40794761
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int n = Console.ReadLine().Split().Select(int.Parse).First();
        int[] aa = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Dictionary<int, int> adic = new Dictionary<int, int>();
        for (int i = 0; i < aa.Length; i++)
        {
            if (!adic.ContainsKey(aa[i])) adic.Add(aa[i], 0);
            adic[aa[i]]++;
        }
        int[] a = adic.Values.ToArray();
        for (int i = 1; i <= int.MaxValue; i++)
        {
            if (a.Where(x => x >= i).Select(x => x / i).Sum() < n)
            {
                Console.WriteLine(i - 1);
                return;
            }
        }
        //Console.WriteLine(a.Length < n ? 0 : a.Min());
    }
}