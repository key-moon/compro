// detail: https://atcoder.jp/contests/arc024/submissions/11757699
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var s = Console.ReadLine();
        HashSet<string> set = new HashSet<string>();
        int[] curCount = new int[26];
        for (int i = 0; i < k; i++) curCount[s[i] - 'a']++;
        Queue<string> queue = new Queue<string>();
        queue.Enqueue(curCount.Encode());
        for (int i = k; i < n; i++)
        {
            curCount[s[i - k] - 'a']--;
            curCount[s[i] - 'a']++;
            var encoded = curCount.Encode();
            queue.Enqueue(encoded);
            if (queue.Count > k) set.Add(queue.Dequeue());
            if (set.Contains(encoded))
            {
                Console.WriteLine("YES");
                return;
            }
        }
        Console.WriteLine("NO");
    }
    public static string Encode(this int[] count) => string.Join("/", count);
}