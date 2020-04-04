// detail: https://atcoder.jp/contests/abc161/submissions/11527412
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
        var k = int.Parse(Console.ReadLine());
        List<long> runrun = new List<long>();
        List<long> lastDig = Enumerable.Range(1, 9).Select(x => (long)x).ToList();
        runrun.AddRange(lastDig);
        while (true)
        {
            List <long> newLastDig = new List<long>();
            foreach (var item in lastDig)
            {
                var i = item % 10;
                if (i != 0) newLastDig.Add(item * 10 + i - 1);
                newLastDig.Add(item * 10 + i);
                if (i != 9) newLastDig.Add(item * 10 + i + 1);
            }
            runrun.AddRange(newLastDig);
            lastDig = newLastDig;
            if (runrun.Count > k) break;
        }
        Console.WriteLine(runrun.OrderBy(x => x).Take(k).Last());
    }
}