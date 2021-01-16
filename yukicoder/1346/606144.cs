// detail: https://yukicoder.me/submissions/606144
using System;
public static class P
{
    public static void Main()
    {
        var n = long.Parse(Console.ReadLine());
        if (n == 2) Console.WriteLine("INF");
        else if (n <= 4) Console.WriteLine(6);
        else if (n <= 6) Console.WriteLine(4);
        else Console.WriteLine(2);
    }
}
