// detail: https://codeforces.com/contest/846/submission/111319410
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
        var nmkq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nmkq[0];
        var m = nmkq[1];
        var k = nmkq[2];
        var q = nmkq[3];

        int[][] mat = Enumerable.Repeat(0, n).Select(_ => Enumerable.Repeat(int.MaxValue / 2, m).ToArray()).ToArray();

        for (int i = 0; i < q; i++)
        {
            var xyt = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var x = xyt[0] - 1;
            var y = xyt[1] - 1;
            var t = xyt[2];
            mat[x][y] = t;
        }


        FoldableQueue<int>[] fqueues = Enumerable.Repeat(0, n).Select(_ => new FoldableQueue<int>(Max)).ToArray();
        
        int res = int.MaxValue / 2;
        for (int j = 0; j < m; j++)
        {
            FoldableQueue<int> fqueue = new FoldableQueue<int>(Max);
            for (int i = 0; i < n; i++)
            {
                fqueues[i].Push(mat[i][j]);
                if (fqueues[i].Count == k)
                {
                    fqueue.Push(fqueues[i].Value);
                    fqueues[i].Pop();
                }
                if (fqueue.Count == k)
                {
                    res = Min(res, fqueue.Value);
                    fqueue.Pop();
                }
            }
        }

        if (res == int.MaxValue / 2) res = -1;
        Console.WriteLine(res);
    }
}


class FoldableQueue<T>
{
    public int Count { get; private set; }
    public T Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return
                TailValueStack.Count == 0 ? FrontValue :
                FrontIsEmpty ? TailValueStack.Peek() :
                Merge(TailValueStack.Peek(), FrontValue);
        }
    }

    bool FrontIsEmpty = true;
    T FrontValue;
    Stack<T> Fronts = new Stack<T>();
    Stack<T> TailValueStack = new Stack<T>();

    Func<T, T, T> Merge;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FoldableQueue(Func<T, T, T> merge) { Merge = merge; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Pop()
    {
        Validate();
        if (TailValueStack.Count == 0) Move();
        TailValueStack.Pop();
        Count--;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Push(T item)
    {
        Fronts.Push(item);
        Count++;
        FrontValue = FrontIsEmpty ? item : Merge(FrontValue, item);
        FrontIsEmpty = false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Move()
    {
        TailValueStack.Push(Fronts.Pop());
        while (0 < Fronts.Count)
            TailValueStack.Push(Merge(Fronts.Pop(), TailValueStack.Peek()));
        FrontIsEmpty = true;
    }

    private void Validate() { if (Count == 0) throw new Exception(); }
}
