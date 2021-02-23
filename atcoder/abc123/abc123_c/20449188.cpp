// detail: https://atcoder.jp/contests/abc123/submissions/20449188
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll n;
  cin >> n;
  ll mn = INT64_MAX;
  for (int i = 0; i < 5; i++) {
    ll a;
    cin >> a;
    chmin(mn, a);
  }
  cout << (n + mn - 1) / mn + 4 << endl;
}
