// detail: https://codeforces.com/contest/1450/submission/100558830
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool Validate(int[] a)
        {
            return a.Min() == 1 && a.Max() == a.Length && a.Distinct().Count() == a.Length;
        }
        int valid = n + 1;
        int invalid = 1;
        while (valid - invalid > 1)
        {
            var mid = (invalid + valid) / 2;

            var cnt = n - mid + 1;
            var seq = new int[cnt];
            FoldableQueue<int> fQueue = new FoldableQueue<int>(Min);
            for (int i = 0; i < mid - 1; i++) fQueue.Push(a[i]);
            for (int i = 0; i < seq.Length; i++)
            {
                fQueue.Push(a[i + mid - 1]);
                seq[i] = fQueue.Value;
                fQueue.Pop();
            }
            
            if (Validate(seq)) valid = mid;
            else invalid = mid;
        }
        char[] res = new char[n];
        res[0] = Validate(a) ? '1' : '0';
        for (int i = 1; i < n; i++)
        {
            res[i] = valid <= i + 1 ? '1' : '0';
        }
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
