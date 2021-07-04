// detail: https://atcoder.jp/contests/abc208/submissions/23984516
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
        var nk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        List<long> values = new List<long>() { 1 };
        foreach (var p in new int[] { 2, 3, 5, 7 })
        {
            List<long> newValues = new List<long>();
            foreach (var v in values)
            {
                var curV = v;
                while (curV <= k)
                {
                    newValues.Add(curV);
                    curV *= p;
                }
            }
            values = newValues;
        }
        values.Add(0);
        values.Add(int.MaxValue);
        Dictionary<long, long> borderCnt = values.ToDictionary(x => x, _ => 0L);
        Dictionary<long, long> lowerCnt = values.ToDictionary(x => x, _ => 0L);
        bool highest = true;
        var nStr = n.ToString();
        foreach (var c in nStr)
        {
            Dictionary<long, long> nxtBorderCnt = values.ToDictionary(x => x, _ => 0L);
            Dictionary<long, long> nxtLowerCnt = values.ToDictionary(x => x, _ => 0L);
            var dig = c - '0';
            if (highest)
            {
                for (int i = 1; i <= 10; i++)
                {
                    var prod = i;
                    if (k < prod) prod = int.MaxValue;
                    if (i < dig) nxtLowerCnt[prod]++;
                    if (i == dig) nxtBorderCnt[prod]++;
                }
                highest = false;
            }
            else
            {
                for (int i = 1; i < 10; i++)
                {
                    var prod = i;
                    if (k < prod) prod = int.MaxValue;
                    nxtLowerCnt[prod]++;
                }
            }
            foreach (var v in values)
            {
                for (int i = 0; i < 10; i++)
                {
                    var prod = v * i;
                    if (k < prod) prod = int.MaxValue;
                    if (i < dig) { nxtLowerCnt[prod] += lowerCnt[v]; nxtLowerCnt[prod] += borderCnt[v]; }
                    if (i == dig) { nxtLowerCnt[prod] += lowerCnt[v]; nxtBorderCnt[prod] += borderCnt[v]; }
                    if (i > dig) { nxtLowerCnt[prod] += lowerCnt[v]; }
                }
            }
            borderCnt = nxtBorderCnt;
            lowerCnt = nxtLowerCnt;
        }
        Console.WriteLine(lowerCnt.Concat(borderCnt).Where(x => x.Key <= k).Sum(x => x.Value));
    }
}