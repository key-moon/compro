// detail: https://yukicoder.me/submissions/613705
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        string Stupid(int n, int target)
        {
            for (int b = 0; b < (1 << n); b++)
            {
                var s = Convert.ToString(b, 2).PadLeft(n, '0');
                int maxLen = 0;
                for (int i = 0; i < n; i++)
                {
                    int len = -1;
                    for (int j = i, k = i; 0 <= j && k < s.Length; j--, k++)
                    {
                        if (s[j] != s[k]) break;
                        len += 2;
                    }
                    maxLen = Max(maxLen, len);
                }
                for (int i = 0; i < n - 1; i++)
                {
                    int len = 0;
                    for (int j = i, k = i + 1; 0 <= j && k < s.Length; j--, k++)
                    {
                        if (s[j] != s[k]) break;
                        len += 2;
                    }
                    maxLen = Max(maxLen, len);
                }
                if (maxLen == target)
                {
                    return s;
                }
            }
            return null;
        }
        string res;
        if (n < 10) res = Stupid(n, k);
        else
        {
            if (k < 4) res = null;
            else
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < k; i++) builder.Append('0');
                while (builder.Length < n) builder.Append("101100");
                res = builder.ToString().Substring(0, n);
            }
        }
        Console.WriteLine(res ?? "-1");
    }
}
