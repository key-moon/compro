// detail: https://yukicoder.me/submissions/727923
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

        int layers = 20;
        int width = 5;
        int b = width - 1;
        int n = 1 + layers * width + 1;
        int[] prevAmps = { 1 };
        int[] nxts = Enumerable.Range(2, width).ToArray();

        //
        // 1 - 2 - 5 - 8   \
        //   \   x   x     |   <- Amps
        //     3 - 6 - 9   /
        //     |       |
        //     4 - 7 - 10 - 11 <- Wires 
        //
        List<int> wires = new List<int>();
        List<(int, int)> edges = new List<(int, int)>();
        for (int i = 0; i < layers; i++)
        {
            int[] nxtAmps = nxts.SkipLast(1).ToArray();
            int nxtWire = nxts.Last();

            wires.Add(nxtWire);
            foreach (var prev in prevAmps)
                foreach (var nxt in nxtAmps)
                    edges.Add((prev, nxt));
            for (int j = 0; j < a % b; j++)
            {
                edges.Add((nxtAmps[j], nxtWire));   
            }
            a /= b;
            nxts = nxts.Select(x => x + width).ToArray();
            prevAmps = nxtAmps;
        }
        wires.Add(n);
        for (int i = 1; i < wires.Count; i++)
        {
            edges.Add((wires[i - 1], wires[i]));
        }

        Console.WriteLine($"{n} {edges.Count}");
        foreach (var (s, t) in edges)
        {
            Console.WriteLine($"{s} {t}");
        }
    }
}
