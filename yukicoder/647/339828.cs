// detail: https://yukicoder.me/submissions/339828
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
        var ab = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int m = int.Parse(Console.ReadLine());
        var xy = Enumerable.Repeat(0, m).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();

        List<int> res = new List<int>();
        int currentMax = 0;
        for (int i = 0; i < m; i++)
        {
            var x = xy[i][0];
            var y = xy[i][1];
            int count = 0;
            for (int j = 0; j < n; j++)
            {
                if (x <= ab[j][0] && ab[j][1] <= y) count++;
            }
            if (currentMax < count)
            {
                res = new List<int>();
                currentMax = count;
            }
            if (currentMax == count)
            {
                res.Add(i + 1);
            }
        }
        Console.WriteLine(currentMax == 0 ? "0" : string.Join("\n", res));
    }
}
