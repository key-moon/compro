// detail: https://atcoder.jp/contests/agc027/submissions/20435749
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, x;
  cin >> n >> x;
  vector<int> a(n);
  for (int i = 0; i < n; i++) cin >> a[i];
  sort(a.begin(), a.end());
  int res = 0;
  for (var&& v : a) {
    if (x < v) break;
    x -= v;
    res++;
  }
  if (res == n && x != 0) res--;
  cout << res << endl;
}
