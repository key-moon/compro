// detail: https://yukicoder.me/submissions/398865
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        SegTree<Tuple<int, int>> rmq = new SegTree<Tuple<int, int>>(a.Select((x, y) => new Tuple<int, int>(x, y + 1)).ToArray(), new Tuple<int, int>(int.MaxValue, -1), (x, y) => x.Item1 < y.Item1 ? x : y);
        for (int i = 0; i < nq[1]; i++)
        {
            var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (query[0] == 1)
            {
                var tmp = rmq[query[1] - 1].Item1;
                rmq[query[1] - 1] = new Tuple<int, int>(rmq[query[2] - 1].Item1, query[1]);
                rmq[query[2] - 1] = new Tuple<int, int>(tmp, query[2]);
            }
            else
            {
                Console.WriteLine(rmq.Query(query[1] - 1, query[2] - 1).Item2);
            }
        }
    }
}

class SegTree<T>
{
    int LeafCount;
    T[] Data;
    T Identity;
    Func<T, T, T> Merge;
    public SegTree(T[] arr, T identity, Func<T, T, T> merge)
    {
        Identity = identity;
        Merge = merge;
        LeafCount = 1;
        while (LeafCount < arr.Length) LeafCount *= 2;
        Data = new T[LeafCount * 2];
        for (int i = 0; i < Data.Length; i++) Data[i] = identity;
        arr.CopyTo(Data, LeafCount);
        for (int i = LeafCount - 1; i >= 0; i--) Data[i] = Merge(Data[i << 1], Data[i << 1 | 1]);
    }
    public T this[int index]
    {
        get { return Data[index + LeafCount]; }
        set 
        {
            Data[index += LeafCount] = value;
            while (1 < index)
            {
                index >>= 1;
                Data[index] = Merge(Data[index << 1], Data[index << 1 | 1]);
            }
        }
    }
    public T Query(int l, int r)
    {
        l += LeafCount;
        r += LeafCount;
        T lRes = Identity;
        T rRes = Identity;
        for (; l <= r;)
        {
            if (l % 2 == 1) lRes = Merge(lRes, Data[l]);
            if (r % 2 == 0) rRes = Merge(Data[r], rRes);
            l++; r--; l >>= 1; r >>= 1;
        }
        return Merge(lRes, rRes);
    }
}
