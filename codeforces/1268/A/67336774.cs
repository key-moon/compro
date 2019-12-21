// detail: https://codeforces.com/contest/1268/submission/67336774
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
        string s = Console.ReadLine();
        var top = s.Substring(0, k);
        var incremented = Increment(top);
        var cand1 = string.Join("", Enumerable.Repeat(top, n / k + 1)).Substring(0, n);
        var cand2 = string.Join("", Enumerable.Repeat(incremented, n / k + 1)).Substring(0, n);
        Console.WriteLine(n);
        if (s.CompareTo(cand1) <= 0) Console.WriteLine(cand1);
        else Console.WriteLine(cand2);
    }
    public static string Increment(string s)
    {
        bool carry = true;
        char[] arr = new char[s.Length];
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (carry)
            {
                if (s[i] == '9') arr[i] = '0';
                else
                {
                    arr[i] = (char)(s[i] + 1);
                    carry = false;
                }
            }
            else arr[i] = s[i];
        }
        return string.Join("", arr);
    }
}
