// detail: https://atcoder.jp/contests/agc008/submissions/20449203
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int x, y;
  cin >> x >> y;
  var solve = [](ll from, ll to) {
    if (from > to) return LLONG_MAX / 2;
    return to - from;
  };
  ll res = solve(x, y);
  chmin(res, solve(-x, y) + 1);
  chmin(res, solve(x, -y) + 1);
  chmin(res, solve(-x, -y) + 2);
  cout << res << endl;
}
