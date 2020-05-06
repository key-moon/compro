// detail: https://codeforces.com/contest/1344/submission/79151086
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
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        bool[] rooms = new bool[n];
        for (int i = 0; i < a.Length; i++)
        {
            var room = (a[i] + i) % n;
            if (room < 0) room += n;
            if (rooms[room])
            {
                Console.WriteLine("NO");
                return;
            }
            rooms[room] = true;
        }
        Console.WriteLine("YES");
    }
}