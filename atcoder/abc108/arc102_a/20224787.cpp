// detail: https://atcoder.jp/contests/abc108/submissions/20224787
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using namespace std;

int main() {
  ll n, k;
  cin >> n >> k;
  ll res = 0;
  {
    ll cnt = n / k;
    res += cnt * cnt * cnt;
  }
  if (k % 2 == 0) {
    ll cnt = (n + k / 2) / k;
    res += cnt * cnt * cnt;
  }
  cout << res << endl;
}
