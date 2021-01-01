// detail: https://yukicoder.me/submissions/598840
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
using static System.Numerics.BigInteger;

public static class P
{
    public static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int curStreak = 0;
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            if (a[i] % 2 == 1)
            {
                curStreak++;
                sum += a[i];
            }
            else
            {
                if (m <= curStreak) Console.WriteLine(sum);
                curStreak = 0;
                sum = 0;
            }
        }
        if (m <= curStreak) Console.WriteLine(sum);
    }
}
