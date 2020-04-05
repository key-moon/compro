// detail: https://atcoder.jp/contests/abc142/submissions/11600622
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
        }
        ImmutableStack<int> resStack = null;
        for (int i = 0; i < n; i++)
        {
            ImmutableStack<int>[] istacks = new ImmutableStack<int>[n];
            istacks[i] = new ImmutableStack<int>().Push(i);
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(i);
            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                foreach (var adj in graph[item])
                {
                    if (adj == i)
                    {
                        if (resStack == null || resStack.Count > istacks[item].Count) resStack = istacks[item];
                        goto end;
                    }
                    if (istacks[adj] != null) continue;
                    istacks[adj] = istacks[item].Push(adj);
                    queue.Enqueue(adj);
                }
            }
            end:;
        }
        if (resStack == null) Console.WriteLine(-1);
        else
        {
            Console.WriteLine(resStack.Count);
            while (resStack.Count > 0)
            {
                Console.WriteLine(resStack.Top + 1);
                resStack = resStack.Pop();
            }
        }
    }
}


class ImmutableStack<T>
{
    readonly ImmutableStack<T> previousStack;
    public readonly T Top;
    public readonly int Count;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ImmutableStack() : this(null, default(T), 0) { }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ImmutableStack(ImmutableStack<T> prev, T top, int count)
    {
        previousStack = prev;
        Top = top;
        Count = count;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ImmutableStack<T> Push(T value) => new ImmutableStack<T>(this, value, Count + 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ImmutableStack<T> Pop() => previousStack == null ? null : previousStack;
}
