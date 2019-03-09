// detail: https://codeforces.com/contest/1137/submission/51058471
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        int zeroCount = s.Count(x => x == '0');
        int oneCount = s.Count(x => x == '1');
        string t = Console.ReadLine();
        //tにおいて、どのように取れば良いかみたいなのは欲しいね
        //これなんだけど、末端でしか圧縮は恐らく不可能
        Dictionary<long, int> length = new Dictionary<long, int>();
        const long POW = 31;
        const long MOD = 9999999999999937;
        long currentHash = 0;
        length.Add(currentHash, 0);
        for (int i = 0; i < t.Length; i++)
        {
            currentHash *= POW;
            currentHash += t[i];
            currentHash %= MOD;
            length.Add(currentHash, i + 1);
        }
        currentHash = 0;
        int longestMatch = 0;
        long currentPower = 1;
        for (int i = t.Length - 1; i >= 1; i--)
        {
            currentHash += (currentPower * t[i]) % MOD;
            currentHash %= MOD;
            if (length.ContainsKey(currentHash)) longestMatch = t.Length - i;
            currentPower *= POW;
            currentPower %= MOD;
        }
        StringBuilder builder = new StringBuilder();
        
        if (t.Length == longestMatch)
        {
            t = t.Substring(0, 1);
        }
        else
        {
            string firstSubstr = t.Substring(0, longestMatch);
            int lmZeroCount = firstSubstr.Count(x => x == '0');
            int lmOneCount = firstSubstr.Count(x => x == '1');
            if (zeroCount >= lmZeroCount && oneCount >= lmOneCount)
            {
                builder.Append(firstSubstr);
                zeroCount -= lmZeroCount;
                oneCount -= lmOneCount;
            }
            t = t.Substring(longestMatch);
        }
        

        int tZeroCount = t.Count(x => x == '0');
        int tOneCount = t.Count(x => x == '1');
        while (zeroCount - tZeroCount >= 0 && oneCount - tOneCount >= 0)
        {
            builder.Append(t);
            zeroCount -= tZeroCount;
            oneCount -= tOneCount;
        }
        builder.Append(Enumerable.Repeat('0', zeroCount).ToArray());
        builder.Append(Enumerable.Repeat('1', oneCount).ToArray());
        string resstr = builder.ToString();
        Console.WriteLine(resstr);

    }
}