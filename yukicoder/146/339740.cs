// detail: https://yukicoder.me/submissions/339740
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


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(Enumerable.Repeat(0, n).Sum(_ => { var s = Console.ReadLine().Split().Select(long.Parse).ToArray(); return (((s[0] + 1) / 2 % 1000000007) * (s[1] % 1000000007)) % 1000000007; }) % 1000000007);
    }
}