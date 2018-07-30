// detail: https://codeforces.com/contest/1013/submission/40962063
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nmq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = nmq[0];
        int m = nmq[1];
        int q = nmq[2];
        //縦列1つ埋めちゃえば後は適当にばーってできる
        //1つの行に纏めたい(それが最小になる保証は?)
        //行に落とせる条件は?
        //　落とすところと同列のものが存在
        //　落とす行に同列の別のものが存在
        //つまり、1つ落とせれば全部落とせる
        //むっちゃUFで繋げそう
        //UFでつないで、その繋がった中全部のを出す
        //足りない列は購入
        //足りない行は購入
        //1つ落とせる判定を高速にしたいんですが どうですか先輩
        //その列が存在する行番号を纏めたい
        //別の行をつないでメリットがあるかどうか高速に知りたいみたいなところはあって、
        //実は全行が独立とかいうクソケースだったら全探索しないと駄目になって死ぬので
        //あーでも他のそれがメリットありありで繋いでたら一番でかいの抜いたとかある? => ないんだな

        //[{r1,c1},{r2,c2},{r3,c3}];
        int[][] elements = Enumerable.Repeat(0, q).Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray()).ToArray();
        //rでつなげられるところをつなげたUF
        UnionFind ufn = new UnionFind(n);
        //そのrに存在しているcまとめ
        List<int>[] ns = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        
        //cでつなげられるところをつなげたUF
        UnionFind ufm = new UnionFind(m);
        //そのcに存在しているrまとめ
        List<int>[] ms = Enumerable.Repeat(0, m).Select(_ => new List<int>()).ToArray();
        foreach (var element in elements)
        {
            if (ms[element[1]].Count >= 1) ufn.Union(ms[element[1]][0], element[0]);
            if (ns[element[0]].Count >= 1) ufm.Union(ns[element[0]][0], element[1]);

            ns[element[0]].Add(element[1]);
            ms[element[1]].Add(element[0]);
        }

        int misn = ns.Count(x => x.Count == 0);
        int mism = ms.Count(x => x.Count == 0);

        //ここで縦/横に纏められる部分が全部揃ったUFが完成
        //各UF内には重複要素は存在しないので、UFの要素全部まとめてもOK
        //全部併合してよくて、併合した後にあまりを2つ買うよ～
        int nparents = ufn.AllParents().Distinct().Count();
        int mparents = ufm.AllParents().Distinct().Count();

        int res = n + m - 1;
        if (n != 1)
        {
            res = Min(res, mparents - 1 + misn);
        }
        if (m != 1)
        {
            res = Min(res, nparents - 1 + mism);
        }
        if (n == 1 && m == 1)
        {
            res = 1 - q;
        }

        Console.WriteLine(res);
    }
}

class UnionFind
{
    int[] data;
    public UnionFind(int count)
    {
        data = Enumerable.Range(0, count).ToArray();
    }
    public void Union(int x, int y)
    {
        int xp = Parent(x);
        int yp = Parent(y);
        if (xp != yp)
        {
            data[yp] = xp;
        }
    }
    public bool IsSameGroup(int x, int y) => Parent(x) == Parent(y);
    public int[] AllParents() => data.Where((x, y) => x == y).ToArray();
    public int Parent(int x)
    {
        form(x);
        return data[x];
    }
    private void form(int x)
    {
        while (data[x] != data[data[x]])
        {
            data[x] = data[data[x]];
        }
    }
}