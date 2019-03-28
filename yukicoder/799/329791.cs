// detail: https://yukicoder.me/submissions/329791
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;

static class P
{
    static void Main()
    {
        var abcd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rangeA = abcd[1] - abcd[0] + 1;
        int rangeB = abcd[3] - abcd[2] + 1;
        int overRap = Max(0, Min(abcd[3], abcd[1]) - Max(abcd[2], abcd[0]) + 1);
        Console.WriteLine(rangeA * rangeB - overRap);
    }
}
