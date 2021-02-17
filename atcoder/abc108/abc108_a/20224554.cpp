// detail: https://atcoder.jp/contests/abc108/submissions/20224554
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using namespace std;

int main() {
  int k;
  cin >> k;
  cout << (k / 2) * ((k + 1) / 2) << endl;
}
