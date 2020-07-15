// detail: https://atcoder.jp/contests/tenka1-2014-qualb/submissions/15257560
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
    static int n;
    static (int, int)[] decode;
    static char[][] board;
    static Random masterRNG = new Random(1);
    static List<int>[] graph;
    public static void Main()
    {
        n = int.Parse(Console.ReadLine());
        board = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().ToArray()).ToArray();

        if (n == 1)
        {
            Console.WriteLine('#');
            return;
        }

        graph = Enumerable.Repeat(0, n * n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n; j++)
            { var id = i * n + j; graph[id].Add(id + n); graph[id + n].Add(id); }
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n - 1; j++)
            { var id = i * n + j; graph[id].Add(id + 1); graph[id + 1].Add(id); }
        decode = new (int, int)[n * n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                decode[i * n + j] = (i, j);

        while (true)
        {
            try
            {
                var res = Solve();
                Debug.WriteLine(attempt);
                Console.WriteLine(string.Join("\n", res.Select(x => string.Join("", x))));
                break;
            }
            catch { }
        }
    }
    static int attempt = 0;
    static char[][] Solve()
    {
        attempt++;
        Random rng = new Random(masterRNG.ULong);
        var prevBoard = Enumerable.Repeat(0, n).Select(_ => new char[n]).ToArray();

        for (int i = 0; i < n * n; i++)
        {
            var (cy, cx) = decode[i];

            int parity = 0;
            int lastNum = -1;
            foreach (var adj in graph[i])
            {
                var (y, x) = decode[adj];
                switch (prevBoard[y][x])
                {
                    case '#':
                        parity ^= 1;
                        break;
                    case '.':
                        //pass
                        break;
                    default:
                        var next = rng.Next() & 1;
                        prevBoard[y][x] = next == 1 ? '#' : '.';
                        parity ^= next;
                        lastNum = adj;
                        break;
                }
            }
            var idealParity = board[cy][cx] == '#' ? 1 : 0;
            if (idealParity != parity)
            {
                if (lastNum == -1) throw new Exception();
                var (ly, lx) = decode[lastNum];
                prevBoard[ly][lx] = (char)(prevBoard[ly][lx] ^('#' ^ '.'));
            }
        }
        return prevBoard;
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
