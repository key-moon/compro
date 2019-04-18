// detail: https://yukicoder.me/submissions/339780
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<int> deck = Enumerable.Range(1, nm[0]).ToList();
        foreach (var operation in Console.ReadLine().Split().Select(int.Parse).ToArray())
        {
            var item = deck[operation - 1];
            deck.RemoveAt(operation - 1);
            deck.Insert(0, item);
        }
        Console.WriteLine(deck.First());
    }
}