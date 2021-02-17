// detail: https://atcoder.jp/contests/abc108/submissions/20224678
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using namespace std;

int main() {
  int x1, y1, x2, y2;
  cin >> x1 >> y1 >> x2 >> y2;

  int x3, y3;
  x3 = x2 - (y2 - y1);
  y3 = y2 - (x1 - x2);
  int x4, y4;
  x4 = x3 - (x2 - x1);
  y4 = y3 - (y2 - y1);
  cout << x3 << " " << y3 << " " << x4 << " " << y4 << endl;
}
