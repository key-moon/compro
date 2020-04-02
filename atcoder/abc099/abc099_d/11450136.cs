// detail: https://atcoder.jp/contests/abc099/submissions/11450136
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
        var nc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nc[0];
        var c = nc[1];
        var d = Enumerable.Repeat(0, c).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var map = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray()).ToArray();
        List<int>[] count = new[]
        {
            new List<int>(),
            new List<int>(),
            new List<int>()
        };
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                count[(i + j) % 3].Add(map[i][j]);
        int[][] minCost = Enumerable.Repeat(0, 3).Select(x => new int[c]).ToArray();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < c; j++)
            {
                minCost[i][j] = count[i].Sum(x => d[x][j]);
            }
        }
        var min = int.MaxValue;
        for (int i = 0; i < c; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (i == j) continue;
                for (int k = 0; k < c; k++)
                {
                    if (i == k || j == k) continue;
                    var res = 0;
                    res += minCost[0][i];
                    res += minCost[1][j];
                    res += minCost[2][k];
                    min = Min(min, res);
                }
            }
        }
        Console.WriteLine(min);
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