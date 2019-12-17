// detail: https://codeforces.com/contest/1266/submission/67098891
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var debt = new long[n];
        for (int i = 0; i < m; i++)
        {
            var abx = Console.ReadLine().Split().Select(int.Parse).ToArray();
            debt[abx[0] - 1] += abx[2];
            debt[abx[1] - 1] += -abx[2];
        }
        var debts = debt.Select((x, y) => new Debt { Item1 = x, ID = y + 1 }).ToArray();
        var borrowers = new Stack<Debt>(debts.Where(x => x.Item1 < 0));
        var lenders = new Stack<Debt>(debts.Where(x => x.Item1 > 0));
        List<string> res = new List<string>();
        while (borrowers.Count > 0)
        {
            var borrower = borrowers.Pop();
            while (borrower.Item1 < 0)
            {
                var lender = lenders.Pop();
                //返済しきれない
                if (borrower.Item1 + lender.Item1 < 0)
                {
                    res.Add($"{lender.ID} {borrower.ID} {lender.Item1}");
                    borrower.Item1 += lender.Item1;
                }
                else
                {
                    res.Add($"{lender.ID} {borrower.ID} {-borrower.Item1}");
                    lender.Item1 += borrower.Item1;
                    if (lender.Item1 != 0) lenders.Push(lender);
                    break;
                }
            }
        }
        Console.WriteLine(res.Count);
        Console.WriteLine(string.Join("\n", res));
    }
}

class Debt
{
    public long Item1;
    public int ID;
}
