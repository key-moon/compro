// detail: https://atcoder.jp/contests/agc050/submissions/19001936
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
        //Test(n);
        var a = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        Console.WriteLine(Solve(a));
    }

    public static void Test(int n)
    {
        int[] order = Enumerable.Range(0, n - 3).OrderBy(x => (x * 0x314159265358979) % 0xdeadbeef).ToArray();
        HashSet<long> arrived = new HashSet<long>();
        bool get(long ind) => arrived.Contains(ind);
        void set(long ind) => arrived.Add(ind);
        //ulong[] arrived = new ulong[(1L << n) / 8];
        //bool get(long ind) => (arrived[ind >> 6] >> (int)ind) != 0;
        //void set(long ind) => arrived[ind >> 6] |= 1UL << (int)ind;
        Stack<long> st = new Stack<long>();
        st.Push(0);
        int[] a = new int[n];
        while (st.Count != 0)
        {
            var elem = st.Pop();
            if (get(elem)) continue;
            set(elem);
            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                if ((elem >> i & 1) == 1) { cnt++; a[i] = 1; }
                else a[i] = -1;
            }
            if (cnt != Solve(a)) Console.WriteLine(Convert.ToString(elem, 2));
            for (int ind = 0; ind + 3 < n; ind++)
            {
                var i = order[ind];
                var fst = elem >> i & 1;
                if ((elem >> (i + 1) & 1) != fst ||
                    (elem >> (i + 2) & 1) != fst) continue;
                st.Push(elem ^ (0b111L << i));
            }
        }
        Console.WriteLine("END");
    }

    static int Solve(int[] a)
    {
        int n = a.Length;
        const int MINF = int.MinValue / 2;
        int[][] dp = Enumerable.Repeat(0, n + 1).Select(_ => Enumerable.Repeat(0, n + 1).ToArray()).ToArray();

        for (int len = 1; len <= n; len++)
        {
            for (int begin = 0; begin <= n - len; begin++)
            {
                var end = begin + len;
                dp[begin][end] = Max(dp[begin][end - 1], dp[begin + 1][end]);
                for (int mid = begin; mid <= end; mid++)
                {
                    dp[begin][end] = Max(dp[begin][end], dp[begin][mid] + dp[mid][end]);
                }
                if (len % 3 == 0)
                {
                    int max = MINF;
                    for (int i = begin + 1; i < end; i += 3) max = Max(max, dp[begin + 1][i] + a[i] + dp[i + 1][end - 1]);
                    dp[begin][end] = Max(dp[begin][end], a[begin] + max + a[end - 1]);
                }
            }
        }
        return dp[0][n];
    }
}