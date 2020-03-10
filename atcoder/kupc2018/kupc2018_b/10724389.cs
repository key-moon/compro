// detail: https://atcoder.jp/contests/kupc2018/submissions/10724389
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

        var map = Enumerable.Repeat(0, hw[0]).Select(_ => Console.ReadLine()).Reverse().ToArray();
        var initPlace = map[0].TakeWhile(x => x != 's').Count();
        for (int i = 0; i < (1 << ((hw[0] - 1) * 2)); i++)
        {
            int place = initPlace;
            int row = 1;
            for (int j = 0; j < (hw[0] - 1) * 2; j += 2, row++)
            {
                var op = (i >> j) & 3;
                if (op == 3) goto end;
                if (op == 0) place--;
                if (op == 1) place++;
                if (place < 0 || hw[1] <= place) goto end;
                if (map[row][place] != '.') goto end;
            }
            string res = "";
            for (int j = 0; j < (hw[0] - 1) * 2; j += 2)
            {
                var op = (i >> j) & 3;
                if (op == 3) goto end;
                if (op == 0) res += "L";
                if (op == 1) res += "R";
                if (op == 2) res += "S";
            }
            Console.WriteLine(res);
            return;
            end:;
        }
        Console.WriteLine("impossible");
    }
}
