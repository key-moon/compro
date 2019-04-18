// detail: https://yukicoder.me/submissions/339875
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        var sqrt = (int)Ceiling(Sqrt(n));
        HashSet<string> candidate = new HashSet<string>();
        for (int i = 1; i <= sqrt; i++)
        {
            if (n % i == 0)
            {
                candidate.Add($"{n / i}{i}");
                candidate.Add($"{i}{n / i}");
            }
        }
        Console.WriteLine(candidate.Count);
    }
}
