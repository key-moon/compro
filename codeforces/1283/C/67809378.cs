// detail: https://codeforces.com/contest/1283/submission/67809378
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool[] recieved = new bool[n];
        for (int i = 0; i < a.Length; i++) if (a[i] != 0) recieved[a[i] - 1] = true;
        var zeros = a.Select((elem, ind) => new { elem, ind }).Where(x => x.elem == 0).Select(x => x.ind).ToArray();
        var unrecieved = recieved.Select((elem, ind) => new { elem, ind }).Where(x => !x.elem).Select(x => x.ind + 1).Reverse().ToArray();
        for (int i = 0; i < zeros.Length; i++)
        {
            a[zeros[i]] = unrecieved[i];
            if (unrecieved[i] - 1 == zeros[i])
            {
                if (i == 0)
                {
                    a[zeros[i + 1]] = a[zeros[i]];
                    a[zeros[i]] = unrecieved[i + 1];
                    i++;
                    continue;
                }
                var tmp = a[zeros[i]];
                a[zeros[i]] = a[zeros[i - 1]];
                a[zeros[i - 1]] = tmp;
            }
        }
        Console.WriteLine(string.Join(" ", a));
    }
}
