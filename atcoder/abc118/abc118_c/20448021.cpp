// detail: https://atcoder.jp/contests/abc118/submissions/20448021
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int gcd(int a, int b) {
  if (a == 0) return b;
  return gcd(b % a, a);
}

int main() {
  int n;
  cin >> n;
  int res = 0;
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    res = gcd(res, a);
  }
  cout << res << endl;
}
