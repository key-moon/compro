// detail: https://atcoder.jp/contests/arc081/submissions/11006903
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
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
        var toNext = Enumerable.Range('a', 26).Select(x => new ImmutableStack<char>().Push((char)x)).ToArray();
        foreach (var c in Console.ReadLine().Reverse())
        {
            var minStack = toNext.Aggregate(toNext[0], (x, y) => x.Count > y.Count ? y : x);
            toNext[c - 'a'] = minStack.Push(c);
        }

        Console.WriteLine(string.Join("", toNext.Aggregate(toNext[0], (x, y) => x.Count > y.Count ? y : x)));
    }
}

class ImmutableStack<T> : IEnumerable<T>
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

    public IEnumerator<T> GetEnumerator()
    {
        if (Count == 0) yield break;
        yield return Top;
        foreach (var item in previousStack) yield return item;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
