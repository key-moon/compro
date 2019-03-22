// detail: https://codeforces.com/contest/1140/submission/51687837
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToList();
        //読んだことがない最初のページから一ページ毎に読んでいく
        int max = 0;
        int clearCount = 0;
        for (int i = 0; i < n; i++)
        {
            max = Max(max, a[i]);
            if (max == i) clearCount++;
        }
        Console.WriteLine(clearCount);
    }
}
