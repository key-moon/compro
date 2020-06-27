// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2857/judge/4620744/C#
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
        var s = Console.ReadLine();
        int n = s.Count(x => char.IsLetter(x));
        var tournament = Node.Parse(s) as Tournament;
        int[] wins = new int[26];
        for (int i = 0; i < n; i++)
        {
            var av = Console.ReadLine().Split();
            var a = av[0][0] - 'a';
            var v = int.Parse(av[1]);
            wins[a] = v;
        }
        foreach (var person in tournament.People())
        {
            var win = wins[person.ID];
            var current = person as Node;
            for (int i = 0; i <= win; i++)
            {
                if (current == null || current.Winner != null) goto end;
                current.Winner = person;
                current = current.Parent;
            }
        }
        if (Node.Fixed(tournament)) 
        {
            Console.WriteLine("Yes");
            return;
        }
        
        end:;
        Console.WriteLine("No");
    }
}

class Node
{
    public Tournament Parent;
    public Person Winner;
    public static bool Fixed(Node node)
    {
        if (node is Person) return true;
        var tournament = node as Tournament;
        return tournament.Winner != null && Fixed(tournament.L) && Fixed(tournament.R);
    }
    public static Node Parse(string s)
    {
        if (!(s[0] == '[')) return new Person() { ID = s[0] - 'a' };
        var depth = 0;
        Node l = null;
        Node r = null;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '[') depth++;
            else if (s[i] == ']') depth--;
            else if (s[i] == '-' && depth == 1)
            {
                l = Parse(s.Substring(1, i - 1));
                r = Parse(s.Substring(i + 1, s.Length - i - 2));
            }
        }
        var res = new Tournament() { L = l, R = r };
        res.L.Parent = res;
        res.R.Parent = res;
        return res;
    }
}

class Tournament : Node
{
    public Node L;
    public Node R;
    public IEnumerable<Person> People()
    {
        IEnumerable<Person> l;
        if (L is Person) l = new[] { L as Person };
        else l = (L as Tournament).People();
        IEnumerable<Person> r;
        if (R is Person) r = new[] { R as Person };
        else r = (R as Tournament).People();
        return l.Concat(r);
    }
}

class Person : Node
{
    public int ID;
}


