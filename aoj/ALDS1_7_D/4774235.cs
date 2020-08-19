// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_7_D/judge/4774235/C#
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
        var preOrder = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var inOrder = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(string.Join(" ", Reproduce(preOrder, inOrder)));
    }

    static IEnumerable<int> Reproduce(int[] preOrder, int[] inOrder)
    {
        if (preOrder.Length == 0) return Enumerable.Empty<int>();
        var root = preOrder[0];
        var lCount = Array.IndexOf(inOrder, root);
        var l = Reproduce(
                preOrder.Skip(1).Take(lCount).ToArray(),
                inOrder.Take(lCount).ToArray()
            ).ToArray();
        var r = Reproduce(
                preOrder.Skip(1 + lCount).ToArray(),
                inOrder.Skip(lCount + 1).ToArray()
            ).ToArray();
        return l.Concat(r).Concat(new int[] { root });
    }
}
