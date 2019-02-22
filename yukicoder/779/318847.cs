// detail: https://yukicoder.me/submissions/318847
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
        var ymd = Console.ReadLine().Split().Select(int.Parse).ToList();
        DateTime dt = new DateTime(ymd[0], ymd[1], ymd[2]);
        Console.WriteLine(new DateTime(1989, 1, 8) <= dt && dt <= new DateTime(2019, 4, 30) ? "Yes" : "No");
    }
}
