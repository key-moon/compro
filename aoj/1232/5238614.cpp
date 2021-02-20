// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1232/judge/5238614/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

const int MAX_M = 100000;

int main() {
  vector<bool> isPrime(MAX_M + 1, true);
  isPrime[0] = false;
  isPrime[1] = false;
  for (int i = 2; i <= MAX_M; i++) {
    if (!isPrime[i]) continue;
    for (int j = i * 2; j <= MAX_M; j += i) isPrime[j] = false;
  }
  vector<int> primes{0};
  for (int i = 0; i <= MAX_M; i++) if (isPrime[i]) primes.emplace_back(i);

  int m, a, b;
  while (cin >> m >> a >> b, m) {
    ll P, Q;
    ll mx = 0;
    for (int i = (int)primes.size() - 1; i >= 0; i--) {
      ll q = primes[i];
      if (q * q < mx) break;
      ll maxp = min(q, m / q);
      ll p = *(upper_bound(primes.begin(), primes.end(), maxp) - 1);
      // a/b > p/q
      if (a * q > p * b) continue;
      if (mx >= p * q) continue;
      mx = p * q;
      P = p;
      Q = q;
    }
    cout << P << " " << Q << endl;
  }
}

