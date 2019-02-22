// detail: https://yukicoder.me/submissions/318661
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

class P
{
    static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToList();
        var a = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToList();
        //なんやこれ DP?
        long res = 1;
        for (int i = 0; i < a.Count / 2; i++)
        {
            int pairMax = nk[1] - a[i];
            int valid = a.Count - 1;
            int invalid = i;
            if (pairMax < a[valid])
            {
                res *= 0;
                break;
            }
            if (a[invalid] <= pairMax)
            {
                res *= a.Count - i * 2 - 1;//自分を除外しないといけないため
                res %= 1000000007;
                continue;
            }

            while (valid - invalid > 1)
            {
                var mid = (valid + invalid) / 2;
                if (a[mid] <= pairMax) valid = mid;
                else invalid = mid;
            }
            if (a.Count - valid <= i)
            {
                res *= 0;
                break;
            }
            res *= (a.Count - valid - i);
            res %= 1000000007;
        }
        Console.WriteLine(res);
    }
}
