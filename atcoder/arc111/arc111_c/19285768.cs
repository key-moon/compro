// detail: https://atcoder.jp/contests/arc111/submissions/19285768
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var holdP = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
        for (int i = 0; i < n; i++)
        {
            if (i != holdP[i] && a[i] <= b[holdP[i]])
            {
                Console.WriteLine(-1);
                return;
            }
        }
        var whoHeld = new int[n];
        for (int i = 0; i < holdP.Length; i++) whoHeld[holdP[i]] = i;
        List<(int, int)> res = new List<(int, int)>();
        void Swap(int a, int b)
        {
            if (a == b) return;
            res.Add((a + 1, b + 1));
            var p1 = holdP[a];
            var p2 = holdP[b];
            (holdP[a], holdP[b]) = (holdP[b], holdP[a]);
            (whoHeld[p1], whoHeld[p2]) = (whoHeld[p2], whoHeld[p1]);
        }
        foreach (var (elem, ind) in b.Select((elem, ind) => (elem, ind)).OrderByDescending(x => x.elem))
        {
            //今持っている人
            var p = whoHeld[ind];
            //持つべき人
            var q = ind;
            Swap(p, q);
        }
        for (int i = 0; i < n; i++)
        {
            if (holdP[i] != i) throw new Exception();
            if (whoHeld[i] != i) throw new Exception();
        }
        Console.WriteLine(res.Count);
        Console.WriteLine(string.Join("\n", res.Select(x => $"{x.Item1} {x.Item2}")));
    }
}