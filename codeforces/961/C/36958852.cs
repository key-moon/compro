// detail: https://codeforces.com/contest/961/submission/36958852
using System;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        //nは奇数
        int n = int.Parse(Console.ReadLine());
        int[][][] boards = Enumerable.Repeat(0, 4).Select(_ => new int[n][]).ToArray();
        for (int i = 0; i < 4; i++)
        {
            boards[i] = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Select(x => x - '0').ToArray()).ToArray();
            if (i != 3) Console.ReadLine();
        }
        //黒にするのに必要な個数
        int[] shouldChange = Enumerable.Repeat(0, 4).ToArray();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < boards[i].Length; j++)
            {
                for (int k = 0; k < boards[i][j].Length; k++)
                {
                    if ((j + k) % 2 != boards[i][j][k])
                    {
                        shouldChange[i]++;
                    }
                }
            }
        }
        int min = new int[] {
        shouldChange[0] + shouldChange[1] + (n * n - shouldChange[2]) + (n * n - shouldChange[3]),
        shouldChange[0] + shouldChange[2] + (n * n - shouldChange[1]) + (n * n - shouldChange[3]),
        shouldChange[0] + shouldChange[3] + (n * n - shouldChange[1]) + (n * n - shouldChange[2]),
        shouldChange[1] + shouldChange[2] + (n * n - shouldChange[0]) + (n * n - shouldChange[3]),
        shouldChange[1] + shouldChange[3] + (n * n - shouldChange[0]) + (n * n - shouldChange[2]),
        shouldChange[2] + shouldChange[3] + (n * n - shouldChange[0]) + (n * n - shouldChange[1])}.Min();
        Console.WriteLine(min);
    }
}