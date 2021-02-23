// detail: https://atcoder.jp/contests/abc108/submissions/20436082
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int x1, y1, x2, y2;
  cin >> x1 >> y1 >> x2 >> y2;
  var dy = x2 - x1;
  var dx = y1 - y2;
  cout
    << x2 + dx << ' '
    << y2 + dy << ' '
    << x1 + dx << ' '
    << y1 + dy << endl;
}