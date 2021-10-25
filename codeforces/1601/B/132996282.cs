// detail: https://codeforces.com/contest/1601/submission/132996282
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
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<int> res = new List<int>();
        int lowest = n - 1;
        int highest = n - 1 - a[n - 1];
        while (0 <= highest)
        {
            var nxtLowest = highest - 1;
            var nxtHighest = int.MaxValue;
            var nxtHighestPos = -1;
            for (int i = highest; i <= lowest; i++)
            {
                var down = i + b[i];
                var nxt = down - a[down];
                if (nxt < nxtHighest)
                {
                    nxtHighest = nxt;
                    nxtHighestPos = i;
                }
            }
            if (nxtLowest < nxtHighest)
            {
                Console.WriteLine(-1);
                return;
            }
            (lowest, highest) = (nxtLowest, nxtHighest);
            res.Add(nxtHighestPos + 1);
        }
        res.Add(0);
        Console.WriteLine(res.Count);
        Console.WriteLine(string.Join(" ", res));
    }
}