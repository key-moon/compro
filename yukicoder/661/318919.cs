// detail: https://yukicoder.me/submissions/318919
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
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int a = int.Parse(Console.ReadLine());
            string s = "";
            if (a % 8 == 0) s += "iki";
            if (a % 10 == 0) s += "sugi";
            if (s == "") s = (a / 3).ToString();
            Console.WriteLine(s);
        }
    }
}
