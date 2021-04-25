// detail: https://atcoder.jp/contests/abc005/submissions/22076965
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
        int t = int.Parse(Console.ReadLine());
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var m = int.Parse(Console.ReadLine());
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Queue<int> q = new Queue<int>();
        foreach (var (time, d) in a.Select(x => (x, 1)).Concat(b.Select(x => (x, -1))).OrderBy(x => x.x).ThenByDescending(x => x.Item2))
        {
            while (q.Count != 0 && q.Peek() < time - t) q.Dequeue();
            if (d == 1) q.Enqueue(time);
            else
            {
                if (q.Count == 0) { Console.WriteLine("no"); return; }
                q.Dequeue();
            }
        }
        Console.WriteLine("yes");
    }
}