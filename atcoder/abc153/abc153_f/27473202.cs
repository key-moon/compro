// detail: https://atcoder.jp/contests/abc153/submissions/27473202
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
        var nda = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nda[0];
        var d = nda[1];
        var a = nda[2];
        var poses = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).OrderBy(x => x[0]).ToArray();
        long used = 0;
        long bombDmg = 0;
        Queue<(long, long)> bombEnds = new Queue<(long, long)>();
        foreach (var pos in poses)
        {
            var x = pos[0];
            var h = pos[1];
            while (bombEnds.Count != 0 && bombEnds.Peek().Item1 < x)
            {
                bombDmg -= bombEnds.Dequeue().Item2 * a;
            }
            var newBomb = Max((h - bombDmg + a - 1) / a, 0);
            used += newBomb;
            bombDmg += newBomb * a;
            bombEnds.Enqueue((x + 2 * d, newBomb));
        }
        Console.WriteLine(used);
    }
}