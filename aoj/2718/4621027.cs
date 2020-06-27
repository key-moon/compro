// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2718/judge/4621027/C#
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

public static class P
{
    static int N;
    static Cell[] Cells;
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        N = n;
        Dictionary<int, List<Tuple<int, int>>> yDict = new Dictionary<int, List<Tuple<int, int>>>();
        Dictionary<int, List<Tuple<int, int>>> xDict = new Dictionary<int, List<Tuple<int, int>>>();
        Cell[] cells = Enumerable.Repeat(new Cell() { DownInd = -1, LeftInd = -1, RightInd = -1, UpInd = -1 }, n).ToArray();
        for (int i = 0; i < n; i++)
        {
            var xyd = Console.ReadLine().Split();
            var x = int.Parse(xyd[1]);
            var y = int.Parse(xyd[0]);
            var dir = xyd[2] == "^" ? 0 : xyd[2] == ">" ? 1 : xyd[2] == "v" ? 2 : 3;
            cells[i].Dir = dir;
            if (!yDict.ContainsKey(y)) yDict.Add(y, new List<Tuple<int, int>>());
            if (!xDict.ContainsKey(x)) xDict.Add(x, new List<Tuple<int, int>>());
            yDict[y].Add(new Tuple<int, int>(x, i));
            xDict[x].Add(new Tuple<int, int>(y, i));
        }
        foreach (var key in xDict.Keys)
        {
            var val = xDict[key];
            val.Sort();
            for (int i = 0; i < val.Count - 1; i++)
            {
                cells[val[i].Item2].RightInd = val[i + 1].Item2;
                cells[val[i + 1].Item2].LeftInd = val[i].Item2;
            }
        }
        foreach (var key in yDict.Keys)
        {
            var val = yDict[key];
            val.Sort();
            for (int i = 0; i < val.Count - 1; i++)
            {
                cells[val[i].Item2].DownInd = val[i + 1].Item2;
                cells[val[i + 1].Item2].UpInd = val[i].Item2;
            }
        }
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            Cells = cells.ToArray();
            res = Max(res, Simulate(i));
        }
        Console.WriteLine(res);
    }
    static void Remove(int ind)
    {
        var u = Cells[ind].UpInd;
        var d = Cells[ind].DownInd;
        var l = Cells[ind].LeftInd;
        var r = Cells[ind].RightInd;
        if (u != -1) Cells[u].DownInd = d;
        if (d != -1) Cells[d].UpInd = u;
        if (l != -1) Cells[l].RightInd = r;
        if (r != -1) Cells[r].LeftInd = l;
        Cells[ind] = new Cell() { Dir = -1 };
    }
    static int Simulate(int startInd)
    {
        int res = 0;
        var curCellInd = startInd;
        //List<int> path = new List<int>();
        while (true)
        {
            if (curCellInd == -1) break;
            //path.Add(curCellInd);
            int next;
            switch (Cells[curCellInd].Dir)
            {
                case 0:
                    next = Cells[curCellInd].UpInd;
                    break;
                case 1:
                    next = Cells[curCellInd].RightInd;
                    break;
                case 2:
                    next = Cells[curCellInd].DownInd;
                    break;
                case 3:
                    next = Cells[curCellInd].LeftInd;
                    break;
                default:
                    throw new Exception();
            }
            Remove(curCellInd);
            curCellInd = next;
            res++;
        }
        //Console.WriteLine($"begin at {startInd}:\n{string.Join("->", path)}");
        return res;
    }
}

struct Cell
{
    public int UpInd;
    public int DownInd;
    public int LeftInd;
    public int RightInd;
    public int Dir;
}

