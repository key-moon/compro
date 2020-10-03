// detail: https://atcoder.jp/contests/arc104/submissions/17166896
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
        var people = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => (A: x[0] - 1, B: x[1] - 1)).ToList();
        int[] role = new int[n * 2];

        foreach (var (A, B) in people)
        {
            if (A != -2)
            {
                if (role[A] != 0) goto no;
                role[A] = 1;
            }
            if (B != -2)
            {
                if (role[B] != 0) goto no;
                role[B] = -1;
            }
            if (A != -2 && B != -2 && A >= B) goto no;
        }

        int[] remainWild = Enumerable.Repeat(-1, 2 * n + 1).ToArray();
        remainWild[0] = people.Where(x => x.A == -2 && x.B == -2).Count();
        people.RemoveAll(x => x == (-2, -2));
        for (int i = 1; i < 2 * n; i += 2)
        {
            for (int start = 0; start < i; start += 2)
            {
                int use = 0;
                var half = (i + 1 - start) / 2;
                for (int j = start, k = start + half; k <= i; j++, k++)
                {
                    if (role[j] == 0 && role[k] == 0) { use++; continue; }
                    // 始点が誰かの終点 または終点が誰かの始点
                    if (role[j] == -1 || role[k] == 1) goto impossible;
                    if (people.Any(x => x.A == j && (x.B != -2 && x.B != k) || x.B == k && (x.A != -2 && x.A != j))) goto impossible;
                }
                remainWild[i + 1] = Max(remainWild[i + 1], remainWild[start] - use);
                impossible:;
            }
        }
        if (remainWild.Last() == -1) goto no;
        Console.WriteLine("Yes");
        return;
        no:;
        Console.WriteLine("No");
    }
}