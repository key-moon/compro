// detail: https://yukicoder.me/submissions/227755
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int last = 0;
        string res = "T";
        for (int i = 0; i < a; i++)
        {
            int p = int.Parse(Console.ReadLine());
            if (Math.Abs(p - last) != 1) res = "F";
            last = p;
        }
        Console.WriteLine(res);
    }
}