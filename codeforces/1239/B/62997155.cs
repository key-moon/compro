// detail: https://codeforces.com/contest/1239/submission/62997155
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();

        if (s.Count(x => x == '(') * 2 != n)
        {
            Console.WriteLine("0\n1 1");
            return;
        }

        int minPoint = 0;
        int minDepth = 0;
        int depth = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (depth < minDepth)
            {
                minPoint = i;
                minDepth = depth;
            }
            depth += s[i] == '(' ? 1 : -1;
        }
        s = s.Substring(minPoint) + s.Substring(0, minPoint);

        depth = 0;
        var zeroCount = 0;
        var curInCount = 0;
        var curInInCount = 0;
        var curInInStart = 0;
        var curInInEnd = 0;
        var ininPreMax = -1;
        var ininPreStart = 0;
        var ininPreEnd = 0;
        var ininMax = -1;
        var ininStart = 0;
        var ininEnd = 0;
        var curStart = -1;
        var curEnd = -1;
        var curMax = -1;
        var maxStart = -1;
        var maxEnd = -1;
        for (int i = 0; i < s.Length; i++)
        {
            depth += s[i] == '(' ? 1 : -1;
            //1
            //(
            if (depth == 1 && s[i] == '(')
            {
                curStart = i;
            }
            //10
            //()
            if (depth == 0 && s[i] == ')')
            {
                zeroCount++;
                curEnd = i;
                if (curMax < curInCount)
                {
                    curMax = curInCount;
                    maxStart = curStart;
                    maxEnd = curEnd;
                }
                if (1 <= curInCount && ininMax < ininPreMax)
                {
                    ininMax = ininPreMax;
                    ininStart = ininPreStart;
                    ininEnd = ininPreEnd;
                }
                ininPreMax = -1;
                ininPreStart = 0;
                ininPreEnd = 0;
                
                curInCount = 0;
            }
            //12
            //((
            else if (depth == 2 && s[i] == '(')
            {
                curInInStart = i;
            }
            //12321
            //((())
            else if (depth == 1 && s[i] == ')')
            {
                curInCount++;
                curInInEnd = i;
                if (ininPreMax < curInInCount)
                {
                    ininPreMax = curInInCount;
                    ininPreStart = curInInStart;
                    ininPreEnd = curInInEnd;
                }
                curInInCount = 0;
            }
            //1232
            //((()
            else if (depth == 2 && s[i] == ')')
            {
                curInInCount++;
            }
        }

        maxStart += minPoint;
        maxEnd += minPoint;
        maxStart %= n;
        maxEnd %= n;

        ininStart += minPoint;
        ininEnd += minPoint;
        ininStart %= n;
        ininEnd %= n;
        if (curMax + 1 <= zeroCount + ininMax + 1)
        {
            Console.WriteLine(zeroCount + ininMax + 1);
            Console.WriteLine($"{ininStart + 1} {ininEnd + 1}");
        }
        else
        {
            Console.WriteLine(curMax + 1);
            Console.WriteLine($"{maxStart + 1} {maxEnd + 1}");
        }
        }
}
