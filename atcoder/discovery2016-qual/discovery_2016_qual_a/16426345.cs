// detail: https://atcoder.jp/contests/discovery2016-qual/submissions/16426345
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
        var s = "DiscoPresentsDiscoveryChannelProgrammingContest2016";
        int n = int.Parse(Console.ReadLine());
        while (s.Length != 0)
        {
            var len = Min(s.Length, n);
            Console.WriteLine(s.Substring(0, len));
            s = s.Substring(len);
        }
    }
}