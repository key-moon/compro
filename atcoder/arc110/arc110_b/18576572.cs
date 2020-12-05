// detail: https://atcoder.jp/contests/arc110/submissions/18576572
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
        var t = Console.ReadLine();
        if (t.Length <= 2)
        {
            long total = (long)1e10;
            long res = 0;
            if (t == "11") res = total;
            if (t == "10") res = total;
            if (t == "01") res = total - 1;
            if (t == "1") res = total * 2;
            if (t == "0") res = total;
            Console.WriteLine(res);
            return;
        }
        int cnt = 0;
        int start = 0;
        if (t.StartsWith("10"))
        {
            cnt += 1;
            start += 2;
        }
        else if (t.StartsWith("0"))
        {
            cnt += 1;
            start += 1;
        }
        int end = n;
        if (t.EndsWith("11"))
        {
            cnt += 1;
            end -= 2;
        }
        else if (t.EndsWith("1"))
        {
            cnt += 1;
            end -= 1;
        }
        if ((end - start) % 3 != 0)
        {
            Console.WriteLine(0);
            return;
        }
        for (int i = start; i < end; i += 3)
        {
            if (t.Substring(i, 3) != "110")
            {
                Console.WriteLine(0);
                return;
            }
            cnt++;
        }
        Console.WriteLine((long)1e10 - cnt + 1);
    }
}