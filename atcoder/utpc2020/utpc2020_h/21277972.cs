// detail: https://atcoder.jp/contests/utpc2020/submissions/21277972
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
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hw[0];
        var w = hw[1];
        var mat = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine().Select(x => x == '#').ToArray()).ToArray();
        var tMat = Enumerable.Range(0, w).Select(x => mat.Select(y => y[x]).ToArray()).ToArray();
        int Solve(bool[][] mat)
        {
            int h = mat.Length;
            int w = mat[0].Length;

            List<int> rowCnt = Enumerable.Repeat(0, h).ToList();
            List<int> colCnt = Enumerable.Repeat(0, w).ToList();

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (!mat[i][j]) continue;
                    rowCnt[i]++;
                    colCnt[j]++;
                }
            }

            int res = 0;
            while (true)
            {
                if (h == 1)
                {
                    res += w;
                    break;
                }
                if (w == 1)
                {
                    res += h;
                    break;
                }

                for (int i = 0; i < rowCnt.Count; i++)
                {
                    if (rowCnt[i] != w && rowCnt[i] != 0) continue;
                    h--;
                    rowCnt[i] = int.MinValue / 2;
                    for (int j = 0; j < colCnt.Count; j++) if (mat[i][j]) colCnt[j]--;
                    goto end;
                }

                for (int j = 0; j < colCnt.Count; j++)
                {
                    if (colCnt[j] != h && colCnt[j] != 0) continue;
                    w--;
                    colCnt[j] = int.MinValue / 2;
                    for (int i = 0; i < rowCnt.Count; i++) if (mat[i][j]) rowCnt[i]--;
                    goto end;
                }
                break;

                end:;
                res++;
            }
            return res;
        }
        Console.WriteLine(Max(Solve(mat), Solve(tMat)));
    }
}