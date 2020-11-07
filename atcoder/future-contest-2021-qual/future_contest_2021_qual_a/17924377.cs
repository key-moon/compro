// detail: https://atcoder.jp/contests/future-contest-2021-qual/submissions/17924377
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
        Reset();
        RNG = new Random(seed);
        Type = type;
    }
    public void Reset()
    {
        StartAt = DateTime.Now;
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
            case 2:
                return Div4AndHilbert();
            case 3:
                return AnnealOnHilbert();
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

    public string Div4AndHilbert()
    {
        var res = Enumerable.Empty<char>();
        Stack<int> stack = new Stack<int>();
        var (cury, curx) = (0, 0);
        void Gather(int basey, int basex, int parity)
        {
            //距離:ヒルベルト上での距離と

            List<(int, (int, int))> l = new List<(int, (int, int))>();
            for (int i = basey; i < basey + Const.H / 2; i++)
            {
                for (int j = basex; j < basex + Const.W / 2; j++)
                {
                    if (Board[i, j] == 0) continue;
                    l.Add((Board[i, j], (i, j)));
                }
            }
            l = l.OrderBy(x => x.Item1 * parity).ToList();
            foreach (var (num, (y, x)) in l)
            {
                res = res.Concat(GetMove((cury, curx), (y, x)));
                res = res.Append('I');
                stack.Push(num);
                (cury, curx) = (y, x);
            }
        }
        Gather(0, 0, 1);
        Gather(Const.H / 2, 0, -1);
        Gather(Const.H / 2, Const.W / 2, 1);
        Gather(0, Const.W / 2, -1);

        var curve = Util.Curve.Select(x => (x.Item1 + Const.H / 4, x.Item2 + Const.W / 4)).ToArray();
        while (stack.Count != 0)
        {
            var elem = stack.Pop();
            var (y, x) = curve[elem - 1];
            res = res.Concat(GetMove((cury, curx), (y, x)));
            res = res.Append('O');
            (cury, curx) = (y, x);
        }

        foreach (var (y, x) in curve)
        {
            res = res.Concat(GetMove((cury, curx), (y, x)));
            res = res.Append('I');
            (cury, curx) = (y, x);
        }

        return string.Join("", res);
    }

    public string AnnealOnHilbert()
    {
        const int len = Const.N + 2;
        int[] distance = new int[len * len];
        var curve = Util.Curve.Select(x => (x.Item1 + Const.H / 4, x.Item2 + Const.W / 4)).ToArray();
        for (int i = 1; i <= Const.N; i++)
        {
            var (iby, ibx) = Board[i];
            var (icy, icx) = curve[i - 1];
            for (int j = 1; j <= Const.N; j++)
            {
                var (jby, jbx) = Board[j];
                var (jcy, jcx) = curve[j - 1];
                var dist = Abs(iby - jby) + Abs(ibx - jbx) + Abs(icy - jcy) + Abs(icx - jcx);
                distance[i * len + j] = dist;
            }
        }
        for (int i = 1; i <= Const.N; i++)
        {
            var (iby, ibx) = Board[i];
            var (icy, icx) = curve[i - 1];
            var (zcy, zcx) = curve[0];
            //原点からの距離/一番最初に取るものから0への距離が必要
            distance[0 * len + i] = iby + ibx + Abs(zcy - icy) + Abs(zcx - icx);
            distance[i * len + (len - 1)] = Abs(iby - icy) + Abs(ibx - icx);
        }

        //0がスタート、n+2がゴール
        int[] cur = Enumerable.Range(0, len).ToArray();
        int curCost = 0;
        for (int i = 0; i < cur.Length - 1; i++)
        {
            curCost += distance[cur[i] * len + cur[i + 1]];
        }
        curCost += 100 - 1;
        
        int[] minRes = cur.ToArray();
        int minCost = curCost;

        #region Anneal
#if TRUE
        const double startTemp = 17.4;
        const double endTemp = 0.1;

        int cnt = 0;
        double temp = 0;

        while (true)
        {
            if ((cnt & 1024) == 0)
            {
                var progress = (double)(DateTime.Now - StartAt).TotalSeconds / Const.TL;
                temp = startTemp + (endTemp - startTemp) * progress;
                if (0.975 <= progress) break;
            }
            cnt++;

            int a = RNG.Next() % Const.N, b;
            do { b = RNG.Next() % Const.N; } while (b == a);
            // a < b
            if (a > b) (a, b) = (b, a);
            a++; b++;

            int prevaval = cur[a - 1], aval = cur[a], bval = cur[b], aftbval = cur[b + 1];

            var curdist = distance[cur[a - 1] * len + cur[a]] + distance[cur[b] * len + cur[b + 1]];
            var nxtdist = distance[cur[a - 1] * len + cur[b]] + distance[cur[a] * len + cur[b + 1]];
            //curdistの方が大きいと嬉しいよ 大きいと正になるのはcurdist - nxtdist
            var prob = Exp((curdist - nxtdist) / temp);
            if (prob * uint.MaxValue > RNG.UInt)
            //if (curdist > nxtdist) //山登り
            {
                Array.Reverse(cur, a, b - a + 1);
                curCost = curCost - curdist + nxtdist;
                #region assert
#if FALSE
                Trace.Assert(cur[a - 1] == prevaval);
                Trace.Assert(cur[a] == bval);
                Trace.Assert(cur[b] == aval);
                Trace.Assert(cur[b + 1] == aftbval);
                int _cost = 0;
                {
                    for (int i = 0; i < cur.Length - 1; i++)
                    {
                        _cost += distance[cur[i] * len + cur[i + 1]];
                    }
                }
                _cost += 100 - 1;
                Trace.Assert(_cost == curCost);
#endif
                #endregion

                if (curCost < minCost)
                {
                    Array.Copy(cur, minRes, cur.Length);
                    minCost = curCost;
                }
            }
        }
#endif
#endregion

        var res = Enumerable.Empty<char>();
        var stack = new Stack<int>();
        var (cury, curx) = (0, 0);
        for (int i = 1; i <= Const.N; i++)
        {
            var (y, x) = Board[minRes[i]];
            res = res.Concat(GetMove((cury, curx), (y, x)));
            res = res.Append('I');
            stack.Push(minRes[i]);
            (cury, curx) = (y, x);
        }
        while (stack.Count != 0)
        {
            var elem = stack.Pop();
            var (y, x) = curve[elem - 1];
            res = res.Concat(GetMove((cury, curx), (y, x)));
            res = res.Append('O');
            (cury, curx) = (y, x);
        }
        foreach (var (y, x) in curve)
        {
            res = res.Concat(GetMove((cury, curx), (y, x)));
            res = res.Append('I');
            (cury, curx) = (y, x);
        }
        var resstr = string.Join("", res);
        //Console.WriteLine(curCost);
        //Console.WriteLine(Util.CalcDist(resstr));
        return resstr;
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
    public const long TickPerSec = 10000000;
    public const long TLTick = 3 * TickPerSec;
    public const long TL = 3;
}


static class Util
{
    public static (int, int)[] Curve = GenCurve(); 
    const string baseCurve =
@"
adehi
bcfgj
utslk
vwrmn
yxqpo";
    public static (int, int)[] GenCurve()
    {
        var grid = baseCurve.Trim().Split('\n');
        (int, int)[] curve = new (int, int)[25];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                curve[grid[i][j] - 'a'] = (i, j);
            }
        }
        var res = curve.Concat(curve.Select(x =>
        {
            var (i, j) = x;
            return (j + 5, i);
        })).Concat(curve.Select(x =>
        {
            var (i, j) = x;
            return (j + 5, i + 5);
        })).Concat(curve.Select(x =>
        {
            var (i, j) = x;
            return (4 - i, 10 - 1 - j);
        })).ToArray();
        return res;
    }

    public static int CalcDist(string res) => res.Count(x => x != 'I' && x != 'O');
    public static int CalcScore(string res) => 4000 - CalcDist(res);
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
        var solver = new Solver(58, 3);
#if DEBUG
        Bench(solver, max: 3, doDump: true);
        //Bench(solver, max: 100, doDump: false);
#endif

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
            solver.Reset();
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