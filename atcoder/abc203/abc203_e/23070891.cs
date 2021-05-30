// detail: https://atcoder.jp/contests/abc203/submissions/23070891
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
        Dictionary<int, Dictionary<int, bool>> pawn = new Dictionary<int, Dictionary<int, bool>>();
        var pawns = Enumerable.Repeat(0, m).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => (x[0], x[1])).ToArray();
        HashSet<int> reachable = new HashSet<int>() { n };
        foreach (var group in pawns.GroupBy(x => x.Item1).OrderBy(x => x.Key))
        {
            List<int> toRemove = new List<int>();
            List<int> toAdd = new List<int>();
            foreach (var (_, j) in group)
            {
                if (reachable.Contains(j)) toRemove.Add(j);
                if (reachable.Contains(j + 1) || 
                    reachable.Contains(j - 1)) toAdd.Add(j);
            }
            foreach (var item in toRemove) reachable.Remove(item);
            foreach (var item in toAdd) reachable.Add(item);
        }
        Console.WriteLine(reachable.Count);
    }
}