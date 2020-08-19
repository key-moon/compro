// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_3_B/judge/4774426/C#
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
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nq[0];
        var q = nq[1];
        Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();
        for (int i = 0; i < n; i++)
        {
            var data = Console.ReadLine().Split();
            queue.Enqueue(new Tuple<string, int>(data[0], int.Parse(data[1])));
        }
        int elapsed = 0;
        while (0 < queue.Count)
        {
            var elem = queue.Dequeue();
            var time = Min(elem.Item2, q);
            elapsed += time;
            if (time == elem.Item2)
            {
                Console.WriteLine($"{elem.Item1} {elapsed}");
            }
            else
            {
                queue.Enqueue(new Tuple<string, int>(elem.Item1, elem.Item2 -  time));
            }
        }
    }
}

