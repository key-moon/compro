// detail: https://yukicoder.me/submissions/603311
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        int[] cnts = new int[200001];
        foreach (var item in Console.ReadLine().Split().Select(int.Parse)) cnts[item - 1]++;
        Console.WriteLine(string.Join("\n", cnts.Take(m).Select((x, y) => $"{y + 1} {x}")));
    }
}