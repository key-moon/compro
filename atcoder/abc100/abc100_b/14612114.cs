// detail: https://atcoder.jp/contests/abc100/submissions/14612114
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
        var dn = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int count = 0;
        for (int i = 1; true; i++)
        {
            int divCount = 0;
            var tmpi = i;
            while (tmpi % 100 == 0)
            {
                divCount++;
                tmpi /= 100;
            }
            if (divCount == dn[0])
            {
                count++;
            }
            if (count == dn[1])
            {
                Console.WriteLine(i);
                return;
            }
        }
    }
}