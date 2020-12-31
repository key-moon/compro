// detail: https://yukicoder.me/submissions/598636
using System;
using System.Linq;

public static class P
{
    public static void Main()
    {
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(a.Distinct().Count() == 4 && a.Max() - a.Min() == 3 ? "Yes" : "No");
    }
}
