// detail: https://atcoder.jp/contests/agc004/submissions/20441138
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll a, b, c;
  cin >> a >> b >> c;
  var calc = [](ll ab, ll c) {
    return (c & 1) ? ab : 0;
  };
  ll res = INT64_MAX;
  chmin(res, calc(a * b, c));
  chmin(res, calc(a * c, b));
  chmin(res, calc(b * c, a));
  cout << res << endl;
}
