// detail: https://codeforces.com/contest/1016/submission/41168647
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nmq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string s = Console.ReadLine();
        string t = Console.ReadLine();
        if (t.Length > s.Length)
        {
            for (int i = 0; i < nmq[2]; i++)
            {
                Console.ReadLine();
                Console.WriteLine(0);
            }
            return;
        }
        int[] a = new int[s.Length - t.Length + 1];
        //全Tの出る位置を確認
        for (int i = 0; i < s.Length - t.Length + 1; i++)
        {
            a[i] = s.Substring(i, t.Length) == t ? 1 : 0;
        }
        int[] ruiseki = new int[a.Length + 2];
        for (int i = 0; i < a.Length; i++)
        {
            ruiseki[i + 1] = ruiseki[i] + a[i];
        }
        for (int i = 0; i < nmq[2]; i++)
        {
            int[] ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (ab[1] - t.Length + 1 <= ab[0] - 1)
            {
                Console.WriteLine(0);
                continue;
            }

            Console.WriteLine(ruiseki[ab[1] - t.Length + 1] - ruiseki[ab[0] - 1]);
        }
    }
}