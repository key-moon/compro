// detail: https://yukicoder.me/submissions/339880
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        var countA = s.Count(x => x == 'A');
        int res = -countA * (countA - 1) / 2;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'A') res += i;
        }
        Console.WriteLine(res);
    }
}
