// detail: https://codeforces.com/contest/1515/submission/114867699
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        var nx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nx[0];
        var x = nx[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        if (a.Sum() == x)
        {
            Console.WriteLine("NO");
            return;
        }
        Console.WriteLine("YES");
        var sum = 0;
        List<int> res = new List<int>();
        for (int i = 0; i < a.Length; i++)
        {
            if (sum + a[i] == x)
            {
                sum += a[i + 1];
                res.Add(a[i + 1]);
                sum += a[i];
                res.Add(a[i]);
                i++;
            }
            else
            {
                sum += a[i];
                res.Add(a[i]);
            }
        }
        Console.WriteLine(string.Join(" ", res));
    }
}