// detail: https://atcoder.jp/contests/abc203/submissions/23067881
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var a = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToArray();

        int[] next = new int[n];
        int ptr = 0;
        for (int i = 0; i < a.Length; i++)
        {
            while (ptr < a.Length && a[i] / 2 < a[ptr]) ptr++;
            next[i] = ptr;
        }
        int[][] res = Enumerable.Repeat(0, 32).Select(x => Enumerable.Repeat(int.MaxValue / 2, n + 1).ToArray()).ToArray();

        Deque<(int, int, int)> deque = new Deque<(int, int, int)>();
        deque.PushFront((0, 0, 0));
        while (deque.Count != 0)
        {
            var (i, j, cost) = deque.PopBack();
            if (res[i][j] < cost) continue;
            if (j == n) continue;
            if (cost < res[i + 1][next[j]])
            {
                deque.PushFront((i + 1, next[j], cost));
                res[i + 1][next[j]] = cost;
            }
            if (cost + 1 < res[i][j + 1])
            {
                deque.PushBack((i, j + 1, cost + 1));
                res[i][j + 1] = cost + 1;
            }
        }
        var minOp = Enumerable.Range(0, 32).Where(x => res[x][n] <= k).Min();
        var minCost = res[minOp][n];
        Console.WriteLine($"{minOp} {minCost}");
    }
}


class Deque<T> : IEnumerable<T>
{
    public int Count;
    T[] data; int FrontInd, BackInd;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Deque() { data = new T[1 << 16]; FrontInd = 0; BackInd = data.Length - 1; Count = 0; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Deque(T[] elem)
    {
        int s = elem.Length; s |= s >> 1; s |= s >> 2; s |= s >> 4; s |= s >> 8; s |= s >> 16;
        data = new T[++s]; elem.CopyTo(data, 0);
        FrontInd = 0; BackInd = elem.Length - 1; Count = elem.Length;
    }

    public T Front
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { ValidateNoEmpty(); return data[FrontInd]; }
    }
    public T Back
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { ValidateNoEmpty(); return data[BackInd]; }
    }

    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { if (index >= Count) throw new Exception(); return data[FrontInd + index & data.Length - 1]; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { if (index >= Count) throw new Exception(); data[FrontInd + index & data.Length - 1] = value; }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void PushFront(T elem) { if (Count == data.Length) Extend(data.Length << 1); Count++; data[FrontInd = (FrontInd - 1) & data.Length - 1] = elem; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T PopFront() { var res = Front; FrontInd = (FrontInd + 1) & data.Length - 1; Count--; return res; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void PushBack(T elem) { if (Count == data.Length) Extend(data.Length << 1); Count++; data[BackInd = (BackInd + 1) & data.Length - 1] = elem; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T PopBack() { var res = Back; BackInd = (BackInd - 1) & data.Length - 1; Count--; return res; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Extend(int newSize)
    {
        T[] newData = new T[newSize];
        if (0 < Count)
        {
            if (FrontInd <= BackInd) Array.Copy(data, FrontInd, newData, 0, Count);
            else
            {
                Array.Copy(data, FrontInd, newData, 0, data.Length - FrontInd);
                Array.Copy(data, 0, newData, data.Length - FrontInd, BackInd + 1);
            }
        }
        data = newData; FrontInd = 0; BackInd = Count - 1;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ValidateNoEmpty() { if (Count == 0) throw new Exception(); }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerator<T> GetEnumerator() { for (int i = FrontInd; i != BackInd; i = i + 1 & data.Length - 1) yield return data[i]; yield return data[BackInd]; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
}
