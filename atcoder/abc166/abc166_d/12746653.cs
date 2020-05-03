// detail: https://atcoder.jp/contests/abc166/submissions/12746653
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
        var list = new long[1000];
        Dictionary<BigInteger, int> dict = new Dictionary<BigInteger, int>();
        for (int i = 0; ; i++)
        {
            var bigi = (BigInteger)i;
            var pow = bigi * bigi * bigi * bigi * bigi;
            var t = (pow) - n;
            var sign = t < 0 ? -1 : 1;
            var abs = BigInteger.Abs(t);
            if (dict.ContainsKey(abs))
            {
                Console.WriteLine($"{i} {sign * dict[abs]}");
                return;
            }
            dict.Add(pow, i);
        }
    }
}