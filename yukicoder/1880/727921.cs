// detail: https://yukicoder.me/submissions/727921
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
        var a = long.Parse(Console.ReadLine());

        int layers = 40;
        int n = 1 + layers * 3;
        int[] prevs = { 1 };
        int nxtA = 2;
        int nxtB = 3;
        int nxtC = 4;

        // 1 - A0 - A1 - A2
        //   \    x    x
        //     B0 - B1 - B2
        //      |         |
        //     C0 - C1 - C2
        List<int> cs = new List<int>();
        List<(int, int)> edges = new List<(int, int)>();
        for (int i = 0; i < layers; i++)
        {
            int[] nxts = { nxtA, nxtB };
            cs.Add(nxtC);
            foreach (var prev in prevs)
                foreach (var nxt in nxts)
                    edges.Add((prev, nxt));
            if ((a >> i & 1) == 1) edges.Add((nxtB, nxtC));
            nxtA += 3;
            nxtB += 3;
            nxtC += 3;
            prevs = nxts;
        }
        for (int i = 1; i < cs.Count; i++)
        {
            edges.Add((cs[i - 1], cs[i]));
        }
        Console.WriteLine($"{n} {edges.Count}");
        foreach (var (s, t) in edges)
        {
            Console.WriteLine($"{s} {t}");
        }
    }
}
