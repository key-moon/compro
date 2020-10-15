// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_13_C/judge/4915935/C#
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
        ulong data = 0UL;
        int pos = 0;
        int shift = 64;
        for (int i = 0; i < 4; i++)
        {
            foreach (var item in Console.ReadLine().Split().Select(ulong.Parse))
            {
                shift -= 4;
                data |= item << shift;
                if (item == 0) pos = shift / 4;
            }
        }
        Dictionary<ulong, int> dists = new Dictionary<ulong, int>();
        PriorityQueue<Board, int> pqueue = new PriorityQueue<Board, int>(x => dists[x.Data] + x.Distance);
        dists[data] = 0;
        pqueue.Push(new Board(data, pos));
        if (data == Board.CorrectData) goto end;
        while (pqueue.Count > 0)
        {
            var board = pqueue.Pop();
            var dist = dists[board.Data];
            foreach (var next in board.Next)
            {
                if (45 < dist + next.Distance) continue;
                if (!dists.ContainsKey(next.Data)) dists.Add(next.Data, int.MaxValue);
                if (dists[next.Data] <= dist + 1) continue;
                dists[next.Data] = dist + 1;
                if (next.Data == Board.CorrectData) goto end;
                pqueue.Push(next);
            }
        }
        end:;
        Console.WriteLine(dists[Board.CorrectData]);
    }
}


class PriorityQueue<TValue, TKey> where TKey : IComparable<TKey>
{
    public int Count { get; private set; }
    private Func<TValue, TKey> KeySelector;
    private bool Descendance;
    private TValue[] data = new TValue[65536];
    private TKey[] keys = new TKey[65536];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PriorityQueue(Func<TValue, TKey> keySelector, bool descendance = false) { KeySelector = keySelector; Descendance = descendance; }
    public TValue Top
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { ValidateNonEmpty(); return data[1]; }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TValue Pop()
    {
        var top = Top;
        var item = data[Count];
        var key = keys[Count--];
        int index = 1;
        while (true)
        {
            if ((index << 1) >= Count)
            {
                if (index << 1 > Count) break;
                if (key.CompareTo(keys[index << 1]) > 0 ^ Descendance)
                { data[index] = data[index << 1]; keys[index] = keys[index << 1]; index <<= 1; }
                else break;
            }
            else
            {
                var nextIndex = keys[index << 1].CompareTo(keys[(index << 1) + 1]) <= 0 ^ Descendance ? (index << 1) : (index << 1) + 1;
                if (key.CompareTo(keys[nextIndex]) > 0 ^ Descendance)
                { data[index] = data[nextIndex]; keys[index] = keys[nextIndex]; index = nextIndex; }
                else break;
            }
        }
        data[index] = item;
        keys[index] = key;
        return top;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Push(TValue item)
    {
        var key = KeySelector(item);
        int index = ++Count;
        if (data.Length == Count) Extend(data.Length * 2);
        while ((index >> 1) != 0)
        {
            if (keys[index >> 1].CompareTo(key) > 0 ^ Descendance)
            { data[index] = data[index >> 1]; keys[index] = keys[index >> 1]; index >>= 1; }
            else break;
        }
        data[index] = item;
        keys[index] = key;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Extend(int newSize)
    {
        TValue[] newData = new TValue[newSize];
        TKey[] newKeys = new TKey[newSize];
        data.CopyTo(newData, 0);
        keys.CopyTo(newKeys, 0);
        data = newData;
        keys = newKeys;
    }
    private void ValidateNonEmpty() { if (Count == 0) throw new IndexOutOfRangeException(); }
}

struct Board
{
    public const ulong CorrectData = 0x123456789abcdef0U;
    public ulong Data;
    public int Pos;

    public int Distance;

    public Board(ulong data, int pos)
    {
        Data = data;
        Pos = pos;
        Distance = DistanceSum(data);
    }

    public IEnumerable<Board> Next
    {
        get
        {
            if ((Pos & 3) != 0) yield return new Board(Swap(Data, Pos, Pos - 1), Pos - 1);
            if ((Pos & 3) != 3) yield return new Board(Swap(Data, Pos, Pos + 1), Pos + 1);
            if (4 <= Pos) yield return new Board(Swap(Data, Pos, Pos - 4), Pos - 4);
            if (Pos < 12) yield return new Board(Swap(Data, Pos, Pos + 4), Pos + 4);
        }
    }

    public int IncorrectCount => NonZeroCellCount(Data ^ CorrectData);
    static private int NonZeroCellCount(ulong data)
    {
        if (data == 0) return 0;
        data |= data >> 1;
        data |= data >> 2;
        data &= 0x1111111111111111UL;
        data *= 0x1111111111111111UL;
        data >>= 60;
        if (data == 0) data = 16;
        return (int)data;
    }

    static private int DistanceSum(ulong data)
    {
        if (data == 0) return 0;
        int dist = 0;
        for (int i = 0; i < 16; i++)
        {
            var cell = (int)(((data >> (i * 4)) + 15) & 0xf);
            if (cell == 15) continue;
            dist += Abs((cell & 3) + (i & 3) - 3) + Abs((cell >> 2) + (i >> 2) - 3);
        }
        return dist;
    }

    static private ulong Swap(ulong data, int pos1, int pos2)
    {
        var xoredData = ((data >> pos1 * 4) ^ (data >> pos2 * 4)) & 0xf;
        data ^= xoredData << pos1 * 4;
        data ^= xoredData << pos2 * 4;
        return data;
    }

    public override string ToString() => Data.ToString("x");
}

