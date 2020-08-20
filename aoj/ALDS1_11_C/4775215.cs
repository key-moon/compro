// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_11_C/judge/4775215/C#
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

        int[][] childs = new int[n][];
        for (int i = 0; i < n; i++)
        {
            var data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            childs[data[0] - 1] = data.Skip(2).Select(x => x - 1).OrderBy(x => x).ToArray();
        }

        int[] dist = Enumerable.Repeat(-1, n).ToArray();
        Queue<int> queue = new Queue<int>();
        dist[0] = 0;
        queue.Enqueue(0);
        while (queue.Count > 0)
        {
            var elem = queue.Dequeue();
            foreach (var item in childs[elem])
            {
                if (dist[item] != -1) continue;
                dist[item] = dist[elem] + 1;
                queue.Enqueue(item);
            }
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{i + 1} {dist[i]}");
        }
    }
}


