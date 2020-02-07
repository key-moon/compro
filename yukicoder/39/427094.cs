// detail: https://yukicoder.me/submissions/427094
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
        var s = Console.ReadLine();
        var res = new List<long>() { long.Parse(s) };
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i + 1; j < s.Length; j++)
            {
                var newS = s.ToArray();
                var tmp = newS[i];
                newS[i] = newS[j];
                newS[j] = tmp;
                res.Add(long.Parse(string.Join("", newS)));
            }
        }
        Console.WriteLine(res.Max());
    }
}