// detail: https://codeforces.com/contest/1282/submission/68450938
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        char[] s;
        int lastQuery;
        int len;
        {
            var q = Query("a");
            
            if (q == 300) Query(Enumerable.Repeat('b', q).ToArray());

            len = q + 1;
            s = Enumerable.Repeat('a', len).ToArray();
            lastQuery = Query(s);

            if (lastQuery == len)
            {
                Query(Enumerable.Repeat('b', len - 1).ToArray());
                throw new Exception();
            }
        }
        var rng = new Random();
        for (int i = s.Length - 1; i >= 0; i--)
        {
            s[i] = 'b';
            var q = Query(s);
            if (q > lastQuery) s[i] = 'a';
            else lastQuery = q;
        }
        throw new Exception();
    }

    static int Query(char[] s) => Query(string.Join("", s));
    static int Query(string s)
    {
        Console.WriteLine(s);
        var res = int.Parse(Console.ReadLine());
        if (res == 0) Environment.Exit(0);
        if (res == -1) throw new Exception();
        return res;
    }
}
