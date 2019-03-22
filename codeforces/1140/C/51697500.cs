// detail: https://codeforces.com/contest/1140/submission/51697500
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;


static class P
{
    static void Main()
    {
        Random RNG = new Random();
        var nk = Console.ReadLine().Split().Select(int.Parse).ToList();
        var tbs = Enumerable.Repeat(0, nk[0]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToList()).OrderBy(_ => RNG.Int).OrderBy(x => x[1]).ToList();
        //beautyが小さいものの上
        //その上で長さ
        //上から取っていく?
        //
        PriorityQueue<int> queue = new PriorityQueue<int>(nk[0]);
        long length = 0;
        long max = 0;
        for (int i = nk[0] - 1; i >= nk[0] - nk[1]; i--)
        {
            length += tbs[i][0];
            max = Max(max, length * tbs[i][1]);
            queue.Push(tbs[i][0]);
        }

        for (int i = nk[0] - nk[1] - 1; i >= 0; i--)
        {
            length += tbs[i][0];
            queue.Push(tbs[i][0]);
            var pop = queue.Pop();
            length -= pop;
            max = Max(max, length * tbs[i][1]);
        }
        Console.WriteLine(max);
    }
}

public class PriorityQueue<T> where T : IComparable
{
    Func<T, T, int> _comparer = null;
    private int _type = 0;

    private T[] _heap;
    private int _sz = 0;

    private int _count = 0;

    /// <summary>
    /// Priority Queue with custom comparer
    /// </summary>
    public PriorityQueue(int maxSize, Func<T, T, int> comparer)
    {
        _heap = new T[maxSize];
        _comparer = comparer;
    }

    /// <summary>
    /// Priority queue
    /// </summary>
    /// <param name="maxSize">max size</param>
    /// <param name="type">0: asc, 1:desc</param>
    public PriorityQueue(int maxSize, int type = 0)
    {
        _heap = new T[maxSize];
        _type = type;
    }

    private int Compare(T x, T y)
    {
        if (_comparer != null) return _comparer(x, y);
        return _type == 0 ? x.CompareTo(y) : y.CompareTo(x);
    }

    public void Push(T x)
    {
        _count++;

        //node number
        var i = _sz++;

        while (i > 0)
        {
            //parent node number
            var p = (i - 1) / 2;

            if (Compare(_heap[p], x) <= 0) break;

            _heap[i] = _heap[p];
            i = p;
        }

        _heap[i] = x;
    }

    public T Pop()
    {
        _count--;

        T ret = _heap[0];
        T x = _heap[--_sz];

        int i = 0;
        while (i * 2 + 1 < _sz)
        {
            //children
            int a = i * 2 + 1;
            int b = i * 2 + 2;

            if (b < _sz && Compare(_heap[b], _heap[a]) < 0) a = b;

            if (Compare(_heap[a], x) >= 0) break;

            _heap[i] = _heap[a];
            i = a;
        }

        _heap[i] = x;

        return ret;
    }

    public int Count()
    {
        return _count;
    }

    public T Peek()
    {
        return _heap[0];
    }

    public bool Contains(T x)
    {
        for (int i = 0; i < _sz; i++) if (x.Equals(_heap[i])) return true;
        return false;
    }

    public void Clear()
    {
        while (this.Count() > 0) this.Pop();
    }

    public IEnumerator<T> GetEnumerator()
    {
        var ret = new List<T>();

        while (this.Count() > 0)
        {
            ret.Add(this.Pop());
        }

        foreach (var r in ret)
        {
            this.Push(r);
            yield return r;
        }
    }

    public T[] ToArray()
    {
        T[] array = new T[_sz];
        int i = 0;

        foreach (var r in this)
        {
            array[i++] = r;
        }

        return array;
    }
}

[StructLayout(LayoutKind.Explicit)]
class Random
{
    [FieldOffset(0)]
    private byte __byte;
    [FieldOffset(0)]
    private sbyte __sbyte;
    [FieldOffset(0)]
    private char __char;
    [FieldOffset(0)]
    private short __short;
    [FieldOffset(0)]
    private ushort __ushort;
    [FieldOffset(0)]
    private int __int;
    [FieldOffset(0)]
    private uint __uint;
    [FieldOffset(0)]
    private long __long;
    [FieldOffset(0)]
    private ulong __ulong;

    public byte Byte { get { Next(); return __byte; } }
    public sbyte SByte { get { Next(); return __sbyte; } }
    public char Char { get { Next(); return __char; } }
    public short Short { get { Next(); return __short; } }
    public ushort UShort { get { Next(); return __ushort; } }
    public int Int { get { Next(); return __int; } }
    public uint UInt { get { Next(); return __uint; } }
    public long Long { get { Next(); return __long; } }
    public ulong ULong { get { Next(); return __ulong; } }

    public double Double { get { return (double)ULong / ulong.MaxValue; } }

    [FieldOffset(0)]
    private ulong _xorshift;

    public Random() : this((ulong)DateTime.Now.Ticks) { }
    public Random(ulong seed) { SetSeed(seed); }
    public void SetSeed(ulong seed) => _xorshift = seed * 0x3141592c0ffeeul;

    public void Next()
    {
        _xorshift ^= _xorshift << 7;
        _xorshift ^= _xorshift >> 9;
    }
}