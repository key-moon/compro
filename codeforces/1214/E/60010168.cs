// detail: https://codeforces.com/contest/1214/submission/60010168
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var baseChain = a.Select((elem, index) => new { elem, index }).OrderByDescending(x => x.elem).Select(x => x.index * 2).Concat(Enumerable.Repeat(-1, 2 * n)).ToList();
        List<Tuple<int, int>> res = new List<Tuple<int, int>>();
        for (int i = 0; i < n - 1; i++)
            res.Add(new Tuple<int, int>(baseChain[i], baseChain[i + 1]));

        for (int i = 0; i < n; i++)
        {
            var len = a[baseChain[i] / 2];
            var pair = baseChain[i + len - 1];
            if (baseChain[i + len] == -1) baseChain[i + len] = baseChain[i] + 1;
            res.Add(new Tuple<int, int>(pair, baseChain[i] + 1));
        }

        Console.WriteLine(string.Join("\n", res.Select(x => $"{x.Item1 + 1} {x.Item2 + 1}")));
    }
}

