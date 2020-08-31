// detail: https://atcoder.jp/contests/code-festival-2014-morning-easy/submissions/16426039
using System;
using System.Linq;
public static class P
{
    public static void Main() => Console.WriteLine(Enumerable.Repeat(0, 20).Aggregate(Enumerable.Empty<int>(), (x, _) => x.Concat(Enumerable.Range(1, 20).Concat(Enumerable.Range(1, 20).Reverse()))).Take(int.Parse(Console.ReadLine())).Last());
}