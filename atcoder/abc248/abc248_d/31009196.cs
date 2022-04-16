// detail: https://atcoder.jp/contests/abc248/submissions/31009196
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<int>[] arr = Enumerable.Repeat(0, 200001).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < a.Length; i++)
        {
            arr[a[i]].Add(i);
        }
        int q = int.Parse(Console.ReadLine());
        for (int i = 0; i < q; i++)
        {
            var lrx = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var l = lrx[0] - 1;
            var r = lrx[1] - 1;
            var x = lrx[2];
            var lind = arr[x].BinarySearch(l);
            if (lind < 0) lind = ~lind;
            var rind = arr[x].BinarySearch(r + 1);
            if (rind < 0) rind = ~rind;
            Console.WriteLine(rind - lind);
        }
    }
}
