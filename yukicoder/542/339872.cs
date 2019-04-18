// detail: https://yukicoder.me/submissions/339872
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
        List<int> res = new List<int>();
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i <= ab[0]; i++)
        {
            for (int j = 0; j <= ab[1]; j++)
            {
                res.Add(i + j * 5);
            }
        }
        Console.WriteLine(string.Join("\n", res.Distinct().Where(x => x != 0).OrderBy(x => x)));
    }
}
