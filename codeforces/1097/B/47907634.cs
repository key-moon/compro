// detail: https://codeforces.com/contest/1097/submission/47907634
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        for (int i = 0; i < (1 << n); i++)
        {
            int sum = 0;
            int tmp = i;
            for (int j = 0; j < n; j++)
            {
                sum += (tmp & 1) == 0 ? a[j] : -a[j];
                tmp >>= 1;
            }
            if (sum % 360 == 0)
            {
                Console.WriteLine("YES");
                return;
            }
        }
        Console.WriteLine("NO");
    }
}
