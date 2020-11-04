// detail: https://atcoder.jp/contests/kupc2017/submissions/17875053
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2>
inline bool chmin(T1 &a, T2 b) { bool c = a > b; if (c) a = b; return c; }
template<typename T1, typename T2>
inline bool chmax(T1 &a, T2 b) { bool c = a < b; if (c) a = b; return c; }

signed main() {
  cin.tie(0);
  ios::sync_with_stdio(0);
  int n, s, t;
  cin >> n >> s >> t;
  for (int i = 0; s <= t; i++, t >>= 1){
    if (s == t) {
      cout << i << endl;
      return 0;
    }
  }
  cout << -1 << endl;
  return 0;
}
