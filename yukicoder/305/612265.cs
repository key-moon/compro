// detail: https://yukicoder.me/submissions/612265
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        char[] res = "0000000000".ToArray();
        int Query()
        {
            Console.WriteLine(res);
            var s = Console.ReadLine().Split();
            if (s[1] == "unlocked") Environment.Exit(0);
            return int.Parse(s[0]);
        }
        var last = Query();
        for (int i = 0; i < 10; i++)
        {
            for (int j = 1; j < 10; j++)
            {
                res[i] = (char)('0' + j);
                var curRes = Query();
                if (curRes != last)
                {
                    if (curRes < last) res[i] = '0';
                    else last = curRes;
                    break;
                }
            }
        }
    }
}
