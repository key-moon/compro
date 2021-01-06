// detail: https://codeforces.com/contest/702/submission/103530308
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
        Dictionary<long, int> targets = new Dictionary<long, int>();
        long res = 0;
        foreach (var item in a)
        {
            for (long sum = 1; sum <= int.MaxValue; sum *= 2)
            {
                if (sum < item) continue;
                var pair = sum - item;
                if (targets.ContainsKey(pair)) res += targets[pair];
            }
            if (!targets.ContainsKey(item)) targets[item] = 0;
            targets[item]++;
        }
        Console.WriteLine(res);
    }
}
