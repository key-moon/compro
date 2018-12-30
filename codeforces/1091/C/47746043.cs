// detail: https://codeforces.com/contest/1091/submission/47746043
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        //すべての因数について試す?1
        //
        List<long> res = new List<long>();
        int sqrtn = (int)Ceiling(Sqrt(n));
        for (long i = 1; i <= sqrtn; i++)
        {
            if(n % i == 0)
            {
                long count = n / i;
                res.Add(((count) * (count - 1) / 2) * i + count);
                res.Add(((i) * (i - 1) / 2) * count + i);
            }
        }
        Console.WriteLine(string.Join(" ", res.Distinct().OrderBy(x => x)));
    }
}
