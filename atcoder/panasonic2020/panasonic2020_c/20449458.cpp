// detail: https://atcoder.jp/contests/panasonic2020/submissions/20449458
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
  // sqrt(a) + sqrt(b) < sqrt(c)
  // a + b + 2*sqrt(ab) < c
  // 2*sqrt(ab) < c - a - b
  // 4*ab < (c - a - b) * (c - a - b) (c - a - b >= 0)
  if (0 <= c - a - b && 4 * a * b < (c - a - b) * (c - a - b)) {
    cout << "Yes" << endl;
  }
  else {
    cout << "No" << endl;
  }
}
