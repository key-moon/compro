// detail: https://yukicoder.me/submissions/598633
using System;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(n % 180 == 90 ? "Yes" : "No");
    }
}
