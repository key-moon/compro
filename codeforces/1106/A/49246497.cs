// detail: https://codeforces.com/contest/1106/submission/49246497
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        int h = int.Parse(Console.ReadLine()); ;
        List<List<char>> grid = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine().ToList()).ToList();
        long res = 0;
        for (int i = 1; i < grid.Count - 1; i++)
        {
            for (int j = 1; j < grid[0].Count - 1; j++)
            {
                if (grid[i][j] == 'X' &&
                   grid[i + 1][j + 1] == 'X' &&
                   grid[i + 1][j - 1] == 'X' &&
                   grid[i - 1][j + 1] == 'X' &&
                   grid[i - 1][j - 1] == 'X') res++;
            }
        }
        Console.WriteLine(res);

    }
}
