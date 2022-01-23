// detail: https://atcoder.jp/contests/abc236/submissions/28752215
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
        var mat = Enumerable.Range(1, 2 * n - 1).Select(x => Enumerable.Repeat(0, x).Concat(Console.ReadLine().Split().Select(int.Parse)).ToArray()).ToArray();
        List<int>[] dp = Enumerable.Repeat(0, 1 << (2 * n)).Select(_ => new List<int>()).ToArray();
        dp[(1 << (2 * n)) - 1].Add(0);
        void Solve(int b)
        {
            if (dp[b].Count != 0) return;
            int fst = -1;
            for (int i = 0; i < 2 * n; i++)
            {
                if ((b >> i & 1) == 1) continue;
                fst = i;
                break;
            }
            Trace.Assert(fst != -1);
            for (int snd = fst + 1; snd < 2 * n; snd++)
            {
                if ((b >> snd & 1) == 1) continue;
                var nb = b | (1 << fst) | (1 << snd);
                Solve(nb);
                foreach (var item in dp[nb])
                {
                    dp[b].Add(item ^ mat[fst][snd]);
                }
            }
        }
        Solve(0);
        Console.WriteLine(dp[0].Max());
    }

    static IEnumerable<T[]> Permutations<T>(T[] array) where T : IComparable<T>
    {
        int index = 0;
        yield return array;
        while (true)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i - 1].CompareTo(array[i]) >= 0) continue;
                int j = Array.FindLastIndex(array, x => array[i - 1].CompareTo(x) < 0);
                T tmp = array[i - 1]; array[i - 1] = array[j]; array[j] = tmp;
                Array.Reverse(array, i, array.Length - i);
                yield return array;
                goto end;
            }
            Array.Reverse(array, index, array.Length);
            yield break;
        end:;
        }
    }
}
