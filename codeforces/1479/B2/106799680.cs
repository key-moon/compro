// detail: https://codeforces.com/contest/1479/submission/106799680
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
        var cur = a[0];
        List<int> seq = new List<int>();
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != cur)
            {
                seq.Add(cur);
            }
            cur = a[i];
        }
        seq.Add(cur);

        int curMaxJoin = 0;
        int prev = -1;
        Dictionary<int, int> dic = new Dictionary<int, int>();
        foreach (var item in seq)
        {
            if (prev != -1)
            {
                int switchedMax = curMaxJoin;
                if (dic.ContainsKey(item)) switchedMax = Max(switchedMax, dic[item] + 1);
                if (!dic.ContainsKey(prev)) dic[prev] = 0;
                dic[prev] = Max(dic[prev], switchedMax);
                curMaxJoin = Max(curMaxJoin, switchedMax);
            }
            prev = item;
        }
        Console.WriteLine(seq.Count - curMaxJoin);
    }
}
