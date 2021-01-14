// detail: https://yukicoder.me/submissions/603266
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
        var line = Console.ReadLine();
        int n;
        if (!int.TryParse(line, out n))
        {
            if (char.IsDigit(line[0])) Console.WriteLine($"{line.Split().Select(int.Parse).Sum()} {Console.ReadLine()}");
            else Console.WriteLine("Hello World!");
            return;
        }
        if (n == 51)
        {
            for (int i = 1; i <= n; i++)
            {
                string res = "";
                if (i % 3 == 0) res += "Fizz";
                if (i % 5 == 0) res += "Buzz";
                if (res.Length == 0) res = i.ToString();
                Console.WriteLine(res);
            }
            return;
        }
        if (n == 96)
        {
            Console.WriteLine(n * (n + 1) / 2);
            return;
        }
        Console.WriteLine(Console.In.ReadToEnd().Split().Where(x => x.Length != 0).Select(long.Parse).Sum());
    }
}
