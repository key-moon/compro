// detail: https://atcoder.jp/contests/abc083/submissions/20437439
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, a, b;
  cin >> n >> a >> b;
  ll res = 0;
  for (int i = 1; i <= n; i++) {
    var s = to_string(i);
    int val = 0;
    for (var&& c : s) {
      val += c - '0';
    }
    if (a <= val && val <= b) res += i;
  }
  cout << res << endl;
}
