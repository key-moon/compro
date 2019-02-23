// detail: https://yukicoder.me/submissions/319123
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
        int count = 0;
        int n = int.Parse(Console.ReadLine());
        foreach (var i in new int[] { 2, 3, 5, 7, 11, 13 })
        {
            foreach (var j in new int[] { 4, 6, 8, 9, 10, 12 })
            {
                if (n == i * j) count++;
            }
        }
        Console.WriteLine(count / 36.0);
    }
}
