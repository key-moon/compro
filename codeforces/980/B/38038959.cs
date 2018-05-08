// detail: https://codeforces.com/contest/980/submission/38038959
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        char[][] grid = Enumerable.Repeat(0, 4).Select(x => Enumerable.Repeat('.', nk[0]).ToArray()).ToArray();
        if (nk[1] > nk[0] - 2)
        {
            grid[1] = genStr(nk[0], nk[0] - 2);
            grid[2] = genStr(nk[0], nk[1] - (nk[0] - 2));
        }
        else
        {
            grid[1] = genStr(nk[0], nk[1]);
        }
        Console.WriteLine("YES");
        Console.WriteLine(string.Join("\n",grid.Select(x => string.Join("",x))));
    } 
    static char[] genStr(int n,int k)
    {
        char[] grid = Enumerable.Repeat('.', n).ToArray();
        if (k % 2 == 1)
        {
            grid[n / 2] = '#';
            k--;
        }
        while (0 < k)
        {
            k--;
            grid[n / 2 + (k % 2 == 0 ? -1 : 1) * (k / 2 + 1)] = '#';
        }
        return grid;
    }
}