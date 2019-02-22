// detail: https://yukicoder.me/submissions/318946
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

class P
{
    static void Main()
    {
        string s = "";
        var a = Console.ReadLine().Split().Select(int.Parse).ToList();
        foreach (var item in a)
        {
            string t = "";
            if (item % 3 == 0) t += "ffff";
            if (item % 5 == 0) t += "bbbb";
            if (t.Length == 0) t += item.ToString();
            s += t;
        }
        Console.WriteLine(s.Length);
    }
}
