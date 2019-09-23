// detail: https://codeforces.com/contest/1229/submission/61131483
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var Users = a.Zip(b, (x, y) => new User() { Skill = x, Level = y }).ToArray();
        var grouped = Users.GroupBy(x => x.Skill).ToArray();

        List<long> mother = new List<long>();
        long res = 0;
        foreach (var item in grouped.Where(x => x.Count() >= 2))
        {
            mother.Add(item.Key);
            foreach (var user in item)
            {
                res += user.Level;
            }
        }

        foreach (var item in grouped.Where(x => x.Count() == 1))
        {
            if (mother.Any(x => (x & item.Key) == item.Key))
            {
                res += item.First().Level;
            }
        }
        Console.WriteLine(res);
    }
}

struct User
{
    public long Skill;
    public int Level;
}
