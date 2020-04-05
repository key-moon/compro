// detail: https://atcoder.jp/contests/judge-update-202004/submissions/11586947
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
        var abc = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int res = 0;
        foreach (var item in Permutations(Enumerable.Range(1, abc.Sum()).ToArray()))
        {
            int[][] blocks = Enumerable.Range(0, 3).Select(x => new int[abc[x]]).ToArray();
            int ind = 0;
            foreach (var block in blocks)
            {
                for (int i = 0; i < block.Length; i++)
                {
                    block[i] = item[ind++];
                }
            }
            bool isValid(IEnumerable<int> x) { return x.Zip(x.Skip(1)).All(x => x.First > x.Second); }
            var res1 = blocks.All(isValid);
            var res2 = Enumerable.Range(0, 3).All(x => isValid(blocks.TakeWhile(y => x < y.Length).Select(y => y[x])));
            if (res1 && res2) res++;
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
