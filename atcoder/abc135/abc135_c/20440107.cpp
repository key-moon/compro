// detail: https://atcoder.jp/contests/abc135/submissions/20440107
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
  vector<ll> a(n + 1);
  for (int i = 0; i <= n; i++) cin >> a[i];

  ll res = 0;
  ll prev = a[0];
  for (int i = 0; i < n; i++) {
    var cur = a[i + 1];
    ll b;
    cin >> b;
    ll d;
    d = min(prev, b);
    b -= d;
    prev -= d;
    res += d;
    d = min(cur, b);
    b -= d;
    cur -= d;
    res += d;
    prev = cur;
  }
  cout << res << endl;
}
