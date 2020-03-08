// detail: https://atcoder.jp/contests/hitachi2020/submissions/10680671
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }

        int[] depth = Enumerable.Repeat(-1, n).ToArray();
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        depth[0] = 0;
        while (stack.Count > 0)
        {
            var elem = stack.Pop();
            foreach (var item in graph[elem])
            {
                if (depth[item] != -1) continue;
                depth[item] = depth[elem] ^ 1;
                stack.Push(item);
            }
        }
        var zeroCount = depth.Count(x => x == 0);
        var oneCount = depth.Count(x => x == 1);

        var permZeroCount = n / 3;

        int[] res = new int[n];
        
        if (zeroCount <= permZeroCount || oneCount <= permZeroCount)
        {
            var zeroClearSig = oneCount <= permZeroCount ? 1 : 0;
            bool[] used = new bool[n + 3];
            //HashSet<int> unused = new HashSet<int>(Enumerable.Range(1, n));
            int next = 3;
            for (int i = 0; i < depth.Length; i++)
            {
                if (depth[i] == zeroClearSig)
                {
                    res[i] = (next += 3) - 3;
                    used[res[i]] = true;
                    //unused.Remove(res[i]);
                }
            }
            int ptr = 1;
            for (int i = 0; i < depth.Length; i++)
            {
                if (res[i] == 0)
                {
                    while (used[ptr]) ptr++;
                    res[i] = ptr;
                    used[res[i]] = true;
                    //unused.Remove(res[i]);
                }
            }
        }
        else
        {
            int lastOne = 1;
            int lastTwo = 2;
            int lastZero = 3;
            for (int i = 0; i < depth.Length; i++)
            {
                if (depth[i] == 0) res[i] = lastOne <= n ? (lastOne += 3) - 3 : (lastZero += 3) - 3;
                else res[i] = lastTwo <= n ? (lastTwo += 3) - 3 : (lastZero += 3) - 3;
            }
        }

        Console.WriteLine(string.Join(" ", res));
    }
}
