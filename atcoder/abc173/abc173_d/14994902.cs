// detail: https://atcoder.jp/contests/abc173/submissions/14994902
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
        var a = Console.ReadLine().Split().Select(long.Parse).OrderByDescending(x => x).ToArray();
        Queue<long> queue = new Queue<long>();
        queue.Enqueue(a[0]);
        long res = 0;
        foreach (var item in a.Skip(1))
        {
            res += queue.Dequeue();
            queue.Enqueue(item);
            queue.Enqueue(item);
        }
        Console.WriteLine(res);
    }
}
