// detail: https://codeforces.com/contest/1/submission/68348189
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
    //static P() { Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false }); }
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var s = Console.ReadLine();
            if (Regex.IsMatch(s, @"^R[0-9]+C[0-9]+$"))
            {
                var rc = s.Substring(1).Split('C').Select(int.Parse).ToArray();
                var r = rc[0];
                var c = rc[1];
                Console.WriteLine($"{Base26(c)}{r}");
            }
            else
            {
                var LetterLength = s.TakeWhile(x => !char.IsDigit(x)).Count();
                var r = int.Parse(s.Substring(LetterLength));
                var c = DecodeBase26(s.Substring(0, LetterLength));
                Console.WriteLine($"R{r}C{c}");
            }
        }
        //Console.Out.Flush();
    }

    public static int DecodeBase26(string self)
    {
        int result = 0;
        char[] chars = self.ToCharArray();
        int len = self.Length - 1;
        foreach (var c in chars)
        {
            int asc = (int)c - 64;
            if (asc < 1 || asc > 26) return 0;
            result += asc * (int)Math.Pow((double)26, (double)len--);
        }
        return result;
    }

    public static string Base26(int self)
    {
        if (self <= 0) return "";

        int n = (self % 26 == 0) ? 26 : self % 26;
        if (self == n) return ((char)(n + 64)).ToString();
        return Base26((self - n) / 26) + ((char)(n + 64)).ToString();
    }
}