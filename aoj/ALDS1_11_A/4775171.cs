// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_11_A/judge/4775171/C#
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

        int[] parents = Enumerable.Repeat(-1, n).ToArray();
        int[][] childs = new int[n][];
        int[][] res = Enumerable.Range(0, n).Select(_ => new int[n]).ToArray();
        for (int i = 0; i < n; i++)
        {
            var data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var id = data[0] - 1;
            childs[id] = data.Skip(2).ToArray();
            foreach (var child in childs[id])
            {
                res[id][child - 1] = 1;
            }
        }

        Console.WriteLine(string.Join("\n", res.Select(x => string.Join(" ", x))));
    }
}


