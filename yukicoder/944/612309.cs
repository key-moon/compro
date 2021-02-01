// detail: https://yukicoder.me/submissions/612309
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var sum = a.Sum();
        int res = 0;
        bool Validate(int sum)
        {
            int cur = 0;
            for (int i = 0; i < a.Length; i++)
            {
                cur += a[i];
                if (sum < cur) return false;
                if (sum == cur) cur = 0;
            }
            return cur == 0;
        }
        for (int i = 1; i * i <= sum; i++)
        {
            if (sum % i != 0) continue;
            if (Validate(i)) res = Max(res, sum / i);
            if (Validate(sum / i)) res = Max(res, i);
        }
        Console.WriteLine(res);
    }
}