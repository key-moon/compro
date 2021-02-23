// detail: https://atcoder.jp/contests/abc109/submissions/20444839
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

ll gcd(ll a, ll b) {
  return a == 0 ? b : gcd(b % a, a);
}

int main() {
  int n, X;
  cin >> n >> X;
  ll res = 0;
  for (int i = 0; i < n; i++) {
    int x;
    cin >> x;
    res = gcd(res, abs(X - x));
  }
  cout << res << endl;
}
