// detail: https://atcoder.jp/contests/abc182/submissions/17976744
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
        var nx = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var x = nx[1];
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();

        var lims = a.Zip(a.Skip(1), (x, y) => y / x).Append(int.MaxValue).ToArray();
        var nums = new long[a.Length];
        for (int i = 0; i < a.Length - 1; i++)
            nums[i] = (x % a[i + 1]) / a[i];
        nums[nums.Length - 1] = x / a[nums.Length - 1];

        long carry = 0;
        long nonCarry = 1;
        foreach (var (num, lim) in nums.Zip(lims))
        {
            long newCarry = 0;
            long newNonCarry = 0;
            {
                if (num != 0)
                {
                    newCarry += nonCarry;
                }
                newNonCarry += nonCarry;
            }
            {
                //if (num != 1)
                if (num != lim - 1)
                {
                    newNonCarry += carry;
                }
                newCarry += carry;
            }
            (carry, nonCarry) = (newCarry, newNonCarry);
        }
        Console.WriteLine(nonCarry);
        //bitが立っている桁が下にあり、きっちり払ってないなら1だけ払える?
    }
}