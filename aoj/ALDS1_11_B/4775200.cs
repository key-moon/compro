// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_11_B/judge/4775200/C#
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

        int time = 0;
        int[] d = new int[n];
        int[] f = new int[n];
        Action<int> dfs = null;
        dfs = node =>
        {
            if (d[node] != 0) return;
            time++;
            d[node] = time;
            foreach (var item in childs[node])
            {
                dfs(item);
            }
            time++;
            f[node] = time;
        };
        for (int i = 0; i < n; i++)
        {
            dfs(i);
            Console.WriteLine($"{i + 1} {d[i]} {f[i]}");
        }
    }
}


