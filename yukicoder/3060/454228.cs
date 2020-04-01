// detail: https://yukicoder.me/submissions/454228
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;


public static class P
{
    static void Main()
    {
        var s = Console.ReadLine();
        if (s == "0") Console.WriteLine("Nothing");
        else if (s.StartsWith("3.1")) Console.WriteLine("pi");
        else if (s.StartsWith("111234"))
        {
            Console.WriteLine("九蓮宝燈");
            Console.WriteLine("Thirteen Orphans");
        }
        else if (s.StartsWith("All your base"))
        {
            Console.WriteLine(@"3
4
4
3
6
2
2");
        }
        else if (s.StartsWith("くぁ"))
        {
            Console.WriteLine("さｍｐぇ");
        }
    }
}
