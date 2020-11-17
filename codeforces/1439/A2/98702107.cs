// detail: https://codeforces.com/contest/1439/submission/98702107
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
    public static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var mat = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Select(x => x == '1').ToArray()).ToArray();
        List<string> res = new List<string>();
        int[] temp = new int[6];
        void Add(int ty, int tx, int by, int bx)
        {
            int ind = 0;
            for (int i = ty; i <= ty + 1; i++)
            {
                for (int j = tx; j <= tx + 1; j++)
                {
                    if (i == by && j == bx) continue;
                    temp[ind++] = i + 1;
                    temp[ind++] = j + 1;
                    mat[i][j] ^= true;
                }
            }
            res.Add(string.Join(" ", temp));
        }

        if (n % 2 == 1 && m % 2 == 1)
            if (mat[n - 1][m - 1])
                Add(n - 2, m - 2, n - 2, m - 2);

        if (n % 2 == 1)
        {
            var i = n - 1;
            var limit = (n % 2 == 1 && m % 2 == 1) ? m - 1 : m;
            for (int j = 0; j < limit; j++)
            {
                if (!mat[i][j]) continue;
                if (j == 0) Add(i - 1, j, i, j + 1);
                else Add(i - 1, j - 1, i, j - 1);
            }
        }
        if (m % 2 == 1)
        {
            var j = m - 1;
            var limit = (n % 2 == 1 && m % 2 == 1) ? n - 1 : n; 
            for (int i = 0; i < limit; i++)
            {
                if (!mat[i][j]) continue;
                if (i == 0) Add(i, j - 1, i + 1, j);
                else Add(i - 1, j - 1, i - 1, j);
            }
        }
        for (int i = 0; i + 1 < n; i += 2)
        {
            for (int j = 0; j + 1 < m; j += 2)
            {
                var one = new List<(int, int)>();
                var zero = new List<(int, int)>();
                for (int y = i; y <= i + 1; y++)
                    for (int x = j; x <= j + 1; x++)
                        (mat[y][x] ? one : zero).Add((y, x));
                List<(int, int)> opList = null;
                switch (one.Count)
                {
                    case 0:
                    case 2:
                    case 4:
                        opList = one;
                        break;
                    case 1:
                    case 3:
                        opList = zero;
                        break;
                }
                foreach (var (y, x) in opList) Add(i, j, y, x);
            }
        }
        if (n * m < res.Count) throw new Exception();
        if (mat.Any(x => x.Any(y => y))) throw new Exception();
        Console.WriteLine(res.Count);
        Console.WriteLine(string.Join("\n", res));
    }
}
