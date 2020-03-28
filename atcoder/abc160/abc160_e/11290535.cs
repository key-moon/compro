// detail: https://atcoder.jp/contests/abc160/submissions/11290535
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
        var xyabc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var X = xyabc[0];
        var Y = xyabc[1];
        var p = Console.ReadLine().Split().Select(long.Parse).OrderBy(x => x).ToArray();
        var q = Console.ReadLine().Split().Select(long.Parse).OrderBy(x => x).ToArray();
        var r = Console.ReadLine().Split().Select(long.Parse).OrderBy(x => x).ToArray();
        PriorityQueue<long> red = new PriorityQueue<long>();
        PriorityQueue<long> green = new PriorityQueue<long>();
        foreach (var item in p) red.Push(item);
        foreach (var item in q) green.Push(item);
        while (red.Count > X) red.Pop();
        while (green.Count > Y) green.Pop();
        foreach (var item in r.OrderBy(Z => Z))
        {
            if (red.Top < green.Top)
            {
                red.Push(item);
                red.Pop();
            }
            else
            {
                green.Push(item);
                green.Pop();
            }
        }
        var res = 0L;
        while (red.Count > 0) res += red.Pop();
        while (green.Count > 0) res += green.Pop();
        Console.WriteLine(res);
    }
}


class PriorityQueue<T> where T : IComparable<T>
{
    public int Count { get; private set; }
    private bool Descendance;
    private T[] data = new T[65536];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PriorityQueue(bool descendance = false) { Descendance = descendance; }
    public T Top
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { ValidateNonEmpty(); return data[1]; }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Pop()
    {
        var top = Top;
        var elem = data[Count--];
        int index = 1;
        while (true)
        {
            if ((index << 1) >= Count)
            {
                if (index << 1 > Count) break;
                if (elem.CompareTo(data[index << 1]) > 0 ^ Descendance) data[index] = data[index <<= 1];
                else break;
            }
            else
            {
                var nextIndex = data[index << 1].CompareTo(data[(index << 1) + 1]) <= 0 ^ Descendance ? (index << 1) : (index << 1) + 1;
                if (elem.CompareTo(data[nextIndex]) > 0 ^ Descendance) data[index] = data[index = nextIndex];
                else break;
            }
        }
        data[index] = elem;
        return top;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Push(T value)
    {
        int index = ++Count;
        if (data.Length == Count) Extend(data.Length * 2);
        while ((index >> 1) != 0)
        {
            if (data[index >> 1].CompareTo(value) > 0 ^ Descendance) data[index] = data[index >>= 1];
            else break;
        }
        data[index] = value;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Extend(int newSize)
    {
        T[] newDatas = new T[newSize];
        data.CopyTo(newDatas, 0);
        data = newDatas;
    }
    private void ValidateNonEmpty() { if (Count == 0) throw new Exception(); }
}
