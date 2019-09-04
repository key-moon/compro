// detail: https://codeforces.com/contest/1214/submission/59987925
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        if (n % 2 == 1 || s.Count(x => x == '(') != n / 2)
        {
            Console.WriteLine("No");
            return;
        }
        int depth = 0;
        bool taken = false;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(') depth++;
            else depth--;
            if (depth < 0)
            {
                if (taken)
                {
                    Console.WriteLine("No");
                    return;
                }
                taken = true;
                depth++;
            }
        }
        if (taken && depth == 1)
        {
            taken = false;
            depth--;
        }
        Console.WriteLine(!taken && depth == 0 ? "Yes" : "No");
    }


    static readonly TextReader In = Console.In;
    static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0;
            int next = In.Read();
            int rev = 1;
            while (45 > next || next > 57) next = In.Read();
            if (next == 45) { next = In.Read(); rev = -1; }
            while (48 <= next && next <= 57)
            {
                res = res * 10 + next - 48;
                next = In.Read();
            }
            return res * rev;
        }
    }
}
