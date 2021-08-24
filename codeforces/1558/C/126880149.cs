// detail: https://codeforces.com/contest/1558/submission/126880149
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

        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
        Console.Out.Flush();
    }
    static int n;
    static List<int> A;
    static List<int> res = new List<int>();
    static void Solve()
    {
        n = int.Parse(Console.ReadLine());
        A = Console.ReadLine().Split().Select(int.Parse).Select(x => x - 1).ToList();
        res.Clear();
        if (A.Where((elem, ind) => elem % 2 != ind % 2).Any())
        {
            Console.WriteLine(-1);
            return;
        }
        for (int i = n - 1; i > 0; i -= 2)
        {
            // dest: xxx...xxxba
            var a = i;
            var b = i - 1;
            // x..xax..xbx...x
            Query(A.IndexOf(a) + 1);
            // ax...xbx...x
            Query(A.IndexOf(b));
            // x...xabx...x
            Query(i + 1);
            // x...xbax...x
            Query(A.IndexOf(a) + 1);
            // abx...x
            Query(i + 1);
            // x...xba
        }
        Trace.Assert(res.Count <= 5 * n / 2);
        Trace.Assert(!A.Where((elem, ind) => elem != ind).Any());
        Console.WriteLine(res.Count);
        Console.WriteLine(string.Join(" ", res));
    }
    static void Query(int len)
    {
        if (len == 1) return;
        res.Add(len);
        A.Reverse(0, len);
    }
}