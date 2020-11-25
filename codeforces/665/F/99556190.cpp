// detail: https://codeforces.com/contest/665/submission/99556190
#include<bits/stdc++.h>
using namespace std;
#define var auto

// Credit: Min_25

using ll = long long;
using i64 = long long;
int isqrt(i64 n) {
  return sqrtl(n);
}

__attribute__((target("avx"), optimize("O3", "unroll-loops")))
i64 prime_pi(const i64 N) {
  if (N <= 1) return 0;
  if (N == 2) return 1;
  const int v = isqrt(N);
  int s = (v + 1) / 2;
  vector<int> smalls(s); for (int i = 1; i < s; ++i) smalls[i] = i;
  vector<int> roughs(s); for (int i = 0; i < s; ++i) roughs[i] = 2 * i + 1;
  vector<i64> larges(s); for (int i = 0; i < s; ++i) larges[i] = (N / (2 * i + 1) - 1) / 2;
  vector<bool> skip(v + 1);
  const auto divide = [] (i64 n, i64 d) -> int { return double(n) / d; };
  const auto half = [] (int n) -> int { return (n - 1) >> 1; };
  int pc = 0;
  for (int p = 3; p <= v; p += 2) if (!skip[p]) {
    int q = p * p;
    if (i64(q) * q > N) break;
    skip[p] = true;
    for (int i = q; i <= v; i += 2 * p) skip[i] = true;
    int ns = 0;
    for (int k = 0; k < s; ++k) {
      int i = roughs[k];
      if (skip[i]) continue;
      i64 d = i64(i) * p;
      larges[ns] = larges[k] - (d <= v ? larges[smalls[d >> 1] - pc] : smalls[half(divide(N, d))]) + pc;
      roughs[ns++] = i;
    }
    s = ns;
    for (int i = half(v), j = ((v / p) - 1) | 1; j >= p; j -= 2) {
      int c = smalls[j >> 1] - pc;
      for (int e = (j * p) >> 1; i >= e; --i) smalls[i] -= c;
    }
    ++pc;
  }
  larges[0] += i64(s + 2 * (pc - 1)) * (s - 1) / 2;
  for (int k = 1; k < s; ++k) larges[0] -= larges[k];
  for (int l = 1; l < s; ++l) {
    int q = roughs[l];
    i64 M = N / q;
    int e = smalls[half(M / q)] - pc;
    if (e < l + 1) break;
    i64 t = 0;
    for (int k = l + 1; k <= e; ++k) t += smalls[half(divide(M, roughs[k]))];
    larges[0] += t - i64(e - l) * (pc + l - 1);
  }
  return larges[0] + 1;
}

vector<int> sieve(const int N, const int Q = 17, const int L = 1 << 15) {
    static const int rs[] = {1, 7, 11, 13, 17, 19, 23, 29};
    struct P {
        P(int p) : p(p) {}
        int p;
        int pos[8];
    };

    auto approx_prime_count = [] (const int N) -> int {
        return N > 60184 ? N / (log(N) - 1.1)
        : max(1., N / (log(N) - 1.11)) + 1;
    };

    const int v = sqrt(N), vv = sqrt(v);
    vector<bool> isp(v + 1, true);
    for (int i = 2; i <= vv; ++i) if (isp[i]) {
            for (int j = i * i; j <= v; j += i) isp[j] = false;
        }

    const int rsize = approx_prime_count(N + 30);
    vector<int> primes = {2, 3, 5};
    int psize = 3;
    primes.resize(rsize);

    vector<P> sprimes;
    size_t pbeg = 0;
    int prod = 1;
    for (int p = 7; p <= v; ++p) {
        if (!isp[p]) continue;
        if (p <= Q) prod *= p, ++pbeg, primes[psize++] = p;
        auto pp = P(p);
        for (int t = 0; t < 8; ++t) {
            int j = (p <= Q) ? p : p * p;
            while (j % 30 != rs[t]) j += p << 1;
            pp.pos[t] = j / 30;
        }
        sprimes.push_back(pp);
    }

    vector<unsigned char> pre(prod, 0xFF);
    for (size_t pi = 0; pi < pbeg; ++pi) {
        auto pp = sprimes[pi];
        const int p = pp.p;
        for (int t = 0; t < 8; ++t) {
            const unsigned char m = ~(1 << t);
            for (int i = pp.pos[t]; i < prod; i += p) pre[i] &= m;
        }
    }

    const int block_size = (L + prod - 1) / prod * prod;
    vector<unsigned char> block(block_size);
    unsigned char* pblock = block.data();
    const int M = (N + 29) / 30;

    for (int beg = 0; beg < M; beg += block_size, pblock -= block_size) {
        int end = min(M, beg + block_size);
        for (int i = beg; i < end; i += prod) {
            copy(pre.begin(), pre.end(), pblock + i);
        }
        if (beg == 0) pblock[0] &= 0xFE;
        for (size_t pi = pbeg; pi < sprimes.size(); ++pi) {
            auto& pp = sprimes[pi];
            const int p = pp.p;
            for (int t = 0; t < 8; ++t) {
                int i = pp.pos[t];
                const unsigned char m = ~(1 << t);
                for (; i < end; i += p) pblock[i] &= m;
                pp.pos[t] = i;
            }
        }
        for (int i = beg; i < end; ++i) {
            for (int m = pblock[i]; m > 0; m &= m - 1) {
                primes[psize++] = i * 30 + rs[__builtin_ctz(m)];
            }
        }
    }
    assert(psize <= rsize);
    while (psize > 0 && primes[psize - 1] > N) --psize;
    primes.resize(psize);
    return primes;
}

int main(){
  ll n;
  cin >> n;
  ll half = 0;
  while (half * half <= n) half++;
  half--;
  ll quad = 0;
  while (quad * quad * quad <= n) quad++;
  quad--;
  var primes = sieve((int)half);
  ll cur_cnt = 0;
  ll res = 0;
  for (var prime : primes){
    cur_cnt++;
    res += prime_pi(n / prime) - cur_cnt;
    if (prime <= quad) res++;
  }
  cout << res << endl;
}
