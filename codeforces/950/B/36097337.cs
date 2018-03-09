// detail: https://codeforces.com/contest/950/submission/36097337
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        Console.ReadLine();
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int aind = 1;
        int bind = 0;
        int current = a[0];
        int res = 0;
        while (true)
        {
            Debug.WriteLine(current);
            if (current >= 0 && bind < b.Length)
            {
                current -= b[bind];
                bind++;
            }
            else if (current <= 0 && aind < a.Length)
            {
                current += a[aind];
                aind++;
            }
            else
            {
                break;
            }
            if (current == 0)
            {
                res++;
            }
        }
        Console.WriteLine(res);

    }
}