// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_5_A/judge/4774926/C#
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
        HashSet<int> canMake = new HashSet<int>();
        for (int i = 0; i < 1 << n; i++)
        {
            int sum = 0;
            for (int j = 0; j < n; j++)
            {
                if ((i >> j & 1) == 1) sum += a[j];
            }
            canMake.Add(sum);
        }
        var q = int.Parse(Console.ReadLine());
        var m = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(string.Join("\n", m.Select(x => canMake.Contains(x) ? "yes" : "no")));
    }
}
