// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/0363/judge/3112001/C#
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static bool[][] bits =
    {
        new bool[]{ false,false,false },
        new bool[]{ false,false,true },
        new bool[]{ false,true,false },
        new bool[]{ false,true,true },
        new bool[]{ true,false,false },
        new bool[]{ true,false,true },
        new bool[]{ true,true,false },
        new bool[]{ true,true,true }
    };
    static int[] bitCount = { 0, 1, 1, 2, 1, 2, 2, 3 };
    static int[][] transition =
    {
        new int[]{0,1,2,4,5 },//0
        new int[]{0,4 },//1
        new int[]{0},//2
        new int[]{},//3
        new int[]{0,1},//4
        new int[]{0},//5
        new int[]{},//6
        new int[]{}//7
    };
    static bool[][] canPlaceCarry = null;
    static void Main()
    {
        int[] hn = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[][] dp = Enumerable.Repeat(0, hn[0]).Select(_ => new int[8]).ToArray();
        canPlaceCarry = Enumerable.Repeat(0, hn[0] - 1).Select(_ => new bool[3] { true, true, true }).ToArray();
        for (int i = 0; i < hn[1]; i++)
        {
            int[] xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
            setFalse(xy[0], (hn[0] - 1) - xy[1]);
        }
        for (int i = 1; i < hn[0]; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                //移る先を列挙
                foreach (var trans in transition[j])
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (bits[trans][k] && !canPlaceCarry[i - 1][k]) goto elop;
                    }
                    dp[i][trans] = Max(dp[i][trans], dp[i - 1][j] + bitCount[trans]);
                    elop:;
                }
            }
        }
        Console.WriteLine(dp.Last().Max());
    }
    static void setFalse(int x,int y)
    {
        if (y != 0)
        {
            if (x != 0)
            {
                canPlaceCarry[y - 1][x - 1] = false;
            }
            if (x < 3)
            {
                canPlaceCarry[y - 1][x] = false;
            }
        }
        if (y < canPlaceCarry.Length)
        {
            if (x != 0)
            {
                canPlaceCarry[y][x - 1] = false;
            }
            if (x < 3)
            {
                canPlaceCarry[y][x] = false;
            }
        }
    }
}
