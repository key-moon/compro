// detail: https://codeforces.com/contest/1020/submission/41475529
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nhabk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < nhabk[4]; i++)
        {
            int[] tftf = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int p = 0;
            if (tftf[0] == tftf[2])
            {
                p = Abs(tftf[1] - tftf[3]);
            }
            else
            {
                if (Max(tftf[1], tftf[3]) <= nhabk[2])
                {
                    p = (Abs(nhabk[2] - tftf[1]) + Abs(nhabk[2] - tftf[3]));
                }
                else if (Min(tftf[1], tftf[3]) >= nhabk[3])
                {
                    p = (Abs(tftf[1] - nhabk[3]) + Abs(tftf[3] - nhabk[3]));
                }
                else
                {
                    p = Abs(tftf[1] - tftf[3]);
                }
            }
            int t = Abs(tftf[0] - tftf[2]);
            Console.WriteLine(t + p);
        }
    }
}