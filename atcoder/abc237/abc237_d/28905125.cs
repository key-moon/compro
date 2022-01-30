// detail: https://atcoder.jp/contests/abc237/submissions/28905125
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
        List<int> l = new List<int>();
        List<int> r = new List<int>();
        foreach (var (elem, ind) in Console.ReadLine().Select((elem, ind) => (elem, ind)).Reverse())
        {

            (elem == 'R' ? l : r).Add(ind);
        }
        l.Reverse();

        Console.WriteLine(string.Join(" ", l.Append(n).Concat(r)));
    }
}