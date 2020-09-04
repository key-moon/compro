// detail: https://yukicoder.me/submissions/547516
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        for (int i = 0; i < a.Length; i++)
        {
            if (i + 1 < a[i])
            {
                Console.WriteLine("No");
                return;
            }
        }
        long add = 0;
        for (int i = a.Length - 1; i >= 0; i--)
        {
            if ((a[i] + add) % (i + 1) != 0)
            {
                Console.WriteLine("No");
                return;
            }
            add += (a[i] + add) / (i + 1);
        }
        Console.WriteLine("Yes");
    }
}