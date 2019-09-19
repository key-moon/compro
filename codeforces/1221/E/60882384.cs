// detail: https://codeforces.com/contest/1221/submission/60882384
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        int q = int.Parse(Console.ReadLine());
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < q; i++)
        {
            builder.AppendLine(Solve() ? "YES" : "NO");
        }
        Console.Write(builder.ToString());
    }

    static bool Solve()
    {
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = ab[0];
        var b = ab[1];
        string s = Console.ReadLine();
        int current = 0;
        int max = 0;
        int count = 0;
        int generatableCount = 0;

        //bだけ取れるのがあったらすでに負け
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'X')
            {
                if (b <= current)
                {
                    if (a <= current)
                    {
                        max = Max(max, current);
                        count++;
                    }
                    if (current < a) return false;
                    if (2 * b <= current) generatableCount++;
                }
                current = 0;
            }
            else
            {
                current++;
            }
        }
        if (b <= current)
        {
            if (a <= current)
            {
                max = Max(max, current);
                count++;
            }
            if (current < a) return false;
            if (2 * b <= current) generatableCount++;
        }
        //bだけ取れるのを生成できる要素が2個以上あったら負け
        if (2 <= generatableCount) return false;

        //取れるものがなかったら負け 当たり前だよね
        if (count == 0) return false;
        //取り出すわけなのでね
        count--;
        //ここで、残りはaもbも取れる奴で、取ったら何も残らないやつだけ
        for (int i = 0; i <= max - a; i++)
        {
            var other = max - i - a;
            //残るやつが地雷だったら駄目
            if ((b <= other && other < a) || (b <= i && i < a)) continue;
            if (2 * b <= other || 2 * b <= i) continue;
            //残ってる奴で取れるのを含めて偶数個だったら良い
            var remainCount = count;
            if (a <= i) remainCount++;
            if (a <= other) remainCount++;
            if ((remainCount & 1) == 0) return true;
        }
        return false;
    }
}
