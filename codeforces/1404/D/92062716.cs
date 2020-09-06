// detail: https://codeforces.com/contest/1404/submission/92062716
#undef DEBUG

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
        int n = int.Parse(Console.ReadLine());
        if (n % 2 == 0)
        {
            Console.WriteLine("First");
            Console.WriteLine(string.Join(" ", Enumerable.Range(1, n).Concat(Enumerable.Range(1, n))));
        }
        else
        {
            Console.WriteLine("Second");
#if DEBUG
            var rng = new Random();
            var groups = Enumerable.Range(0, n).Concat(Enumerable.Range(0, n)).OrderBy(_ => rng.Next()).ToArray();
#else
            var groups = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
#endif
            int[][] elemForGroups = Enumerable.Repeat(0, n).Select(_ => new int[2]).ToArray();
            for (int i = 0; i < groups.Length; i++)
            {
                var group = elemForGroups[groups[i]];
                if (group[0] == 0) group[0] = i + 1;
                else group[1] = i + 1;
            }
            List<long> elems = new List<long>();
            bool[] groupTooked = new bool[n];
            for (int i = 0; i < groupTooked.Length; i++)
            {
                if (groupTooked[i]) continue;
                int toTake = elemForGroups[i][0];
                int curGroup = i;
                while (!groupTooked[curGroup])
                {
                    elems.Add(toTake);
                    groupTooked[curGroup] = true;
                    var cantTake = elemForGroups[curGroup][0] ^ elemForGroups[curGroup][1] ^ toTake;
                    
                    toTake = cantTake;
                    if (toTake <= n) toTake += n;
                    else toTake -= n;
                    curGroup = groups[toTake - 1];
                }
            }
            groupTooked = new bool[n];
            foreach (var item in elems)
            {
                if (groupTooked[groups[item - 1]]) throw new Exception();
                groupTooked[groups[item - 1]] = true;
            }
            var sum = elems.Sum();
            if (sum % (2 * n) != 0)
            {
                elems = Enumerable.Range(1, 2 * n).Select(x => (long)x).Except(elems).ToList();
                sum = elems.Sum();
                if (sum % (2 * n) != 0) throw new Exception();
            }
            Console.WriteLine(string.Join(" ", elems));
        }
        int.Parse(Console.ReadLine());
    }
}