// detail: https://yukicoder.me/submissions/339869
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
        int n = int.Parse(Console.ReadLine());
        int place = 1;
        int score = int.Parse(Console.ReadLine());
        Console.WriteLine(place);
        for (int i = 1; i < n; i++)
        {
            if (score < int.Parse(Console.ReadLine())) place++;
            Console.WriteLine(place);
        }
    }
}
