// detail: https://codeforces.com/contest/1106/submission/49260620
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
        Random RNG = new Random();
        int n = int.Parse(Console.ReadLine());
        long[] a = Console.ReadLine().Split().Select(long.Parse).OrderBy(x => RNG.Next()).OrderBy(x => x).ToArray();
        long res = 0;
        for (int i = 0, j = n - 1; i < j; i++, j--) res += (a[i] + a[j]) * (a[i] + a[j]);
        Console.WriteLine(res);
        //まあなるべく全体を慣らしたいですよね みたいな気持ちがあります
        //
    }
}
