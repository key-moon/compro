// detail: https://atcoder.jp/contests/agc056/submissions/27693434
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
        /*for (int i = 6; i < 500; i++)
        {
            Solve(i);
        }*/
        int n = int.Parse(Console.ReadLine());
        var res = Solve(n);

        Console.WriteLine(string.Join("\n", res.Select(x => string.Join("", x))));
    }
    static char[][] Solve(int n)
    {
        var board6 = @"
###...
...###
###...
...###
###...
...###".Trim().Split('\n');
        var board7 = @"
.##...#
#....##
#.##...
..#.##.
...#.##
.#.##..
##..#..".Trim().Split('\n');
        var board8 = @"
.##....#
##.#....
#..##...
.##..#..
..#..##.
...##..#
....#.##
#....##.".Trim().Split('\n');
        var board9 = @"
###......
...###...
......###
###......
...###...
......###
###......
...###...
......###".Trim().Split('\n');
        var board10 = @"
.##.#.....
#....##...
#.##......
..#..##...
#....##...
.#.##.....
.#.##.....
.......###
.......###
.......###".Trim().Split('\n');
        var board11 = @"
.#.......##
#.##.......
.##.#......
.#..##.....
..##..#....
...#..##...
....##..#..
.....#.##..
......###..
#........##
#........##".Trim().Split('\n');
        var boards = new Dictionary<int, string[]>
        {
            { 6, board6 },
            { 7, board7 },
            { 8, board8 },
            { 9, board9 },
            { 10, board10 },
            { 11, board11 },
        };
        char[][] res = Enumerable.Repeat(0, n).Select(_ => Enumerable.Repeat('.', n).ToArray()).ToArray();
        {
            int i = 0;
            for (; 12 <= n - i; i += 6)
            {
                for (int j = 0; j < 6; j++)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        res[i + j][i + k] = board6[j][k];
                    }
                }
            }
            var remain = n - i;
            for (int j = 0; j < remain; j++)
            {
                for (int k = 0; k < remain; k++)
                {
                    res[i + j][i + k] = boards[remain][j][k];
                }
            }
        }
        UnionFind uf = new UnionFind(n * n);
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n; j++)
            {
                var id = i * n + j;
                if (res[i][j] == '#' && res[i + 1][j] == '#') { uf.TryUnite(id, id + n); }
            }
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n - 1; j++)
            { var id = i * n + j; if (res[i][j] == '#' && res[i][j + 1] == '#') uf.TryUnite(id, id + 1); }
        for (int i = 0; i < n; i++)
        {
            Trace.Assert(res[i].Count(x => x == '#') == 3);
            Trace.Assert(res.Count(x => x[i] == '#') == 3);
        }
        var reps = uf.AllRepresents.ToArray();
        var cnt = uf.AllRepresents.Count(x => res[x / n][x % n] == '#');
        Trace.Assert(cnt == n);
        return res;
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
