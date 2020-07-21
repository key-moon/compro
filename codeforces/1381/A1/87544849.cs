// detail: https://codeforces.com/contest/1381/submission/87544849
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
        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine().ToArray();
        var t = Console.ReadLine().ToArray();
        //var d = s.ToArray();
        int begin = 0;
        int end = n - 1;
        bool reversed = false;
        List<int> query = new List<int>();
        for (int i = n - 1; i >= 0; i--)
        {
            if ((s[end] != t[i]) ^ reversed)
            {
                if ((s[begin] == t[i]) ^ reversed)
                {
                    query.Add(1);
                    //Array.Reverse(d, 0, 1);
                    //d = d.Select((_, ind) => (char)(ind < 1 ? _ ^ '0' ^ '1' : _)).ToArray();
                }
                query.Add(i + 1);
                //Array.Reverse(d, 0, i + 1);
                //d = d.Select((_, ind) => (char)(ind <= i ? _ ^ '0' ^ '1' : _)).ToArray();
                var tmp = begin;
                begin = end;
                end = tmp;
                reversed = !reversed;
            }
            end += reversed ? 1 : -1;
           // Console.WriteLine($"{string.Join("", d)} {begin} {end} {reversed}");
        }

        //Console.WriteLine(string.Join("", d));
        if (query.Count == 0) Console.WriteLine(query.Count);
        else Console.WriteLine($"{query.Count} {string.Join(" ", query)}");
    }
}
