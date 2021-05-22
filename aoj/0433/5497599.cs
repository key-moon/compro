// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/0433/judge/5497599/C#
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
        //   c4
        //   c2
        // c1  c3
        var r = Console.ReadLine();
        var c1 = r[0];
        var c2 = r[2];
        char c3 = '_';
        if (c2 == 'R')
        {
            if (c1 == 'B') c3 = 'G';
            if (c1 == 'Y') c3 = 'B';
            if (c1 == 'G') c3 = 'Y';
        }
        if (c2 == 'G')
        {
            if (c1 == 'R') c3 = 'B';
            if (c1 == 'Y') c3 = 'R';
            if (c1 == 'B') c3 = 'Y';
        }
        if (c2 == 'B')
        {
            if (c1 == 'R') c3 = 'Y';
            if (c1 == 'Y') c3 = 'G';
            if (c1 == 'G') c3 = 'R';
        }
        if (c2 == 'Y')
        {
            if (c1 == 'R') c3 = 'G';
            if (c1 == 'G') c3 = 'B';
            if (c1 == 'B') c3 = 'R';
        }

        var c4 = (char)('R' ^ 'Y' ^ 'G' ^ 'B' ^ c1 ^ c2 ^ c3);

        char[][] cols = Enumerable.Repeat(0, 4).Select(_ => new char[2]).ToArray();
        cols[0][0] = c1;
        cols[1][0] = c2;
        cols[0][1] = c4;
        cols[1][1] = c3;

        cols[2][0] = c3;
        cols[3][0] = c4;
        cols[2][1] = c2;
        cols[3][1] = c1;


        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var pos = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(cols[pos[0] % 4][pos[1] % 2]);
        }
    }
}

