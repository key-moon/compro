// detail: https://codeforces.com/contest/1202/submission/58439233
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string x = string.Join("", Console.ReadLine().Reverse());
            string y = string.Join("", Console.ReadLine().Reverse());
            var yLastIndex = y.IndexOf('1');
            var xLastIndex = x.IndexOf('1', yLastIndex);
            Console.WriteLine(xLastIndex - yLastIndex);
        }
    }
}

