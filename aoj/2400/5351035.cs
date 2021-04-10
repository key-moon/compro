// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2400/judge/5351035/C#
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
        while (true)
        {
            var tpr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var t = tpr[0];
            var p = tpr[1];
            var r = tpr[2];

            int[][] wa = Enumerable.Range(0, t).Select(x => new int[p]).ToArray();
            int[] correct = new int[t];
            int[] penalties = new int[t];
            for (int i = 0; i < r; i++)
            {
                var log = Console.ReadLine().Split();
                var team = int.Parse(log[0]) - 1;
                var problem = int.Parse(log[1]) - 1;
                var time = int.Parse(log[2]);
                if (log[3] == "CORRECT")
                {
                    correct[team]++;
                    penalties[team] += time;
                    penalties[team] += wa[team][problem] * 1200;
                }
                if (log[3] == "WRONG")
                {
                    wa[team][problem]++;
                }
            }

            foreach (var res in correct.Zip(penalties, (ac, pena) => new { ac = ac, pena = pena }).Select((state, ind) => new { state = state, ind = ind }).OrderByDescending(x => x.state.ac).ThenBy(x => x.state.pena))
            {
                Console.WriteLine($"{res.ind + 1} {res.state.ac} {res.state.pena}");
            }

            if (t == 0) return;
        }
    }
}
