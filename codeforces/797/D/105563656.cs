// detail: https://codeforces.com/contest/797/submission/105563656
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
        Node[] nodes = Enumerable.Repeat(0, n).Select(_ => new Node()).ToArray();
        HashSet<int> rootCands = Enumerable.Range(0, n).ToHashSet();
        for (int i = 0; i < n; i++)
        {
            var vlr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            nodes[i].Val = vlr[0];
            if (vlr[1] != -1) nodes[i].L = nodes[vlr[1] - 1];
            if (vlr[2] != -1) nodes[i].R = nodes[vlr[2] - 1];
            rootCands.Remove(vlr[2] - 1); rootCands.Remove(vlr[1] - 1);
        }

        HashSet<int> valid = new HashSet<int>();

        // 開区間
        void DFS(Node node, int lower, int upper)
        {
            if (node is null) return;
            var val = node.Val;
            if (lower < val && val < upper) valid.Add(val);
            DFS(node.L, lower, Min(val, upper));
            DFS(node.R, Max(val, lower), upper);
        }

        var root = rootCands.First();
        DFS(nodes[root], int.MinValue, int.MaxValue);
        Console.WriteLine(nodes.Count(x => !valid.Contains(x.Val)));
    }
}

class Node
{
    public int Val;
    public Node L;
    public Node R;
}
