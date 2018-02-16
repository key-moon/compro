// detail: https://codeforces.com/contest/938/submission/35342887
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        Console.ReadLine();
        string s = Console.ReadLine();
        List<char> res = new List<char>() { s[0] };
        for (int i = 1; i < s.Length; i++)
        {
            if (!isboin(res.Last()) || !isboin(s[i])) res.Add(s[i]);
        }
        Console.WriteLine(string.Join("",res));
    }
    static bool isboin(char c) => new char[] { 'a', 'e', 'i', 'o', 'u', 'y' }.Contains(c);
}