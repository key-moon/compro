// detail: https://atcoder.jp/contests/abc183/submissions/18136729
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
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var q = nq[1];
        var c = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var sqrt = 500;
        var overKey = c.GroupBy(x => x).Where(x => sqrt <= x.Count()).Select(x => x.Key).ToArray();
        var dic = overKey.Select((x, ind) => (x, ind)).ToDictionary(x => x.x, x => x.ind);
        var belows = c.Select((val, ind) => (val, ind)).GroupBy(x => x.val).Where(x => x.Count() < sqrt).ToArray();
        var belowDic = belows.ToDictionary(x => x.Key, x => x.Select(x => x.ind).ToArray());
        UnionFind<int[]> uf = new UnionFind<int[]>(nq[0], (x, y) => x.Zip(y, (x, y) => x + y).ToArray());
        for (int i = 0; i < c.Length; i++)
        {
            uf[i] = new int[dic.Count];
            if (dic.ContainsKey(c[i])) uf[i][dic[c[i]]]++;
        }
        for (int i = 0; i < q; i++)
        {
            var tab = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            if (tab[0] == 1)
            {
                uf.TryUnite(tab[1] - 1, tab[2] - 1);
            }
            else
            {
                var a = tab[1] - 1;
                var kind = tab[2];
                if (belowDic.ContainsKey(kind))
                {
                    int res = 0;
                    foreach (var item in belowDic[kind])
                    {
                        if (uf.Find(a) == uf.Find(item)) res++;
                    }
                    Console.WriteLine(res);
                }
                else if (dic.ContainsKey(kind))
                {
                    Console.WriteLine(uf[a][dic[kind]]);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}


class UnionFind<T>
{
    public readonly int Size;
    public int GroupCount { get; private set; }
    public IEnumerable<int> AllRepresents => Parent.Where((x, y) => x == y);
    int[] Sizes;
    int[] Parent;
    T[] Data;
    Func<T, T, T> MergeData;
    public UnionFind(int count, Func<T, T, T> mergeData)
    {
        Size = count;
        GroupCount = count;
        Parent = new int[count];
        Sizes = new int[count];
        Data = new T[count];
        MergeData = mergeData;
        for (int i = 0; i < count; i++)
        {
            Parent[i] = i;
            Sizes[i] = 1;
            Data[i] = default(T);
        }
    }
    public T this[int index]
    {
        get { return Data[Find(index)]; }
        set { Data[Find(index)] = value; }
    }

    public bool TryUnite(int x, int y)
    {
        int xp = Find(x);
        int yp = Find(y);
        if (yp == xp) return false;
        if (Sizes[xp] < Sizes[yp])
        {
            var tmp = xp;
            xp = yp;
            yp = tmp;
        }
        GroupCount--;
        Parent[yp] = xp;
        Data[xp] = MergeData(Data[xp], Data[yp]);
        Sizes[xp] += Sizes[yp];
        return true;
    }
    public int GetSize(int x) => Sizes[Find(x)];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Find(int x)
    {
        while (x != Parent[x])
        {
            Parent[x] = Parent[Parent[x]];
            x = Parent[x];
        }
        return x;
    }
}
