// detail: https://codeforces.com/contest/710/submission/104676023
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
        int n = int.Parse(Console.ReadLine());
        int[][] res = Enumerable.Repeat(0, n).Select(_ => new int[n]).ToArray();
        Stack<int> odd = new Stack<int>(Enumerable.Range(1, n * n).Where(x => x % 2 == 1));
        Stack<int> even = new Stack<int>(Enumerable.Range(1, n * n).Where(x => x % 2 == 0));
        for (int i = 0; i < n; i++)
        {
            res[i][n / 2] = odd.Pop();
            if (i != n / 2) res[n / 2][i] = odd.Pop();
        }
        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j < n / 2; j++)
            {
                if (odd.Count == 0) continue;
                res[i][j] = odd.Pop();
                res[n - 1 - i][j] = odd.Pop();
                res[i][n - 1 - j] = odd.Pop();
                res[n - 1 - i][n - 1 - j] = odd.Pop();
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (res[i][j] != 0) continue;
                res[i][j] = even.Pop();
            }
        }

        Console.WriteLine(string.Join("\n", res.Select(x => string.Join(" ", x))));
    }
}