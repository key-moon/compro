// detail: https://atcoder.jp/contests/abc183/submissions/18124235
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var mat = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray();
        long res = 0;
        foreach (var item in Permutations(Enumerable.Range(0, n).ToArray()))
        {
            if (item.First() != 0) continue;
            var a = item.Zip(item.Skip(1).Append(item.First()), (x, y) => mat[x][y]).Sum();
            if (a == k) res++;
        }
        Console.WriteLine(res);
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