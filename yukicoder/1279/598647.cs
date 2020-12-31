// detail: https://yukicoder.me/submissions/598647
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
        var a = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int max = 0;
        int cnt = 0;
        foreach (var item in Permutations(a.Select((x, y) => (x, y)).ToArray()))
        {
            int res = 0;
            for (int i = 0; i < n; i++) res += Max(0, item[i].x - b[i]);
            if (max < res) { max = res; cnt = 0; }
            if (max == res) cnt++;
        }
        Console.WriteLine(cnt);
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
