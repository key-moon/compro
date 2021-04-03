// detail: https://codeforces.com/contest/1503/submission/111887494
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
        Stack<(int, int)> a = new Stack<(int, int)>();
        Stack<(int, int)> b = new Stack<(int, int)>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if ((i + j) % 2 == 0) a.Push((i, j));
                else b.Push((i, j));
            }
        }
        int filled = 0;
        Stack<(int, int)> remain = null;
        for (int cnt = 0; cnt < n * n; cnt++)
        {
            var val = int.Parse(Console.ReadLine());
            int y, x, col;
            if (filled != 0)
            {
                col = 1;
                while (col == filled || col == val) col++;
                (y, x) = remain.Pop();
            }
            else
            {
                if (val == 1)
                {
                    (y, x) = a.Pop();
                    col = 2;
                    if (a.Count == 0) (filled, remain) = (2, b);
                }
                else
                {
                    (y, x) = b.Pop();
                    col = 1;
                    if (b.Count == 0) (filled, remain) = (1, a);
                }
            }
            Console.WriteLine($"{col} {y + 1} {x + 1}");
        }
    }
}