// detail: https://yukicoder.me/submissions/426376
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var s = Console.ReadLine().OrderByDescending(x => x).ToArray();
        var ind = Array.IndexOf(s, s.Last());
        if (ind == 0)
        {
            Console.WriteLine(-1);
            return;
        }
        var tmp = s[ind];
        s[ind] = s[ind - 1];
        s[ind - 1] = tmp;
        var res = string.Join("", s);
        if (res[0] == '0')
        {
            Console.WriteLine(-1);
            return;
        }
        Console.WriteLine(res);
    }
}