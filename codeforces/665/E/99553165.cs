// detail: https://codeforces.com/contest/665/submission/99553165
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long res = ((long)n) * (n + 1) / 2;
        const int USE_ARR = 9;
        int[] counts = new int[int.MaxValue >> USE_ARR];
        Dictionary<int, int> countDic = new Dictionary<int, int>();
        for (int sft = 31; sft >= 0; sft--)
        {
            if (((k >> sft) & 1) != 1) continue;
            var target = (k >> sft) - 1;
            if (sft >= USE_ARR)
            {
                int frontXor = 0;
                int backXor = 0;
                counts[backXor] = 1;
                for (int j = a.Length - 1; j >= 0; j--)
                {
                    backXor ^= a[j] >> sft;
                    counts[backXor]++;
                }
                int totalXor = backXor;
                for (int i = 0; i < a.Length; i++)
                {
                    counts[backXor]--;
                    backXor ^= a[i] >> sft;

                    var expectBack = totalXor ^ frontXor ^ target;
                    res -= counts[expectBack];

                    frontXor ^= a[i] >> sft;
                }
                counts[backXor]--;
            }
            else
            {
                int frontXor = 0;
                int backXor = 0;
                countDic[backXor] = 1;
                for (int j = a.Length - 1; j >= 0; j--)
                {
                    backXor ^= a[j] >> sft;
                    if (!countDic.ContainsKey(backXor)) countDic[backXor] = 0;
                    countDic[backXor]++;
                }
                int totalXor = backXor;
                for (int i = 0; i < a.Length; i++)
                {
                    countDic[backXor]--;
                    if (countDic[backXor] == 0) countDic.Remove(backXor);
                    backXor ^= a[i] >> sft;

                    var expectBack = totalXor ^ frontXor ^ target;
                    if (countDic.ContainsKey(expectBack)) res -= countDic[expectBack];

                    frontXor ^= a[i] >> sft;
                }
                countDic[backXor]--;
            }
        }
        Console.WriteLine(res);
    }
}