// detail: https://atcoder.jp/contests/rcl-contest-2020-qual/submissions/10106846
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static System.Math;
using keymoon.Marathon.Heuristic;
using keymoon.Marathon.Util;
using static Const;
using System.IO;
using static Reader;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static partial class Const
{
    public static DateTime StartTime;
    static Const()
    {
        StartTime = DateTime.Now;
    }
    public static MyRandom RNG = new MyRandom();
}

public static class P
{
    static int n;
    static int w;
    static int k;
    static int v;
    static Mino[] Minos;
    public static void Main()
    {
        n = NextInt;
        w = NextInt;
        k = NextInt;
        v = NextInt;
        Minos = Enumerable.Repeat(0, n).Select(_ => new Mino() { Color = NextInt, Value = NextInt }).ToArray();
        placableRow = Enumerable.Repeat(0, k).Select(_ => new PriorityQueue<int>()).ToArray();
        //色決めうちしてそれに合わせて置いていく、みたいな 
        //最後数手は上に積み重なってる可能性があるから、125までしか積み上げを許可しない
        int[] colorcand = new int[125];
        for (int i = 0; i < 125; i++)
            colorcand[i] = RNG.Next() % k;
        var lastScore = CalcVal(colorcand);
        int[] bestState = colorcand.ToArray();
        int bestScore = lastScore;
        int iter = 0;
        double progress = 0;
        //var startTemp = 4500;
        var startTemp = 4500;
        var endTemp = 0;
        while (progress < 1)
        {
            iter++;

            int changeInd = RNG.Next() & 127;
            while (125 <= changeInd) changeInd = RNG.Next() & 127;
            int changeFrom = colorcand[changeInd];
            int changeTo = RNG.Next() & 7;
            while (changeFrom == changeTo || 6 <= changeTo) changeTo = RNG.Next() & 7;

            colorcand[changeInd] = changeTo;

            var score = CalcVal(colorcand);
            
            double temp = startTemp + (endTemp - startTemp) * progress;
            double prob = Exp((score - lastScore) / temp);
            if (lastScore < score || RNG.Double > prob)
            {
                if (bestScore < score)
                {
                    bestScore = score;
                    bestState = colorcand.ToArray();
                }
            }
            else
            {
                colorcand[changeInd] = changeFrom;
            }

            if ((iter & 128) == 0)
            {
                progress = (DateTime.Now - StartTime).TotalMilliseconds / 1950.0;
            }
        }
        #if DEBUG
        Console.SetOut(new StreamWriter(@$"C:\Users\{Environment.UserName}\Desktop\a.txt") { AutoFlush = true });
        #endif
        Console.WriteLine(string.Join("\n", GetStep(bestState)));
    }
    static PriorityQueue<int>[] placableRow;
    public static int CalcVal(int[] cand)
    {
        int[] count = new int[125 + 1];
        count[125] = 114514;
        int score = 0;
        for (int i = 0; i < placableRow.Length; i++)
            placableRow[i].Clear();
        placableRow[cand[0]].Push(0);
        for (int i = 0; i < Minos.Length; i++)
        {
            var color = Minos[i].Color;
            var value = Minos[i].Value;
            if (placableRow[color].Count == 0)
            {
                var max = 0;
                var maxInd = -1;
                for (int j = 0; j < placableRow.Length; j++)
                {
                    if (max < placableRow[j].Count)
                    {
                        max = placableRow[j].Count;
                        maxInd = j;
                    }
                }
                var elem = placableRow[maxInd].Top;
                count[elem]++;
                score -= 5;
                if (count[elem] == w || (elem != 0 && count[elem] == count[elem - 1]))
                    placableRow[maxInd].Pop();
                if (count[elem] == count[elem + 1] + 1)
                {
                    placableRow[cand[elem + 1]].Push(elem + 1);
                }
            }
            else
            {
                var elem = placableRow[color].Top;
                count[elem]++;
                score += value;
                if (count[elem] == w || (elem != 0 && count[elem] == count[elem - 1]))
                    placableRow[color].Pop();
                if (count[elem] == count[elem + 1] + 1)
                    placableRow[cand[elem + 1]].Push(elem + 1);
            }
        }
        return score;
    }
    public static int[] GetStep(int[] cand)
    {
        int[] ops = new int[n];
        int[] count = new int[125 + 1];
        count[125] = 114514;
        int score = 0;
        for (int i = 0; i < placableRow.Length; i++)
            placableRow[i].Clear();
        placableRow[cand[0]].Push(0);
        for (int i = 0; i < Minos.Length; i++)
        {
            var color = Minos[i].Color;
            var value = Minos[i].Value;
            if (placableRow[color].Count == 0)
            {
                var max = 0;
                var maxInd = -1;
                for (int j = 0; j < placableRow.Length; j++)
                {
                    if (max < placableRow[j].Count)
                    {
                        max = placableRow[j].Count;
                        maxInd = j;
                    }
                }
                var elem = placableRow[maxInd].Top;
                ops[i] = count[elem];
                count[elem]++;
                if (count[elem] == w || (elem != 0 && count[elem] == count[elem - 1]))
                    placableRow[maxInd].Pop();
                if (count[elem] == count[elem + 1] + 1)
                    placableRow[cand[elem + 1]].Push(elem + 1);
            }
            else
            {
                var elem = placableRow[color].Top;
                ops[i] = count[elem];
                count[elem]++;
                if (count[elem] == w || (elem != 0 && count[elem] == count[elem - 1]))
                    placableRow[color].Pop();
                if (count[elem] == count[elem + 1] + 1)
                    placableRow[cand[elem + 1]].Push(elem + 1);
            }
        }
        return ops;
    }
}

//public class ColorCand : IEnumerable<uint>
//{
//    const int HEIGHT = 125;
//    const int DATA_WORD = 8;
//    const int DATA_PER_WORD = (sizeof(ulong) / DATA_WORD);
//    private ulong[] Data = new ulong[HEIGHT / DATA_PER_WORD];
//    public ColorCand()
//    {

//    }
//    public uint this[int index]
//    {
//        get { return (uint)((Data[index >> 3] >> (index & DATA_PER_WORD)) & (DATA_WORD - 1)); }
//        set 
//        {
//            Data[index >> 3] &= ulong.MaxValue ^ (7UL << (index & DATA_PER_WORD)); 
//            Data[index >> 3] |= (ulong)value << (index & DATA_PER_WORD); 
//        }
//    }
//    public ColorCand Copy()
//    {
//        var newData = new long[HEIGHT / (sizeof(long) / 8)];
//        Data.CopyTo(newData, 0);
//        return new ColorCand() { Data = newData };
//    }

//    public IEnumerator<uint> GetEnumerator() => Enumerable.Range(0, HEIGHT).Select(x => this[x]).GetEnumerator();

//    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
//}

struct Mino
{
    public int Color;
    public int Value;
}


class PriorityQueue<T> where T : IComparable<T>
{
    public int Count { get; private set; }
    private bool Descendance;
    private T[] data = new T[256];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PriorityQueue(bool descendance = false) { Descendance = descendance; }
    public T Top
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { ValidateNonEmpty(); return data[1]; }
    }
    public void Clear()
    {
        Count = 0;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Pop()
    {
        var top = Top;
        var elem = data[Count--];
        int index = 1;
        while (true)
        {
            if ((index << 1) >= Count)
            {
                if (index << 1 > Count) break;
                if (elem.CompareTo(data[index << 1]) > 0 ^ Descendance) data[index] = data[index <<= 1];
                else break;
            }
            else
            {
                var nextIndex = data[index << 1].CompareTo(data[(index << 1) + 1]) <= 0 ^ Descendance ? (index << 1) : (index << 1) + 1;
                if (elem.CompareTo(data[nextIndex]) > 0 ^ Descendance) data[index] = data[index = nextIndex];
                else break;
            }
        }
        data[index] = elem;
        return top;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Push(T value)
    {
        int index = ++Count;
        if (data.Length == Count) Extend(data.Length * 2);
        while ((index >> 1) != 0)
        {
            if (data[index >> 1].CompareTo(value) > 0 ^ Descendance) data[index] = data[index >>= 1];
            else break;
        }
        data[index] = value;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Extend(int newSize)
    {
        T[] newDatas = new T[newSize];
        data.CopyTo(newDatas, 0);
        data = newDatas;
    }
    private void ValidateNonEmpty() { if (Count == 0) throw new Exception(); }
}

static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream =
#if !DEBUG
        Console.OpenStandardInput();
#else
        new FileStream($@"C:\Users\{Environment.UserName}\Desktop\case.txt", FileMode.Open);
#endif
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = BUF_SIZE - 1;
    static void Move() { if (++ptr >= Buffer.Length) { Stream.Read(Buffer, 0, BUF_SIZE); ptr = 0; } }


    public static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0; while (Buffer[ptr] < 48) Move();
            do { res = res * 10 + (int)(Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
}

namespace keymoon.Marathon.Heuristic
{
    //TODO:設計要検討
    public abstract class StateBase
    {
        public abstract int Score { get; set; }
        public abstract void Transition(uint seed = 0);
    }

    public abstract class ReversibleStateBase : StateBase
    {
        /// <summary>一度だけreverseできれば良い</summary>
        public abstract void Reverse();
    }

    public abstract class CopieableStateBase : StateBase
    {
        public abstract CopieableStateBase Copy();
    }
}

namespace keymoon.Marathon.Util
{
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    public class Array2D<T> : IEnumerable<IEnumerable<T>>
    {
        public static string Prefix;
        public readonly int H;
        public readonly int W;
        T[] data;
        public Array2D(int h, int w)
        {
            H = h;
            W = w;
            data = new T[H * W];
        }
        public Array2D(int h, int w, T[][] data) : this(h, w)
        {
            int ptr = 0;
            for (int i = 0; i < H; i++)
                for (int j = 0; j < W; j++)
                    this.data[ptr++] = data[i][j];
        }

        public IEnumerable<T> this[int y]
        {
            get 
            {
                var ind = y * W;
                for (int i = 0; i < W; i++)
                {
                    yield return data[ind + i]; 
                }
            }
        }

        public T this[int y, int x]
        {
            get { return data[y * W + x]; }
            set { data[y * W + x] = value; }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<IEnumerable<T>> GetEnumerator()
        {
            for (int i = 0; i < H; i++) yield return this[i];
        }

        public Array2D<T> Crop(int minY, int maxY, int minX, int maxX)
        {
            var newH = maxY - minY + 1;
            var newW = maxX - minX + 1;
            var res = new Array2D<T>(newH, newW);
            for (int y = 0; y < newH; y++)
                for (int x = 0; x < newW; x++)
                    res[y, x] = this[minY + y, minX + x];
            return res;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public class MyRandom
    {
        public static MyRandom RNG;
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

        public MyRandom() : this((ulong)DateTime.Now.Ticks) { }
        public MyRandom(ulong seed) { SetSeed(seed); }
        public void SetSeed(ulong seed) => _xorshift = seed * 0x3141592c0ffeeul;

        public int Next() => Int & 2147483647;
        public void Update()
        {
            _xorshift ^= _xorshift << 7;
            _xorshift ^= _xorshift >> 9;
        }
    }
}
