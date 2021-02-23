// detail: https://atcoder.jp/contests/abc130/submissions/20446216
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll w, h, x, y;
  cin >> w >> h >> x >> y;
  cout << w * h / 2.0 << " ";
  cout << (x * 2 == w && y * 2 == h ? 1 : 0) << endl;
}
