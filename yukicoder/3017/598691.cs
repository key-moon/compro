// detail: https://yukicoder.me/submissions/598691
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
        var sk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(sk[0] % sk[1]);
    }
}
