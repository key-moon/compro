// detail: https://atcoder.jp/contests/arc106/submissions/17619663
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        if (n == 1)
        {
            if (m == 0)
            {
                Console.WriteLine("314 1592");
            }
            else
            {
                Console.WriteLine("-1");
            }
            return;
        }
        //高橋くんが最適
        if (m < 0 || m == n - 1 || m == n)
        {
            Console.WriteLine(-1);
            return;
        }

        List<(int, int)> list = new List<(int, int)>();
        var offset = (int)(1e8 - 1);
        list.Add((1, offset));
        for (int i = 1; i <= m + 1; i++)
        {
            list.Add((i * 3, i * 3 + 1));
        }
        for (int i = m + 2; i <= n - 1; i++)
        {
            list.Add((offset + i * 3, offset + i * 3 + 1));
        }

        if (list.Count != n) throw new Exception();

        Console.WriteLine(string.Join("\n", list.Select(x => $"{x.Item1} {x.Item2}")));
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