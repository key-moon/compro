// detail: https://atcoder.jp/contests/abc215/submissions/25206211
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
        var input = Console.ReadLine().Split();
        var s = input[0];
        var k = int.Parse(input[1]);
        var res = Permutations(s.OrderBy(x => x).ToArray()).ElementAt(k - 1);
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