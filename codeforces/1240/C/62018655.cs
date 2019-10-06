// detail: https://codeforces.com/contest/1240/submission/62018655
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        int q = int.Parse(Console.ReadLine());
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < q; i++)
        {
            builder.AppendLine(Solve().ToString());
        }
        Console.Write(builder.ToString());
    }
    static long Solve()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        List<Edge>[] edges = Enumerable.Repeat(0, n).Select(_ => new List<Edge>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var a = abc[0] - 1;
            var b = abc[1] - 1;
            var c = abc[2];
            edges[a].Add(new Edge() { From = a, To = b, Weight = c });
            edges[b].Add(new Edge() { From = b, To = a, Weight = c });
        }
        int[] parents = new int[n];
        Stack<int> stack = new Stack<int>();
        int[] order = new int[n];
        var ptr = n - 1;
        parents[0] = -1;
        stack.Push(0);
        while (stack.Count > 0)
        {
            var elem = stack.Pop();
            order[ptr--] = elem;
            foreach (var edge in edges[elem])
            {
                if (parents[elem] == edge.To) continue;
                parents[edge.To] = elem;
                stack.Push(edge.To);
            }
        }
        Node[] nodes = new Node[n];
        for (int i = 0; i < order.Length; i++)
        {
            var curnode = order[i];
            long baseReward = 0;
            //そっちにedgeを張ったときの追加報酬
            long[] extraRewards = new long[edges[curnode].Count - (curnode == 0 ? 0 : 1)];
            ptr = 0;
            foreach (var edge in edges[curnode])
            {
                if (edge.To == parents[curnode]) continue;
                baseReward += nodes[edge.To].BaseReward;
                extraRewards[ptr++] = nodes[edge.To].ExtraReward + edge.Weight;
            }
            //
            var rewards = extraRewards.OrderByDescending(x => x).Take(k).TakeWhile(x => 0 <= x).ToArray();
            //k本貼れる
            nodes[curnode].BaseReward = baseReward + rewards.Sum();
            //k-1本貼れる
            nodes[curnode].ExtraReward = rewards.Length == k ? -rewards[k - 1] : 0;
        }
        return nodes[0].BaseReward;
    }
}

struct Node
{
    public long BaseReward;
    public long ExtraReward;
}

struct Edge
{
    public int From;
    public int To;
    public long Weight;
}
