// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2311/judge/5351624/C#
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
        var board = Enumerable.Repeat(0, 8).Select(_ => Console.ReadLine().ToArray()).ToArray();
        bool skipped = false;
        char turn = 'o';
        while (true)
        {
            Tuple<int, int> maxInd = new Tuple<int, int>(-1, -1);
            int max = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var cnt = Flips(board, i, j, turn).Count();
                    if (turn == 'o' ? max < cnt : max <= cnt)
                    {
                        maxInd = new Tuple<int, int>(i, j);
                        max = cnt;
                    }
                }
            }
            if (max != 0)
            {
                foreach (var item in Flips(board, maxInd.Item1, maxInd.Item2, turn).ToArray())
                {
                    board[item.Item1][item.Item2] = turn;
                }
                board[maxInd.Item1][maxInd.Item2] = turn;
                skipped = false;
            }
            else
            {
                if (skipped) break;
                skipped = true;
            }
            turn = (char)(turn ^ 'o' ^ 'x');
        }
        foreach (var row in board)
        {
            Console.WriteLine(row);
        }
    }
    static IEnumerable<Tuple<int, int>> Flips(char[][] board, int y, int x, char c)
    {
        if (board[y][x] != '.') yield break;

        int[] dys = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dxs = { -1, 0, 1, -1, 1, -1, 0, 1 };
        List<Tuple<int, int>> l = new List<Tuple<int, int>>();
        for (int dind = 0; dind < 8; dind++)
        {
            var dy = dys[dind];
            var dx = dxs[dind];
            int cury = y;
            int curx = x;
            l.Clear();
            while (true)
            {
                cury += dy;
                curx += dx;
                if (cury < 0 || 8 <= cury) break;
                if (curx < 0 || 8 <= curx) break;
                if (board[cury][curx] == '.') break;
                if (board[cury][curx] != c)
                {
                    l.Add(new Tuple<int, int>(cury, curx));
                    continue;
                }
                if (board[cury][curx] == c)
                {
                    foreach (var item in l) yield return item;
                    break;
                }
            }
        }
    }
}
