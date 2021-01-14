// detail: https://yukicoder.me/submissions/603301
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
        var nd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nd[0];
        var d = nd[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var origPos = 0;
        var pos = 0;
        List<int> res = new List<int>() { 0 };
        foreach (var distance in a)
        {
            origPos += distance;
            pos += d;
            pos = Max(pos, origPos);
            res.Add(pos);
        }

        Console.WriteLine(string.Join(" ", res));
    }
}