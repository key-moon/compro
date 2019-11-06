// detail: https://codeforces.com/contest/1242/submission/64398404
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        List<int>[] heavyEdges = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var a = ab[0] - 1;
            var b = ab[1] - 1;
            heavyEdges[a].Add(b);
            heavyEdges[b].Add(a);
        }
        int[] group = Enumerable.Range(0, n).ToArray();
        HashSet<int> undefinedNodes = new HashSet<int>(Enumerable.Range(0, n));
        for (int targetGroup = 0; targetGroup < group.Length; targetGroup++)
        {
            if (!undefinedNodes.Remove(targetGroup)) continue;
            Stack<int> targets = new Stack<int>();
            targets.Push(targetGroup);

            while (targets.Count > 0)
            {
                var target = targets.Pop();

                var next = new HashSet<int>();
                foreach (var node in heavyEdges[target])
                {
                    if (undefinedNodes.Remove(node)) next.Add(node);
                }
                //グループ化されていなくて、今のグループと繋がってるedgeは全部グループ入り
                foreach (var node in undefinedNodes)
                {
                    group[node] = targetGroup;
                    targets.Push(node);
                }

                //今調べた全てのノードと切り離されてるノードたちはundefined
                undefinedNodes = next;
            }
        }
        Console.WriteLine(group.Distinct().Count() - 1);
    }
}
