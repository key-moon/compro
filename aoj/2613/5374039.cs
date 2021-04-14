// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2613/judge/5374039/C#
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
        string s = Console.ReadLine();
        long res = long.MinValue;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    List<char>[] orders =
                    {
                        new List<char>(),
                        new List<char>(),
                        new List<char>()
                    };
                    orders[i].Add('+');
                    orders[j].Add('-');
                    orders[k].Add('*');
                    Orders = orders.Select(x => x.ToArray()).ToArray();
                    int ind = 0;
                    res = Max(res, Parse(s, ref ind));
                }
            }
        }
        Console.WriteLine(res);
    }
    static char[][] Orders;
    static long Parse(string s, ref int ind)
    {
        List<long> numbers = new List<long>();
        List<char> ops = new List<char>();
        while (ind < s.Length)
        {
            long cur = 0;
            if (s[ind] == '(')
            {
                ind++;
                cur = Parse(s, ref ind);
            }
            else
            {
                while (ind < s.Length && char.IsDigit(s[ind]))
                {
                    cur = cur * 10 + (s[ind] - '0');
                    ind++;
                }
            }
            numbers.Add(cur);
            if (s.Length <= ind) break;
            if (s[ind] == ')') { ind++; break; }
            ops.Add(s[ind]);
            ind++;
        }
        if (numbers.Count - 1 != ops.Count) throw new Exception();
        foreach (var order in Orders)
        {
            for (int i = 0; i < ops.Count; i++)
            {
                if (!order.Contains(ops[i])) continue;
                var op = ops[i];
                ops.RemoveAt(i);
                var a = numbers[i];
                numbers.RemoveAt(i);
                var b = numbers[i];
                numbers.RemoveAt(i);
                long res;
                switch (op)
                {
                    case '+':
                        res = a + b;
                        break;
                    case '-':
                        res = a - b;
                        break;
                    case '*':
                        res = a * b;
                        break;
                    default:
                        throw new Exception();
                }
                numbers.Insert(i, res);
                i--;
            }
        }
        if (numbers.Count != 1) throw new Exception();
        return numbers.Last();
    }
}

