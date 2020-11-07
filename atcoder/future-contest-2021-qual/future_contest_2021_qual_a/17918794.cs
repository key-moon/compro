// detail: https://atcoder.jp/contests/future-contest-2021-qual/submissions/17918794
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

class Solver
{
    DateTime StartAt;
    Random RNG;
    Board Board;
    public int Type;
    public Solver(ulong seed, int type)
    {
        StartAt = DateTime.Now;
        RNG = new Random(seed);
        Type = type;
    }
    public string Solve(Board board)
    {
        Board = board;
        switch (Type)
        {
            case 0:
                return Stupid();
            case 1:
                return GatherUp();
            default:
                throw new Exception();
        }
    }
    public string Stupid(int cury = 0, int curx = 0)
    {
        var res = Enumerable.Empty<char>();
        for (int i = 1; i <= Const.N; i++)
        {
            var (y, x) = Board[i];
            res = res.Concat(GetMove((cury, curx), (y, x)));
            res = res.Append('I');
            (cury, curx) = (y, x);
        }
        return string.Join("", res);
    }

    public string GatherUp()
    {
        var res = Enumerable.Empty<char>();
        
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < Const.H; i++)
        {
            if (i != 0) res = res.Append('D');

            int begin, end, d; char c;
            if (i % 2 == 0) (begin, end, d, c) = (0, Const.W, 1, 'R');
            else (begin, end, d, c) = (Const.W - 1, -1, -1, 'L');
            for (int j = begin; j != end; j += d)
            {
                if (j != begin) res = res.Append(c);
                if (Board[i, j] != 0)
                {
                    res = res.Append('I');
                    stack.Push(Board[i, j]);
                    Board[i, j] = 0;
                }
            }
        }

        var w = 10;
        var h = 10;
        for (int i = Const.H - 1; i >= Const.H - h; i--)
        {
            if (i != Const.H - 1) res = res.Append('U');

            int begin, end, d; char c;
            if (i % 2 != 0) (begin, end, d, c) = (Const.W - w, Const.W, 1, 'R');
            else (begin, end, d, c) = (Const.W - 1, Const.W - w - 1, -1, 'L');
            for (int j = begin; j != end; j += d)
            {
                if (j != begin) res = res.Append(c);
                res = res.Append('O');
                Board[i, j] = stack.Pop();
            }
        }

        res = res.Concat(Stupid(Const.H - h, Const.W - w));
        return string.Join("", res);
    }

    IEnumerable<char> GetMove((int y, int x) prev, (int y, int x) after)
    {
        var res = Enumerable.Empty<char>();
        if (prev.y > after.y) res = res.Concat(Enumerable.Repeat('U', prev.y - after.y));
        if (prev.y < after.y) res = res.Concat(Enumerable.Repeat('D', after.y - prev.y));

        if (prev.x > after.x) res = res.Concat(Enumerable.Repeat('L', prev.x - after.x));
        if (prev.x < after.x) res = res.Concat(Enumerable.Repeat('R', after.x - prev.x));
        return res;
    }
}

static class Const
{
    public const int N = 100;
    public const int H = 20;
    public const int W = 20;
}

static class Util
{
    public static int CalcScore(string res) => 4000 - res.Count(x => x != 'I' && x != 'O');
    public static Board GenRandCase(ulong seed)
    {
        var rng = new Random(seed);
        var board = new Board();
        for (int i = 1; i <= Const.N; i++)
        {
            int y, x;
            do
            {
                (y, x) = (rng.Next() % Const.H, rng.Next() % Const.W);
            } while (board[y, x] != 0);
            board[y, x] = i;
        }
        return board;
    }
    public static string GenRandCaseInput(ulong seed)
    {
        var rng = new Random(seed);
        var board = new Board();
        StringBuilder builder = new StringBuilder();
        for (int i = 1; i <= Const.N; i++)
        {
            int y, x;
            do
            {
                (y, x) = (rng.Next() % Const.H, rng.Next() % Const.W);
            } while (board[y, x] != 0);
            board[y, x] = i;
            builder.AppendLine($"{y} {x}");
        }
        return builder.ToString();
    }
}

class Board
{
    int[] Data = new int[Const.H * Const.W];
    public (int y, int x)[] Indexes = new (int y, int x)[Const.N + 1];
    public Board() { Array.Fill(Data, 0); }
    public Board(TextReader reader) : this()
    {
        for (int i = 1; i <= Const.N; i++)
        {
            var xy = reader.ReadLine().Split().Select(int.Parse).ToArray();
            var (x, y) = (xy[0], xy[1]);
            this[x, y] = i;
        }
    }
    public int this[int y, int x]
    {
        get { return Data[y * Const.H + x]; }
        set { Data[y * Const.H + x] = value; Indexes[value] = (y, x); }
    }
    public (int y, int x) this[int num]
    {
        get { return Indexes[num]; }
    }
}

public static class P
{
    public static void Main()
    {
        var solver = new Solver(58, 1);
        //Bench(solver, doDump: true);
        //return;

        Board board = new Board(Console.In);
        var res = solver.Solve(board);
        Console.WriteLine(res);
    }
    static void Bench(Solver solver, uint max = 100, bool doDump = false)
    {
        double score = 0;
        for (uint i = 1; i <= max; i++)
        {
            var board = Util.GenRandCase(i);
            var res = solver.Solve(board);
            score += Util.CalcScore(res);
            if (doDump)
            {
                var dir = @$"C:\Users\{Environment.UserName}\Desktop\out\{i}";
                Directory.CreateDirectory(dir);
                File.WriteAllText(@$"{dir}\in", Util.GenRandCaseInput(i));
                File.WriteAllText(@$"{dir}\out", res);
            }
        }
        Console.WriteLine($@"
     type: {solver.Type}
     step: {4000 - score / max}
    score: {score / max}
est-score: {score / max * 50}");
    }
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