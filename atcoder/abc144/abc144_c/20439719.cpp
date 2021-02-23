// detail: https://atcoder.jp/contests/abc144/submissions/20439719
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll n;
  cin >> n;
  ll res = LLONG_MAX;
  for (ll i = 1; i * i <= n; i++) {
    if (n % i != 0) continue;
    var j = n / i;
    chmin(res, i + j - 2);
  }
  cout << res << endl;
}
