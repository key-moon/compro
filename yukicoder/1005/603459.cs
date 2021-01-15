// detail: https://yukicoder.me/submissions/603459
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
        var t = Console.ReadLine();
        if (t.Length == 1 && s.Contains(t))
        {
            Console.WriteLine(-1);
            return;
        }
        var res = "";
        foreach (var item in s)
        {
            if ((res + item).EndsWith(t)) res += '.';
            res += item;
        }
        
        Console.WriteLine(res.Length - s.Length);
    }
}