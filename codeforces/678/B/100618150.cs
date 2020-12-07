// detail: https://codeforces.com/contest/678/submission/100618150
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
        int n = int.Parse(Console.ReadLine());
        var y = n % 400 + 2000;
        DateTime start = new DateTime(y, 12, 31);
        while (true)
        {
            y++;
            n++;
            var cur = new DateTime(y, 12, 31);
            if (start.DayOfYear == cur.DayOfYear &&
                start.DayOfWeek == cur.DayOfWeek)
            {
                Console.WriteLine(n);
                return;
            }
        }
    }
}