// detail: https://yukicoder.me/submissions/332450
using System;using System.Linq;class P{static void Main(){Console.WriteLine(string.Join("\n",Enumerable.Repeat(0,int.Parse(Console.ReadLine())).Select(_=>Console.ReadLine().Split()).OrderBy(x=>x[0]).ThenBy(x=>x[1][0]).Select(x=>$"{x[0]} {x[1]}")));}}