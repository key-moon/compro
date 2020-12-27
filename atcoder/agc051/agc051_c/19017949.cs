// detail: https://atcoder.jp/contests/agc051/submissions/19017949
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

public static class P
{
    public static void Main()
    {
        //Test(0, size: 8, shuffle: 20);
        //Test(1, size: 8, shuffle: 20);
        //Test(2, size: 8, shuffle: 20);
        //Test(3, size: 8, shuffle: 1);
        //Console.WriteLine("end");
        int n = int.Parse(Console.ReadLine());
        var xy = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var pts = xy.Select(x => new Point() { X = x[0], Y = x[1] }).ToArray();

        Console.WriteLine(Solve(pts)); 
    }

    static void Test(int res, int cnt = 1000, int size = 10, int shuffle = 100)
    {
        Random rng = new Random(1);
        int h = size;
        int w = size;
        for (int i = 0; i < cnt; i++)
        {
            bool[][] board = Enumerable.Repeat(0, h).Select(_ => new bool[w]).ToArray();
            for (int j = 0; j < res; j++)
            {
                int y, x;
                do
                {
                    y = rng.Next() % h;
                    x = rng.Next() % w;
                } while (board[y][x]);
                board[y][x] = true;
            }

            for (int j = 0; j < shuffle; j++)
            {
                var y = rng.Next() % (h - 3 + 1);
                var x = rng.Next() % (w - 2 + 1);
                for (int k = 0; k < 3; k++)
                    for (int l = 0; l < 2; l++)
                        board[y + k][x + l] ^= true;
            }

            List<Point> pts = new List<Point>();
            for (int a = 0; a < h; a++)
            {
                for (int b = 0; b < w; b++)
                {
                    if (board[a][b]) pts.Add(new Point() { Y = a, X = b });
                }
            }
            var hoge = Solve(pts.ToArray());
            if (hoge != res)
            {
                Console.WriteLine($"{res} -> {hoge}");
                Console.WriteLine(string.Join("\n", board.Select(x => string.Join("", x.Select(y => y ? "#" : ".")))));
                Solve(pts.ToArray());
            }
        }
    }

    static int Solve(Point[] pts)
    {
        List<int>[] yCnts = new List<int>[3] { new List<int>(), new List<int>(), new List<int>() };

        foreach (var group in pts.GroupBy(x => x.Y))
        {
            var gid = group.Key % 3;
            yCnts[gid].Add(group.Count());
        }

        List<int[]> xCnts = new List<int[]>();
        foreach (var group in pts.GroupBy(x => x.X))
        {
            int[] cnts = new int[3];
            foreach (var item in group) cnts[item.Y % 3]++;
            xCnts.Add(cnts);
        }

        var yCntsSum = yCnts.Select(x => x.Sum(y => y % 2)).ToArray();

        int[] xEachGroupSum = new int[3];
        int[] groupKindCnts = new int[4];
        foreach (var xCnt in xCnts)
        {
            var arr = xCnt.Select(x => x % 2).ToArray();
            if (2 <= arr.Sum()) arr = arr.Select(x => x ^ 1).ToArray();
            var groupKind = 3;
            if (arr.Contains(1)) groupKind = Array.IndexOf(arr, 1);
            groupKindCnts[groupKind]++;
            if (groupKind < 3) xEachGroupSum[groupKind]++;
        }

        var diff = yCntsSum.Zip(xEachGroupSum, (x, y) => (x ^ y) & 1).ToArray();
        // Diff should [0, 0, 0] or [1, 1, 1]
        if (diff.Distinct().Count() != 1) throw new Exception();
        var shouldChange = diff.First() == 1;

        bool Change()
        {
            var curdiff = xEachGroupSum.Zip(yCntsSum, (x, y) => x - y).ToArray();

            int[] profits = new int[4];
            for (int i = 0; i < 4; i++)
            {
                if (groupKindCnts[i] == 0) profits[i] = int.MinValue;
                else profits[i] = curdiff.Select((elem, ind) => Max(0, elem) - Max(0, ind == i ? elem - 1 : elem + 1)).Sum();
            }

            var maxProfit = profits.Max();
            if (maxProfit == int.MinValue) return false;
            var changeInd = Array.IndexOf(profits, maxProfit);

            groupKindCnts[changeInd]--;
            for (int i = 0; i < xEachGroupSum.Length; i++)
            {
                if (i == changeInd) xEachGroupSum[i]--;
                else xEachGroupSum[i]++;
            }
            return true;
        }
        int GetScore() => xEachGroupSum.Zip(yCntsSum, Max).Sum();
        if (shouldChange) if (!Change()) throw new Exception();
        while (true)
        {
            var prevScore = GetScore();
            var backup = xEachGroupSum.ToArray();
            if (Change() && Change() && GetScore() < prevScore) continue;
            else
            {
                xEachGroupSum = backup;
                break;
            }
        }
        return GetScore();
    }
}

struct Point
{
    public long Y;
    public long X;
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

    public byte Byte { get { Update(); return __byte; } }
    public sbyte SByte { get { Update(); return __sbyte; } }
    public char Char { get { Update(); return __char; } }
    public short Short { get { Update(); return __short; } }
    public ushort UShort { get { Update(); return __ushort; } }
    public int Int { get { Update(); return __int; } }
    public uint UInt { get { Update(); return __uint; } }
    public long Long { get { Update(); return __long; } }
    public ulong ULong { get { Update(); return __ulong; } }
    public double Double { get { return (double)ULong / ulong.MaxValue; } }

    [FieldOffset(0)]
    private ulong _xorshift;

    public Random() : this((ulong)DateTime.Now.Ticks) { }
    public Random(ulong seed) { SetSeed(seed); }
    public void SetSeed(ulong seed) => _xorshift = seed * 0x3141592c0ffeeul;

    public int Next() => Int & 2147483647;
    public void Update()
    {
        _xorshift ^= _xorshift << 7;
        _xorshift ^= _xorshift >> 9;
    }
}
