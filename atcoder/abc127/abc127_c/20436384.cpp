// detail: https://atcoder.jp/contests/abc127/submissions/20436384
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, m;
  cin >> n >> m;
  int lb = 1;
  int ub = n;
  for (int i = 0; i < m; i++) {
    int l, r;
    cin >> l >> r;
    chmax(lb, l);
    chmin(ub, r);
  }
  cout << max(0, ub - lb + 1) << endl;
}
