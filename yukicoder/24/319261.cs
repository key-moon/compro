// detail: https://yukicoder.me/submissions/319261
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Int = System.Int64;
using Debug = System.Diagnostics.Debug;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int> b = new List<int>(Enumerable.Repeat(0, 10));
        int t = 0;
        for (int i = 0; i < n; i++)
        {
            var a = Console.ReadLine().Split();
            if(a[4] == "YES")
            {
                t++;
                b[a[0][0] - '0']++;
                b[a[1][0] - '0']++;
                b[a[2][0] - '0']++;
                b[a[3][0] - '0']++;
            }
            else
            {
                b[a[0][0] - '0']--;
                b[a[1][0] - '0']--;
                b[a[2][0] - '0']--;
                b[a[3][0] - '0']--;
            }
        }
        Console.WriteLine(b.IndexOf(t));
    }
}
