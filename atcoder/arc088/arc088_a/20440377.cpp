// detail: https://atcoder.jp/contests/arc088/submissions/20440377
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll x, y;
  cin >> x >> y;
  int res = 1;
  while (true) {
    x *= 2;
    if (y < x) break;
    res++;
  }
  cout << res << endl;
}
