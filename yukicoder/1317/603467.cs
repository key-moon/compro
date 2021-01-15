// detail: https://yukicoder.me/submissions/603467
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
        var verdicts = new[] { "AC", "WA", "TLE", "MLE", "OLE", "RE" };
        for (int i = 0; i < n; i++)
        {
            var res1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var res2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var x = Array.IndexOf(verdicts, Console.ReadLine());
            var res = res2.Where((elem, ind) => ind != 0 && ind != x).All(x => x == 0) && res1[x] == 0;
            Console.WriteLine(res ? "Yes" : "No");
        }
    }
}
