// detail: https://atcoder.jp/contests/abc113/submissions/20437807
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, t, a;
  cin >> n >> t >> a;
  t *= 1000;
  a *= 1000;
  int res = -1;
  ll mn = INT64_MAX;
  for (int i = 0; i < n; i++) {
    ll h;
    cin >> h;
    var temp = t - h * 6;
    var d = abs(temp - a);
    if (d < mn) {
      mn = d;
      res = i + 1;
    }
  }
  cout << res << endl;
}
