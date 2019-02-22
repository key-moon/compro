// detail: https://yukicoder.me/submissions/318475
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        StringBuilder builder = new StringBuilder();
        builder.Append("A=");
        bool IsFirst = true;
        int max = 1 << n;
        bool IsAllTrue = true;
        for (int i = 0; i < max; i++)
        {
            var q = Console.ReadLine().Split().Select(int.Parse).ToList();
            if (q.Last() != 1)
            {
                IsAllTrue = false;
                continue;
            }
            if (!IsFirst) builder.Append("∨");
            else IsFirst = false;
            builder.Append("(");
            for (int j = 0; j < n; j++)
            {
                if (q[j] == 0) builder.Append("¬");
                builder.Append("P_");
                builder.Append(j + 1);
                if (j != n - 1) builder.Append("∧");
            }
            builder.Append(")");
        }
        if (IsFirst) builder.Append("⊥");
        if (IsAllTrue) Console.WriteLine("A=⊤");
        else Console.WriteLine(builder.ToString());
    }

    static long Power(long n, long m)
    {
        const int mod = 1000000007;
        long pow = n;
        long res = 1;
        while (m > 0)
        {
            if ((m & 1) == 1) res = (res * pow) % mod;
            pow = (pow * pow) % mod;
            m >>= 1;
        }
        return res;
    }
}
