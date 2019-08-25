// detail: https://codeforces.com/contest/1208/submission/59469824
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        //while (true) Validate(100000);
        Console.WriteLine(string.Join(" ", Solve(int.Parse(Console.ReadLine()), Console.ReadLine().Split().Select(long.Parse).ToArray())));
    }

    static int[] Solve(int n, long[] a)
    {
        var res = new int[n];
        BIT<long> bit = new BIT<long>(n + 1, 0, (x, y) => x + y);
        for (int i = 0; i < bit.Size; i++)
            bit.Operate(i, i);
        for (int i = a.Length - 1; i >= 1; i--)
        {
            int valid = n + 1;
            int invalid = -1;
            while (valid - invalid > 1)
            {
                var mid = (valid + invalid) / 2;
                if (a[i] < bit.Query(mid)) valid = mid;
                else invalid = mid;
            }
            res[i] = valid;
            bit.Operate(res[i], -res[i]);
        }
        res[0] = (int)bit.Query(bit.Size - 1);
        return res;
    }

    static void Validate(int n)
    {
        Random rng = new Random();
        var res = Enumerable.Range(1, n).OrderBy(x => rng.Next()).ToArray();
        BIT<long> bit = new BIT<long>(n + 1, 0, (x, y) => x + y);
        long[] a = new long[n];
        for (int i = 0; i < res.Length; i++)
        {
            a[i] = bit.Query(res[i]);
            bit.Operate(res[i], res[i]);
        }
        System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        var ans = Solve(n, a);
        Console.WriteLine(watch.ElapsedMilliseconds);
        if (res.Zip(ans, (x, y) => x != y).Any(x => x))
        {
            Console.WriteLine(string.Join(" ", res));
            Console.WriteLine(string.Join(" ", Solve(n, a)));
            Console.WriteLine(string.Join(" ", a));
        }
    }
}

class BIT<T>
{
    public readonly int Size;
    T Identity;
    T[] Elements;
    Func<T, T, T> Merge;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BIT(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Identity = identity;
        Merge = merge;
        Elements = new T[Size + 1];
        for (int i = 0; i < Elements.Length; i++)
            Elements[i] = identity;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int r)
    {
        T res = Identity;
        for (r++; r > 0; r -= r & -r)
            res = Merge(res, Elements[r]);
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x)
    {
        for (i++; i < Elements.Length; i += i & -i)
            Elements[i] = Merge(Elements[i], x);
    }

    public override string ToString() => string.Join(" ", Enumerable.Range(0, Size).Select(x => Query(x)));
}

