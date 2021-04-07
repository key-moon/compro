// detail: https://atcoder.jp/contests/abc181/submissions/21551944
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
        var s = Console.ReadLine().OrderBy(x => x).ToArray();

        if (s.Length <= 3)
        {
            foreach (var perm in Permutations(s))
            {
                var n = long.Parse(string.Join("", perm));
                if (n % 8 == 0)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }
            Console.WriteLine("No");
            return;
        }

        int[] cnt = new int[256];
        foreach (var c in s) cnt[c]++;

        for (int i = 0; i < 1000; i++)
        {
            if (i % 8 != 0) continue;
            var str = i.ToString("000");
            
            int[] curCnt = new int[256];
            foreach (var c in i.ToString("000")) curCnt[c]++;

            if (cnt.Zip(curCnt).Any(x => x.First < x.Second)) continue;
            Console.WriteLine("Yes");
            return;
        }
        Console.WriteLine("No");
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