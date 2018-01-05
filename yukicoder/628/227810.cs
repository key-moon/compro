// detail: https://yukicoder.me/submissions/227810
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, int> tagdict = new Dictionary<string, int>();
        for (int i = 0; i < n; i++)
        {
            Console.ReadLine();
            int point = int.Parse(Console.ReadLine().Split()[1]);
            string[] tags = Console.ReadLine().Split();
            foreach (var tag in tags)
            {
                if (!tagdict.ContainsKey(tag)) tagdict.Add(tag, point);
                else tagdict[tag] += point;
            }
        }
        Console.WriteLine(string.Join("\n", tagdict.OrderBy(x => (int.MaxValue - x.Value).ToString().PadLeft(11,'0') + x.Key).Take(10).Select(x => $"{x.Key} {x.Value}")));
    }
}