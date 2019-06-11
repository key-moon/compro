// detail: https://yukicoder.me/submissions/351099
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        //matrix[i,j]:vector[i]の要素が1であればi行目のj要素に乗算が行われ、そこに遷移する
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = nk[0];
        int k = nk[1];
        ModMatrix matrix = new ModMatrix(k * k * k, k * k * k);
        //k=2の時
        //  a : 01010101
        // ab : 00110011
        //abc : 00001111
        for (int i = 0; i < matrix.Height; i++)
        {
            int val = i;
            int aCount = val % k;
            val /= k;
            int abCount = val % k;
            val /= k;
            int abcCount = val % k;

            int newACount, newABCount, newABCCount;
            //aが追加された時
            newACount = (aCount + 1) % k;
            newABCount = abCount;
            newABCCount = abcCount;
            matrix[i, (newABCCount * k + newABCount) * k + newACount] += 1;

            //bが追加された時
            newACount = aCount;
            newABCount = (abCount + aCount) % k;
            newABCCount = abcCount;
            matrix[i, (newABCCount * k + newABCount) * k + newACount] += 1;

            //cが追加された時
            newACount = aCount;
            newABCount = abCount;
            newABCCount = (abcCount + abCount) % k;
            matrix[i, (newABCCount * k + newABCount) * k + newACount] += 1;
        }

        ModMatrix res = new ModMatrix(1, k * k * k);
        res[0, 0] = 1;

        long pow = n;
        while (n > 0)
        {
            if ((n & 1) == 1) res *= matrix;
            matrix *= matrix;
            n >>= 1;
        }

        long resSum = 0;
        for (int i = 0; i < k * k; i++) resSum += res[0, i];
        Console.WriteLine(resSum % 998244353);
    }
}

class ModMatrix : IEquatable<ModMatrix>
{
    const int MOD = 998244353;
    public readonly int Height;
    public readonly int Width;
    long[,] data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ModMatrix(int height, int width)
    {
        data = new long[height, width];
        Height = height;
        Width = width;
    }
    public long this[int i, int j]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return data[i, j]; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { if ((data[i, j] = value % MOD) < 0) data[i, j] += MOD; }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(ModMatrix other)
    {
        if (this.Width != other.Width || this.Height != other.Height) return false;
        for (int i = 0; i < Height; i++) for (int j = 0; j < Width; j++) if (this[i, j] != other[i, j]) return false;
        return true;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModMatrix Add(ModMatrix a, ModMatrix b)
    {
        Debug.Assert(a.Width == b.Width && a.Height == b.Height);
        var res = new ModMatrix(a.Height, a.Width);
        for (int i = 0; i < a.Height; i++) for (int j = 0; j < a.Width; j++) if (MOD <= (res.data[i, j] = a[i, j] + b[i, j])) res.data[i, j] -= MOD;
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModMatrix Sub(ModMatrix a, ModMatrix b)
    {
        Debug.Assert(a.Width == b.Width && a.Height == b.Height);
        var res = new ModMatrix(a.Height, a.Width);
        for (int i = 0; i < a.Height; i++) for (int j = 0; j < a.Width; j++) if ((res.data[i, j] = a[i, j] - b[i, j]) < 0) res.data[i, j] += MOD;
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModMatrix Mul(ModMatrix a, ModMatrix b)
    {
        Debug.Assert(a.Width == b.Height);
        var res = new ModMatrix(a.Height, b.Width);
        for (int i = 0; i < a.Height; i++) for (int j = 0; j < b.Width; j++) { for (int k = 0; k < a.Width; k++) res.data[i, j] += a[i, k] * b[k, j] % MOD; res.data[i, j] %= MOD; }
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModMatrix operator +(ModMatrix a, ModMatrix b) => Add(a, b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModMatrix operator -(ModMatrix a, ModMatrix b) => Sub(a, b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModMatrix operator *(ModMatrix a, ModMatrix b) => Mul(a, b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ModMatrix a, ModMatrix b) => a.Equals(b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ModMatrix a, ModMatrix b) => !a.Equals(b);
}
