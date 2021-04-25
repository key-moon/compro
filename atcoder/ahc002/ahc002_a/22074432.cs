// detail: https://atcoder.jp/contests/ahc002/submissions/22074432
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    public const int H = 50;
    public const int W = 50;

    public const int BEAM_WIDTH_MAX = 100;
    public const int BEAM_WIDTH_INIT = 1;
    public const double BEAM_WIDTH_RATIO = 3;
    public const int STEP = 3;
    public const int CNT = 3;
    public const int SCORE_CNT = 1;

    public const int SNAP = 7;
    public const int ATTEMPT = 4;

    public readonly static Random rng = new Random(357);
    public readonly static int[] Score = new int[H * W];
    public readonly static Array2D<int> AdjCell = new Array2D<int>(H * W, 4 + 1);
    public readonly static Array2D<int> AdjGroup = new Array2D<int>(H * W, 6 + 1);
    public readonly static int[] Group = new int[H * W];

    public readonly static int[] AdjCellLen = new int[H * W];
    public readonly static int[] AdjGroupLen = new int[H * W];
    public static void Main()
    {
        DateTime begin = DateTime.Now;
        var sij = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var si = sij[0];
        var sj = sij[1];
        var spos = si * W + sj;
        var ids = Enumerable.Repeat(0, 50).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var scores = Enumerable.Repeat(0, 50).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        for (int i = 0; i < H; i++)
            for (int j = 0; j < W; j++)
                Score[i * W + j] = scores[i][j];
        Array.Fill(AdjCell.Data, -1);
        Array.Fill(AdjGroup.Data, -1);
        Array.Fill(Group, -1);

        for (int i = 0; i < H - 1; i++)
            for (int j = 0; j < W; j++)
            {
                var id1 = i * W + j;
                var id2 = (i + 1) * W + j;
                if (ids[i][j] == ids[i + 1][j])
                {
                    Group[id1] = id2;
                    Group[id2] = id1;
                }
                AdjCell[id1, AdjCellLen[id1]++] = id2;
                AdjCell[id2, AdjCellLen[id2]++] = id1;
            }
        for (int i = 0; i < H; i++)
            for (int j = 0; j < W - 1; j++)
            {
                var id1 = i * W + j;
                var id2 = i * W + j + 1;
                if (ids[i][j] == ids[i][j + 1])
                {
                    Group[id1] = id2;
                    Group[id2] = id1;
                }
                AdjCell[id1, AdjCellLen[id1]++] = id2;
                AdjCell[id2, AdjCellLen[id2]++] = id1;
            }

        for (int i = 0; i < H * W; i++)
        {
            int cind;
            cind = 0;
            while (AdjCell[i, cind] != -1)
            {
                AdjGroup[i, AdjGroupLen[i]++] = AdjCell[i, cind];
                cind++;
            }
            if (Group[i] == -1) continue;
            cind = 0;
            while (AdjCell[Group[i], cind] != -1)
            {
                AdjGroup[Group[i], AdjGroupLen[i]++] = AdjCell[i, cind];
                cind++;
            }
        }

        State maxState = new State();
        while (true)
        {
            var beamWidth = BEAM_WIDTH_INIT;
            State[] currentStates = new State[] { new State(spos) };
            int failed = 0;
            int maxScore = 0;
            while (failed <= 3)
            {
                currentStates =
                    currentStates
                    .SelectMany(x => x.NextState())
                    .OrderByDescending(x => x.CalcScore())
                    .Take(beamWidth)
                    .ToArray();
                var nxtMaxScore = currentStates.Max(x => x.Score);
                if (maxScore == nxtMaxScore) failed++;
                else failed = 0;
                maxScore = nxtMaxScore;
                beamWidth = Min((int)(beamWidth * BEAM_WIDTH_RATIO), BEAM_WIDTH_MAX);
                if (1900 <= (DateTime.Now - begin).TotalMilliseconds)
                {
                    goto end;
                }
            }
            var resState = currentStates.First();
            if (maxState.Score < resState.Score)
            {
                maxState = resState;
            }
        }

        end:;
        Console.Error.WriteLine(maxState.Score);
        Console.WriteLine(maxState.Moves);
    }
    static bool RandomMove(this State state)
    {
        var pos = state.Pos;
        var ind = rng.Next() & 3;
        switch (AdjCellLen[pos])
        {
            case 0:
                return false;
            case 1:
                ind = 0;
                break;
            case 2:
                ind &= 1;
                break;
            case 3:
                if (ind == 3) ind = rng.Next() % 3;
                break;
        }
        if (state.Bitarr[AdjCell[pos, ind]]) return false;
        state.MoveTo(AdjCell[pos, ind]);
        return true;
    }
    static IEnumerable<State> NextState(this State state)
    {
        for (int i = 0; i < CNT; i++)
        {
            var tmpState = new State(state);
            for (int j = 0; j < STEP; j++) tmpState.RandomMove();
            yield return tmpState;
        }
    }
    static int CalcScore(this State state)
    {
        int score = 0;
        for (int i = 0; i < SCORE_CNT; i++)
        {
            var tmpState = new State(state);
            State snap = new State(tmpState);
            int cnt = 0;
            int failed = 0;
            while (failed <= ATTEMPT)
            {
                if (!tmpState.RandomMove())
                {
                    tmpState = new State(snap);
                    failed++;
                }
                if ((cnt++ % SNAP) == 0)
                {
                    snap = new State(tmpState);
                    failed = 0;
                }
            }
            score = Max(score, tmpState.Score);
        }
        return score;
    }
}

public class State
{
    public BitArray Bitarr;
    public int Score;
    ImmutableStack<int> PosHistory;
    public int Pos => PosHistory.Peek();
    public string Moves
    {
        get
        {
            List<char> l = new List<char>();
            var history = PosHistory;
            var nxt = history.Peek(); history = history.Pop();
            while (!history.IsEmpty)
            {
                var cur = history.Peek();
                var d = nxt - cur;
                l.Add(d switch { 1 => 'R', -1 => 'L', P.H => 'D', -P.H => 'U' });
                nxt = cur;
                history = history.Pop();
            }
            l.Reverse();
            return string.Concat(l);
        }
    }
    public State(State state)
    {
        Bitarr = new BitArray(state.Bitarr);
        Score = state.Score;
        PosHistory = state.PosHistory;
    }
    public State()
    {
        Bitarr = new BitArray(50 * 50);
        PosHistory = ImmutableStack<int>.Empty;
    }
    public State(int pos) : this()
    {
        MoveTo(pos);
    }
    public void MoveTo(int pos)
    {
        Debug.Assert(!Bitarr[pos]);
        PosHistory = PosHistory.Push(pos);
        Score += P.Score[pos];
        var group = P.Group[pos];
        if (group != -1) Bitarr[group] = true;
        Bitarr[pos] = true;
    }
}

public class Array2D<T> : IEnumerable<T>
{
    public int Width;
    public int Height;
    public T[] Data;
    public T this[int i, int j]
    {
        get => Data[i * Width + j];
        set => Data[i * Width + j] = value;
    }
    public Array2D(int h, int w)
    {
        Height = h;
        Width = w;
        Data = new T[w * h];
    }
    public Array2D(Array2D<T> data) : this(data.Width, data.Height)
    {
        Array.Copy(data.Data, Data, Data.Length);
    }

    public IEnumerator<T> GetEnumerator() => Data.AsEnumerable().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => Data.GetEnumerator();
}

public class SmallBitArray2D
{
    ulong[] Data;
    public bool this[int i, int j]
    {
        get => (Data[i] >> j & 1) == 1;
        set
        {
            if (value) Data[i] |= 1UL << j;
            else Data[i] &= ~(1UL << j);
        }
    }
    public SmallBitArray2D(int h, int w)
    {
        if (64 < w) throw new Exception();
        Data = new ulong[h];
    }
}


[StructLayout(LayoutKind.Explicit)]
public class Random
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
