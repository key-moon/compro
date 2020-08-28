// detail: https://atcoder.jp/contests/arc086/submissions/16277283
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<int>[] graph = Enumerable.Repeat(0, n + 1).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < a.Length; i++)
            graph[a[i]].Add(i + 1);
        int[] depths = new int[n + 1];
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        while (stack.Count != 0)
        {
            var elem = stack.Pop();
            foreach (var item in graph[elem])
            {
                depths[item] = depths[elem] + 1;
                stack.Push(item);
            }
        }
        Deque<(ModInt, ModInt) >[] res = new Deque<(ModInt, ModInt)>[n + 1];
        foreach (var (depth, ind) in depths.Select((elem, ind) => (elem, ind)).OrderByDescending(x => x.elem))
        {
            var sorted = graph[ind].Select(x => res[x]).OrderByDescending(x => x.Count).ToArray();
            res[ind] = sorted.Length == 0 ? new Deque<(ModInt, ModInt)>() : sorted.First();
            var newTotal = new List<ModInt>();
            var badPerms = new List<ModInt>();
            var newPerms = new List<ModInt>();
            foreach (var item in sorted.Skip(1))
            {
                for (int i = 0; i < item.Count; i++)
                {
                    var (perm, total) = item[i];
                    if (newTotal.Count == i)
                    {
                        newTotal.Add(res[ind][i].Item2);
                        badPerms.Add(res[ind][i].Item2 - res[ind][i].Item1);
                        newPerms.Add(0);
                    }
                    newTotal[i] *= total;
                    badPerms[i] *= total - perm;
                }
            }
            foreach (var item in sorted)
            {
                var max = Min(newTotal.Count, item.Count);
                for (int i = 0; i < max; i++)
                {
                    var (perm, total) = item[i];
                    newPerms[i] += badPerms[i] / (total - perm) * perm;
                }
            }
            for (int i = 0; i < newTotal.Count; i++)
                res[ind][i] = (newPerms[i], newTotal[i]);

            res[ind].PushFront((1, 2));
        }
        ModInt allPerm = 1;
        for (int i = 0; i <= n; i++)
            allPerm *= 2;

        Console.WriteLine(res[0].Aggregate(new ModInt(0), (x, y) => x + y.Item1 * (allPerm / y.Item2)));
    }
}

class Deque<T> : IEnumerable<T>
{
    public int Count;
    T[] data; int FrontInd, BackInd;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Deque() { data = new T[16]; FrontInd = 0; BackInd = data.Length - 1; Count = 0; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Deque(T[] elem)
    {
        int s = elem.Length; s |= s >> 1; s |= s >> 2; s |= s >> 4; s |= s >> 8; s |= s >> 16;
        data = new T[++s]; elem.CopyTo(data, 0);
        FrontInd = 0; BackInd = elem.Length - 1; Count = elem.Length;
    }

    public T Front
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { ValidateNoEmpty(); return data[FrontInd]; }
    }
    public T Back
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { ValidateNoEmpty(); return data[BackInd]; }
    }

    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { if (index >= Count) throw new Exception(); return data[FrontInd + index & data.Length - 1]; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { if (index >= Count) throw new Exception(); data[FrontInd + index & data.Length - 1] = value; }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void PushFront(T elem) { if (Count == data.Length) Extend(data.Length << 1); Count++; data[FrontInd = (FrontInd - 1) & data.Length - 1] = elem; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T PopFront() { var res = Front; FrontInd = (FrontInd + 1) & data.Length - 1; Count--; return res; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void PushBack(T elem) { if (Count == data.Length) Extend(data.Length << 1); Count++; data[BackInd = (BackInd + 1) & data.Length - 1] = elem; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T PopBack() { var res = Back; BackInd = (BackInd - 1) & data.Length - 1; Count--; return res; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Extend(int newSize)
    {
        T[] newData = new T[newSize];
        if (0 < Count)
        {
            if (FrontInd <= BackInd) Array.Copy(data, FrontInd, newData, 0, Count);
            else
            {
                Array.Copy(data, FrontInd, newData, 0, data.Length - FrontInd);
                Array.Copy(data, 0, newData, data.Length - FrontInd, BackInd + 1);
            }
        }
        data = newData; FrontInd = 0; BackInd = Count - 1;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ValidateNoEmpty() { if (Count == 0) throw new Exception(); }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerator<T> GetEnumerator() { for (int i = FrontInd; i != BackInd; i = i + 1 & data.Length - 1) yield return data[i]; yield return data[BackInd]; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
}

struct ModInt
{
    public const int Mod = 1000000007;
    const long POSITIVIZER = ((long)Mod) << 31;
    long Data;
    public ModInt(long data) { if ((Data = data % Mod) < 0) Data += Mod; }
    public static implicit operator long(ModInt modInt) => modInt.Data;
    public static implicit operator ModInt(long val) => new ModInt(val);
    public static ModInt operator +(ModInt a, int b) => new ModInt() { Data = (a.Data + b + POSITIVIZER) % Mod };
    public static ModInt operator +(ModInt a, long b) => new ModInt(a.Data + b);
    public static ModInt operator +(ModInt a, ModInt b) { long res = a.Data + b.Data; return new ModInt() { Data = res >= Mod ? res - Mod : res }; }
    public static ModInt operator -(ModInt a, int b) => new ModInt() { Data = (a.Data - b + POSITIVIZER) % Mod };
    public static ModInt operator -(ModInt a, long b) => new ModInt(a.Data - b);
    public static ModInt operator -(ModInt a, ModInt b) { long res = a.Data - b.Data; return new ModInt() { Data = res < 0 ? res + Mod : res }; }
    public static ModInt operator *(ModInt a, int b) => new ModInt(a.Data * b);
    public static ModInt operator *(ModInt a, long b) => a * new ModInt(b);
    public static ModInt operator *(ModInt a, ModInt b) => new ModInt() { Data = a.Data * b.Data % Mod };
    public static ModInt operator /(ModInt a, ModInt b) => new ModInt() { Data = a.Data * GetInverse(b) % Mod };
    public static bool operator ==(ModInt a, ModInt b) => a.Data == b.Data;
    public static bool operator !=(ModInt a, ModInt b) => a.Data != b.Data;
    public override string ToString() => Data.ToString();
    public override bool Equals(object obj) => (ModInt)obj == this;
    public override int GetHashCode() => (int)Data;
    static long GetInverse(long a)
    {
        long div, p = Mod, x1 = 1, y1 = 0, x2 = 0, y2 = 1;
        while (true)
        {
            if (p == 1) return x2 + Mod; div = a / p; x1 -= x2 * div; y1 -= y2 * div; a %= p;
            if (a == 1) return x1 + Mod; div = p / a; x2 -= x1 * div; y2 -= y1 * div; p %= a;
        }
    }
}
