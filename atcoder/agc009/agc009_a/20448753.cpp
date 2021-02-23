// detail: https://atcoder.jp/contests/agc009/submissions/20448753
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
  using P = pair<ll, ll>;
  vector<P> v(n);
  for (int i = 0; i < n; i++) cin >> v[i].first >> v[i].second;
  ll cur = 0;
  for (int i = n - 1; i >= 0; i--) {
    var a = v[i].first;
    var b = v[i].second;
    a = (b - a % b) % b;
    if (a < cur % b) {
      cur += b - cur % b;
    }
    cur += a - cur % b;
  }
  cout << cur << endl;
}
