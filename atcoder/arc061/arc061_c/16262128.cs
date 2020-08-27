// detail: https://atcoder.jp/contests/arc061/submissions/16262128
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
using static Reader;
using static System.Math;

public static class P
{
    public static void Main()
    {
        var (n, m) = (NextInt, NextInt);
        var edges = Enumerable.Repeat(0, m).Select(_ => (NextInt - 1, NextInt - 1, NextInt)).ToArray();

        Dictionary<(int, int), int> dict = new Dictionary<(int, int), int>();
        UnionFind uf = new UnionFind(m);
        foreach (var ((s, t, c), ind) in edges.Select((elem, ind) => (elem, ind)))
        {
            if (!dict.TryAdd((s, c), ind)) uf.TryUnite(dict[(s, c)], ind);
            if (!dict.TryAdd((t, c), ind)) uf.TryUnite(dict[(t, c)], ind);
            uf.TryUnite(dict[(s, c)], dict[(t, c)]);
        }

        List<(int, int)>[] graph = Enumerable.Repeat(0, n + m).Select(_ => new List<(int, int)>()).ToArray();
        foreach (var ((s, t, c), ind) in edges.Select((elem, ind) => (elem, ind)))
        {
            graph[s].Add((n + ind, 1));
            graph[n + ind].Add((s, 0));

            graph[t].Add((n + ind, 1));
            graph[n + ind].Add((t, 0));
            
            var represent = uf.Find(dict[(s, c)]);
            if (represent != ind)
            {
                graph[n + ind].Add((n + represent, 0));
                graph[n + represent].Add((n + ind, 0));
            }
        }

        int[] dists = Enumerable.Repeat(int.MaxValue / 2, n + m).ToArray();
        Deque<(int, int)> deque = new Deque<(int, int)>();
        deque.PushFront((0, 0));
        while (deque.Count != 0)
        {
            var (from, dist) = deque.PopFront();
            if (dists[from] <= dist) continue;
            dists[from] = dist;
            foreach (var (to, edgeCost) in graph[from])
            {
                var nextDist = dist + edgeCost;
                if (dists[to] <= nextDist) continue;
                if (edgeCost == 0) deque.PushFront((to, nextDist));
                else deque.PushBack((to, nextDist));
            }
        }
        var res = dists[n - 1];
        Console.WriteLine(res == int.MaxValue / 2 ? -1 : res);
    }
}


class Deque<T> : IEnumerable<T>
{
    public int Count;
    T[] data; int FrontInd, BackInd;
    public Deque() { data = new T[1 << 16]; FrontInd = 0; BackInd = data.Length - 1; Count = 0; }
    public Deque(T[] elem)
    {
        int s = elem.Length; s |= s >> 1; s |= s >> 2; s |= s >> 4; s |= s >> 8; s |= s >> 16;
        data = new T[++s]; elem.CopyTo(data, 0);
        FrontInd = 0; BackInd = elem.Length - 1; Count = elem.Length;
    }

    public T Front
    {
        get { ValidateNoEmpty(); return data[FrontInd]; }
    }
    public T Back
    {
        get { ValidateNoEmpty(); return data[BackInd]; }
    }

    public T this[int index]
    {
        get { if (index >= Count) throw new Exception(); return data[FrontInd + index & data.Length - 1]; }
        set { if (index >= Count) throw new Exception(); data[FrontInd + index & data.Length - 1] = value; }
    }

    public void PushFront(T elem) { if (Count == data.Length) Extend(data.Length << 1); Count++; data[FrontInd = (FrontInd - 1) & data.Length - 1] = elem; }
    public T PopFront() { var res = Front; FrontInd = (FrontInd + 1) & data.Length - 1; Count--; return res; }
    public void PushBack(T elem) { if (Count == data.Length) Extend(data.Length << 1); Count++; data[BackInd = (BackInd + 1) & data.Length - 1] = elem; }
    public T PopBack() { var res = Back; BackInd = (BackInd - 1) & data.Length - 1; Count--; return res; }
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
    private void ValidateNoEmpty() { if (Count == 0) throw new Exception(); }

    public IEnumerator<T> GetEnumerator() { for (int i = FrontInd; i != BackInd; i = i + 1 & data.Length - 1) yield return data[i]; yield return data[BackInd]; }
    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
}

class UnionFind
{
    public int Size { get; private set; }
    public int GroupCount { get; private set; }
    public IEnumerable<int> AllRepresents => Parent.Where((x, y) => x == y);
    int[] Sizes;
    int[] Parent;
    public UnionFind(int count)
    {
        Size = count;
        GroupCount = count;
        Parent = new int[count];
        Sizes = new int[count];
        for (int i = 0; i < count; i++) Sizes[Parent[i] = i] = 1;
    }
    public bool TryUnite(int x, int y)
    {
        int xp = Find(x);
        int yp = Find(y);
        if (yp == xp) return false;
        if (Sizes[xp] < Sizes[yp]) { var tmp = xp; xp = yp; yp = tmp; }
        GroupCount--;
        Parent[yp] = xp;
        Sizes[xp] += Sizes[yp];
        return true;
    }
    public int GetSize(int x) => Sizes[Find(x)];
    public int Find(int x)
    {
        while (x != Parent[x]) x = (Parent[x] = Parent[Parent[x]]);
        return x;
    }
}

static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = BUF_SIZE - 1;
    static void Move() { if (++ptr >= Buffer.Length) { Stream.Read(Buffer, 0, BUF_SIZE); ptr = 0; } }

    public static int NextInt
    {
        get
        {
            int res = 0; while (Buffer[ptr] < 48) Move();
            do { res = res * 10 + (int)(Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
}
