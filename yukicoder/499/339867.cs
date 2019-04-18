// detail: https://yukicoder.me/submissions/339867
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
        string res = n == 0 ? "0" : "";
        while (n != 0)
        {
            res = (n % 7).ToString() + res;
            n /= 7;
        }
        Console.WriteLine(res);
    }
}
