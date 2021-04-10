// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2253/judge/5352112/C#
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
        int offset = 65;
        while (true)
        {
            var tn = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var t = tn[0];
            var n = tn[1];
            if (t == 0) break;
            int[][] grid = Enumerable.Repeat(0, offset * 2 + 1).Select(x => Enumerable.Repeat(int.MaxValue, offset * 2 + 1).ToArray()).ToArray();
            for (int i = 0; i < n; i++)
            {
                var s = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var y = s[0] + offset;
                var x = s[1] + offset;
                grid[y][x] = -1;
            }
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            {
                var s = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var y = s[0] + offset;
                var x = s[1] + offset;
                grid[y][x] = 0;
                queue.Enqueue(new Tuple<int, int>(y, x));
            }
            int res = 0;
            int[] dys = new[] { -1, -1, 0, 0, 1, 1 };
            int[] dxs = new[] { -1, 0, -1, 1, 0, 1 };
            while (queue.Count != 0)
            {
                var elem = queue.Dequeue();
                res++;
                var y = elem.Item1;
                var x = elem.Item2;
                var cur = grid[y][x];
                if (t < cur + 1) continue;
                for (int dind = 0; dind < 6; dind++)
                {
                    var dy = dys[dind];
                    var dx = dxs[dind];
                    if (grid[y + dy][x + dx] <= cur + 1) continue;
                    grid[y + dy][x + dx] = cur + 1;
                    queue.Enqueue(new Tuple<int, int>(y + dy, x + dx));
                }
            }
            Console.WriteLine(res);
        }
    }
}
