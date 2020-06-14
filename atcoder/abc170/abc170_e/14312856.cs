// detail: https://atcoder.jp/contests/abc170/submissions/14312856
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
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nq[0];
        var q = nq[1];
        int[] currentSchool = new int[n];
        long[] encoded = new long[n];
        SortedSet<long> set = new SortedSet<long>();
        SortedSet<long>[] school = Enumerable.Range(0, 200000).Select(_ => new SortedSet<long>()).ToArray();
        long encode(long rate, long id) => (rate << 30) + id;
        (long rate, long id) decode(long encoded) => (encoded >> 30, encoded & ((1 << 30) - 1));
        for (int i = 0; i < n; i++)
        {
            var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            currentSchool[i] = ab[1] - 1;
            school[ab[1] - 1].Add(encoded[i] = encode(ab[0], i));
        }
        SortedSet<long> tops = new SortedSet<long>();
        for (int i = 0; i < school.Length; i++)
            if (school[i].Count != 0) tops.Add(school[i].Max);
        for (int i = 0; i < q; i++)
        {
            var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var id = ab[0] - 1;
            var newSchool = ab[1] - 1;

            var oldSchool = currentSchool[id];

            tops.Remove(school[oldSchool].Max);
            if (school[newSchool].Count != 0) tops.Remove(school[newSchool].Max);

            school[oldSchool].Remove(encoded[id]);
            school[newSchool].Add(encoded[id]);

            if (school[currentSchool[id]].Count != 0) tops.Add(school[currentSchool[id]].Max);
            tops.Add(school[newSchool].Max);

            currentSchool[id] = newSchool;

            Console.WriteLine(decode(tops.Min).rate);
        }
    }
}
