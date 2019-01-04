// detail: https://codeforces.com/contest/1097/submission/47942093
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] s = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).ToArray();
        Dictionary<int, int> dictl = s.Where(x => valL(x)).GroupBy(x => x.Aggregate(0, (c, y) => c + (y == '(' ? 1 : -1))).ToDictionary(x => x.Key, x => x.Count());
        Dictionary<int, int> dictr = s.Where(x => valR(x)).GroupBy(x => x.Aggregate(0, (c, y) => c + (y == ')' ? 1 : -1))).ToDictionary(x => x.Key, x => x.Count());
        int justCount = s.Where(valid).Count();
        int res = justCount / 2;
        foreach (var item in dictl)
        {
            int val = 0;
            if (dictr.TryGetValue(item.Key, out val))
            {
                res += Min(item.Value, val);
            }
        }
        Console.WriteLine(res);
    }
    static bool valR(string s)
    {
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(') count++;
            else count--;
            if (count < 0) return false;
        }
        return count != 0;
    }
    static bool valL(string s)
    {
        int count = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == ')') count++;
            else count--;
            if (count < 0) return false;
        }
        return count != 0;
    }
    static bool valid(string s)
    {
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(') count++;
            else count--;
            if (count < 0) return false;
        }
        count = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == ')') count++;
            else count--;
            if (count < 0) return false;
        }
        return true;
    }
}
/*using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{

    static long sum = 1;
    static void Main()
    {
        long[] nk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        //10752個 : 9316358251200
        //Dictionary<long, List<long>> divs = getDivs(nk[0]).ToDictionary(x => x, x => getDivs(x).ToList());
        var factor = factors(nk[0]).GroupBy(x => x).Select(x => new Tuple<long, long[]>(x.Key, getcount(x.Count(), (int)nk[1]))).ToArray();
        //それぞれの個数が何通りあるか
        //1/2+(1/2)
        IEnumerable<Tuple<long, long>> divs = Enumerable.Repeat(new Tuple<long, long>(1, 1), 1);
        foreach (var item in factor)
        {
            List<Tuple<long, long>> newl = new List<Tuple<long, long>>();
            foreach (var div in divs)
            {
                for (int i = 0; i < item.Item2.Length; i++)
                {
                    newl.Add(new Tuple<long, long>(power(item.Item1, i) * div.Item1, (item.Item2[i] * div.Item2) % 1000000007));
                }
            }
            divs = newl;
        }
        Console.WriteLine((divs.Aggregate(0L, (x, y) => x + (y.Item1 * y.Item2) % 1000000007) * power(sum, 1000000007 - 2)) % 1000000007);
    }

    static long[] getcount(int count, int repeatCount)
    {
        long[] res = new long[count + 1];

        res[0] = 1;
        //count = 1
        //12345678
        //count = 2
        //13610...
        //これで全部の合計が出るので、それで割ると確率が出うr
        for (int i = 1; i <= count; i++)
        {
            res[i] = ((res[i - 1] * (repeatCount + i - 1)) % 1000000007) * power(i, 1000000007 - 2);
            res[i] %= 1000000007;
        }
        sum *= res.Sum();
        sum %= 1000000007;
        Debug.WriteLine(string.Join(" ", res));
        return res;
    }

    static long power(long n, long m)
    {
        const int mod = 1000000007;
        long pow = n;
        long res = 1;
        while (m > 0)
        {
            if ((m & 1) == 1) res = (res * pow) % mod;
            pow = (pow * pow) % mod;
            m >>= 1;
        }
        return res;
    }

    static IEnumerable<long> getDivs(long num) => factors(num).GroupBy(x => x).Aggregate(Enumerable.Repeat(1L, 1), (x, y) => pows(y.Key, y.Count()).SelectMany(z => x.Select(w => w * z)));

    static IEnumerable<long> pows(long x,int y)
    {
        long pow = 1;
        for (int i = 0; i < y; i++)
        {
            yield return pow;
            pow *= x;
        }
        yield return pow;
    }

    static long[] factors(long n)
    {
        long i = 3;
        List<long> res = new List<long>();
        while (n != 0 && n % 2 == 0)
        {
            res.Add(2);
            n /= 2;
        }
        while (i * i <= n)
        {
            if (n % i == 0)
            {
                res.Add(i);
                n /= i;
            }
            else
            {
                i += 2;
            }
        }
        if (n != 1) res.Add(n);
        return res.ToArray();
    }
}
*/