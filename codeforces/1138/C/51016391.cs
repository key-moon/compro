// detail: https://codeforces.com/contest/1138/submission/51016391
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        //座圧したときのそこの高さとその行列
        var nm = Console.ReadLine().Split().Select(int.Parse).ToList();
        var map = Enumerable.Repeat(0, nm[0]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToList()).ToList();
        var zaatsuh = map.Select(x => x.Compress().ToList()).ToList();
        var zaatsuw = Enumerable.Range(0,nm[1]).Select(x => Enumerable.Range(0, nm[0]).Select(y => map[y][x]).Compress().ToList()).ToList();
        var hMaxes = zaatsuh.Select(x => x.Max()).ToArray();
        var wMaxes = zaatsuw.Select(x => x.Max()).ToArray();
        int[][] hmap = Enumerable.Repeat(0, nm[0]).Select(_ => new int[nm[1]]).ToArray();
        for (int i = 0; i < nm[0]; i++)
        {
            for (int j = 0; j < nm[1]; j++)
            {
                var zh = zaatsuh[i][j];
                var zw = zaatsuw[j][i];
                hmap[i][j] = Max(hMaxes[i] + Max(0, zw - zh), wMaxes[j] + Max(0, zh - zw)) + 1;
            }
            Console.WriteLine(string.Join(" ", hmap[i]));
        }
    }
    public static IEnumerable<int> Compress<T>(this IEnumerable<T> enumerable) where T : IComparable<T>
    {
        var dict = enumerable.OrderBy(x => x).Distinct().Select((x, y) => new Tuple<T, int>(x, y)).ToDictionary(x => x.Item1, x => x.Item2);
        return enumerable.Select(x => dict[x]);
    }
}
