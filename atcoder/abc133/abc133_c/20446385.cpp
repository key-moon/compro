// detail: https://atcoder.jp/contests/abc133/submissions/20446385
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll l, r;
  cin >> l >> r;
  if (r - l > 2019) {
    cout << 0 << endl;
  }
  else {
    ll res = INT_MAX;
    for (ll i = l; i <= r; i++) {
      for (ll j = i + 1; j <= r; j++) {
        chmin(res, i * j % 2019);
      }
    }
    cout << res << endl;
  }
}
