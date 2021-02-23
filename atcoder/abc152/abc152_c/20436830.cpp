// detail: https://atcoder.jp/contests/abc152/submissions/20436830
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  cin >> n;
  int mn = INT_MAX;
  int res = 0;
  for (int i = 0; i < n; i++) {
    int p;
    cin >> p;
    chmin(mn, p);
    if (p <= mn) res++;
  }
  cout << res << endl;
}
