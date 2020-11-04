// detail: https://atcoder.jp/contests/kupc2017/submissions/17875017
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2>
inline bool chmin(T1 &a, T2 b) { bool c = a > b; if (c) a = b; return c; }
template<typename T1, typename T2>
inline bool chmax(T1 &a, T2 b) { bool c = a < b; if (c) a = b; return c; }

signed main() {
  cin.tie(0);
  ios::sync_with_stdio(0);
  int n, k;
  cin >> n >> k;
  vector<int> a(n);
  for (int i = 0; i < n; i++){
    cin >> a[i];
  }
  sort(a.begin(), a.end());
  ll res = 0;
  int cnt = 0;
  for (int i = n - 1; i >= 0; i--){
    res += a[i];
    cnt++;
    if (k <= res){
      cout << cnt << endl;
      return 0;
    }
  }
  cout << -1 << endl;
  return 0;
}
