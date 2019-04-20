// detail: https://codeforces.com/contest/1146/submission/53058858
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        int count = s.Count(x => x == 'a');
        var a = s.Substring(0, (s.Length - count) / 2 + count);
        var b = s.Substring((s.Length - count) / 2 + count);
        if(string.Join("",a.Where(x => x != 'a')) == b)
        {
            Console.WriteLine(a);
        }
        else
        {
            Console.WriteLine(":(");
        }
    }
}
