// detail: https://codeforces.com/contest/702/submission/103530702
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long valid = int.MaxValue;
        long invalid = -1;
        while (valid - invalid > 1)
        {
            var mid = (valid + invalid) / 2;

            List<(long, int)> events = new List<(long, int)>();
            foreach (var item in b)
            {
                events.Add((item - mid, 1));
                events.Add((item + mid + 1, -1));
            }
            events.Add((long.MaxValue, 0));
            events.Sort();
            int eventInd = 0;
            int cnt = 0;
            for (int i = 0; i < a.Length; i++)
            {
                while (events[eventInd].Item1 <= a[i])
                {
                    cnt += events[eventInd].Item2;
                    eventInd++;
                }
                if (cnt == 0) goto invalid;
            }
            valid = mid;
            continue;
            invalid:;
            invalid = mid;
        }
        Console.WriteLine(valid);
    }
}