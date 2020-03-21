// detail: https://yukicoder.me/submissions/447595
using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class P
{
    static void Main()
    {
        var s = Console.ReadLine().TrimStart('ｗ');
        var maxLen = Regex.Matches(s, @"ｗ+").DefaultIfEmpty(Match.Empty).Max(x => x.Value.Length);
        if (maxLen == 0) return;
        var res = Regex.Matches(s, $@"([^ｗ]+)ｗ{{{maxLen}}}").Select(x => x.Groups[1].Value).ToArray();
        Console.WriteLine(string.Join("\n", res));
    }
}
