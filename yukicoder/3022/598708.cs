// detail: https://yukicoder.me/submissions/598708
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
using static System.Numerics.BigInteger;

public static class P
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var three = One + One + One;
        var five = three + One + One;
        for (int i = (int)One; i <= n; i++)
        {
            string s = "";
            if (i % three == Zero) s += "Fizz";
            if (i % five == Zero) s += "Buzz";
            if (s.Length == Zero) s = i.ToString();
            Console.WriteLine(s);
        }
    }
}
