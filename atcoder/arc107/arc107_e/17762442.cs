// detail: https://atcoder.jp/contests/arc107/submissions/17762442
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
    static int n;
    public static void Main()
    {
        n = int.Parse(Console.ReadLine());
        if (n <= 10)
        {
            var mat = Enumerable.Repeat(0, n).Select(x => new int[n]).ToArray();
            mat[0] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 1; i < n; i++)
            {
                mat[i][0] = int.Parse(Console.ReadLine());
            }
            mat = EmulateAll(mat);
            Console.WriteLine($"{mat.Sum(x => x.Count(y => y == 0))} {mat.Sum(x => x.Count(y => y == 1))} {mat.Sum(x => x.Count(y => y == 2))}");
            return;
        }
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = new int[n];
        b[0] = a[0];
        for (int i = 1; i < n; i++)
        {
            b[i] = int.Parse(Console.ReadLine());
        }
        var (ra, rb) = Emulate(a, b);
        long[] c = {
            ra.Sum(x => (long)x.Count(y => y == 0)) + rb.Sum(x => (long)x.Skip(5).Count(y => y == 0)),
            ra.Sum(x => (long)x.Count(y => y == 1)) + rb.Sum(x => (long)x.Skip(5).Count(y => y == 1)),
            ra.Sum(x => (long)x.Count(y => y == 2)) + rb.Sum(x => (long)x.Skip(5).Count(y => y == 2))
        };
        for (int i = 5; i < n; i++)
        {
            var cont = ra[4][i - 1];
            c[cont] += n - i;
        }
        for (int i = 6; i < n; i++)
        {
            var cont = rb[4][i - 1];
            c[cont] += n - i;
        }
        Console.WriteLine(string.Join(" ", c));
    }

    static int[][] table = new int[][]
    {
        new int[] { 1 , 2 , 1 },
        new int[] { 2 , 0 , 0 },
        new int[] { 1 , 0 , 0 }
    };

    public static int[][] EmulateAll(int[][] a)
    {
        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j < n; j++)
            {
                a[i][j] = table[a[i - 1][j]][a[i][j - 1]];
            }
        }
        return a;
    }

    public static (int[][], int[][]) Emulate(int[] a, int[] b)
    {
        var ra = new int[][] { a, new int[n], new int[n], new int[n], new int[n] };
        var rb = new int[][] { b, new int[n], new int[n], new int[n], new int[n] };
        ra[1][0] = rb[0][1];
        ra[2][0] = rb[0][2];
        ra[3][0] = rb[0][3];
        ra[4][0] = rb[0][4];
        rb[1][0] = ra[0][1];
        rb[2][0] = ra[0][2];
        rb[3][0] = ra[0][3];
        rb[4][0] = ra[0][4];
        for (int i = 1; i < 5; i++)
        {
            for (int j = 1; j < n; j++)
            {
                ra[i][j] = table[ra[i][j - 1]][ra[i - 1][j]];
                rb[i][j] = table[rb[i][j - 1]][rb[i - 1][j]];
            }
        }
        return (ra, rb);
    }
}