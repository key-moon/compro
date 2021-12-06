// detail: https://codeforces.com/contest/1611/submission/138142891
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {

        Console.ReadLine();
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var friends = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();

        List<int>[] g = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            g[st[0]].Add(st[1]);
            g[st[1]].Add(st[0]);
        }
        var par = new int[n];
        Stack<int> s = new Stack<int>();
        s.Push(0);
        par[0] = -1;
        while (s.Count != 0)
        {
            var elem = s.Pop();
            foreach (var item in g[elem])
            {
                if (par[elem] == item) continue;
                par[item] = elem;
                s.Push(item);
            }
        }
        var leaves = Enumerable.Range(1, n - 1).Where(x => g[x].Count == 1).ToHashSet();

        var reachable = new List<int>() { 0 };
        var curFriends = friends.ToList();
        bool[] reached = new bool[n];
        foreach (var friend in curFriends) reached[friend] = true;
        int res = 0;
        while (reachable.Count != 0)
        {
            List<int> newFriends = new List<int>();
            foreach (var friend in curFriends)
            {
                var nxt = par[friend];
                if (nxt == -1 || reached[nxt]) continue;
                newFriends.Add(nxt);
                reached[nxt] = true;
            }
            curFriends = newFriends;
            List<int> newReachable = new List<int>();
            foreach (var item in reachable)
            {
                foreach (var adj in g[item])
                {
                    if (par[item] == adj) continue;
                    if (reached[adj])
                    {
                        res++;
                        continue;
                    }
                    if (leaves.Contains(adj))
                    {
                        Console.WriteLine(-1);
                        return;
                    }
                    newReachable.Add(adj);
                }
            }
            reachable = newReachable;
        }
        Console.WriteLine(res);
    }
}