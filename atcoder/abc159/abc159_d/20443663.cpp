// detail: https://atcoder.jp/contests/abc159/submissions/20443663
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
  vector<int> a(n);
  vector<ll> cnt(n + 1);
  for (int i = 0; i < n; i++) {
    cin >> a[i];
    cnt[a[i]]++;
  }
  ll totalRes = 0;
  for (int i = 0; i <= n; i++) {
    totalRes += cnt[i] * (cnt[i] - 1) / 2;
  }
  for (int i = 0; i < n; i++) {
    ll res = totalRes;
    res -= cnt[a[i]] * (cnt[a[i]] - 1) / 2;
    res += (cnt[a[i]] - 1) * (cnt[a[i]] - 2) / 2;
    cout << res << endl;
  }
}
