// detail: https://atcoder.jp/contests/abc176/submissions/16113406
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
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hw[0];
        var w = hw[1];
        var chcw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var ch = chcw[0] - 1;
        var cw = chcw[1] - 1;
        var dhdw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var dh = dhdw[0] - 1;
        var dw = dhdw[1] - 1;
        int[][] dists = Enumerable.Repeat(0, h).Select(_ => Enumerable.Repeat(int.MaxValue / 2, w).ToArray()).ToArray();
        var map = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine()).ToArray();
        Deque<(int, int, int)> stack = new Deque<(int, int, int)>();
        stack.PushBack((ch, cw, 0));
        while (stack.Count > 0)
        {
            var (y, x, dist) = stack.PopFront();
            if (map[y][x] == '#' || dist >= dists[y][x]) continue;
            dists[y][x] = dist;
            var ymin = Max(0, y - 2);
            var ymax = Min(h - 1, y + 2);
            var xmin = Max(0, x - 2);
            var xmax = Min(w - 1, x + 2);
            for (int i = ymin; i <= ymax; i++)
            {
                for (int j = xmin; j <= xmax; j++)
                {
                    if (Abs(i - y) + Abs(j - x) <= 1)
                        stack.PushFront((i, j, dist));
                    else
                        stack.PushBack((i, j, dist + 1));
                }
            }
        }
        var res = dists[dh][dw];
        if (res == int.MaxValue / 2) res = -1;
        Console.WriteLine(res);
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
