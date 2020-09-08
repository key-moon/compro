// detail: https://atcoder.jp/contests/practice2/submissions/16569240
//Halving(非再帰)
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using static Reader;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

using AtCoder;
using System.Linq;

public static class P
{
    public static void Main()
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        int n = NextInt;
        int q = NextInt;
        
        UnionFind uf = new UnionFind(n);
        DSU dsu = new DSU(n);

        void VerifyGroup()
        {
            var groups = dsu.Groups().ToArray().Select(x => x.OrderBy(x => x).ToArray()).OrderBy(x => x.First()).ToArray();
            var ans = Enumerable.Range(0, n).GroupBy(uf.Find).Select(x => x.OrderBy(x => x).ToArray()).OrderBy(x => x.First()).ToArray();
            if (groups.Length != ans.Length) throw new Exception();
            if (groups.Zip(ans, (x, y) => x.SequenceEqual(y)).Any(x => !x)) throw new Exception();
        }

        for (int i = 0; i < q; i++)
        {
            var (t, u, v) = (NextInt, NextInt, NextInt);
            if (t == 0) { dsu.Merge(u, v); uf.TryUnite(u, v); }
            else Console.WriteLine(dsu.Same(u, v) ? "1" : "0");
            if ((i & -i) == 0) VerifyGroup();
        }
        VerifyGroup();

        Console.Out.Flush();
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0; while (Buffer[ptr] < 48) Move();
            do { res = res * 10 + (int)(Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetSize(int x) => Sizes[Find(x)];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Find(int x)
    {
        while (x != Parent[x]) x = (Parent[x] = Parent[Parent[x]]);
        return x;
    }
}

namespace AtCoder
{
    class DSU
    {
        private int Count;
        private int[] ParentOrSize;

        /// <summary>
        /// <see cref="DSU"/> クラスの新しいインスタンスを、<paramref name="n"/> 頂点 0 辺のグラフとして初期化します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="n"/>≤10^8</para>
        /// <para>計算量: O(<paramref name="n"/>)</para>
        /// </remarks>
        public DSU(int n)
        {
            Count = n;
            ParentOrSize = new int[n];
            for (int i = 0; i < ParentOrSize.Length; i++) ParentOrSize[i] = -1;
        }

        /// <summary>
        /// 頂点 <paramref name="a"/> と頂点 <paramref name="b"/> を結ぶ辺を追加し、それらの代表元を返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="a"/>, <paramref name="b"/>&lt;n</para>
        /// <para>計算量: ならしO(a(n))</para>
        /// </remarks>
        public int Merge(int a, int b)
        {
            Debug.Assert(0 <= a && a < Count);
            Debug.Assert(0 <= b && b < Count);
            int x = Leader(a), y = Leader(b);
            if (x == y) return x;
            if (-ParentOrSize[x] < ParentOrSize[y]) (x, y) = (y, x);
            ParentOrSize[x] += ParentOrSize[y];
            ParentOrSize[y] = x;
            return x;
        }

        /// <summary>
        /// 頂点 <paramref name="a"/>, <paramref name="b"/> が連結かどうかを返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="a"/>, <paramref name="b"/>&lt;n</para>
        /// <para>計算量: ならしO(a(n))</para>
        /// </remarks>
        public bool Same(int a, int b)
        {
            Debug.Assert(0 <= a && a < Count);
            Debug.Assert(0 <= b && b < Count);
            return Leader(a) == Leader(b);
        }

        /// <summary>
        /// 頂点 <paramref name="a"/> の属する連結成分の代表元を返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="a"/>&lt;n</para>
        /// <para>計算量: ならしO(a(n))</para>
        /// </remarks>
        public int Leader(int a)
        {
            if (ParentOrSize[a] < 0) return a;
            while (0 <= ParentOrSize[ParentOrSize[a]])
            {
                (a, ParentOrSize[a]) = (ParentOrSize[a], ParentOrSize[ParentOrSize[a]]);
            }
            return ParentOrSize[a];
        }


        /// <summary>
        /// 頂点 <paramref name="a"/> の属する連結成分のサイズを返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="a"/>&lt;n</para>
        /// <para>計算量: ならしO(a(n))</para>
        /// </remarks>
        public int Size(int a)
        {
            Debug.Assert(0 <= a && a < Count);
            return -ParentOrSize[Leader(a)];
        }

        /// <summary>
        /// グラフを連結成分に分け、その情報を返します。
        /// </summary>
        /// <para>計算量: O(n)</para>
        /// <returns>「一つの連結成分の頂点番号のリスト」のリスト。</returns>
        public Span<int[]> Groups()
        {
            int[] leaderBuf = new int[Count];
            int[] id = new int[Count];
            Span<int[]> result = new int[Count][];
            int groupCount = 0;
            for (int i = 0; i < leaderBuf.Length; i++)
            {
                leaderBuf[i] = Leader(i);
                if (i == leaderBuf[i])
                {
                    id[i] = groupCount;
                    result[id[i]] = new int[-ParentOrSize[i]];
                    groupCount++;
                }
            }
            int[] ind = new int[groupCount];
            result = result.Slice(0, groupCount);
            for (int i = 0; i < leaderBuf.Length; i++)
            {
                var leaderID = id[leaderBuf[i]];
                result[leaderID][ind[leaderID]] = i;
                ind[leaderID]++;
            }

            return result;
        }
    }
}

