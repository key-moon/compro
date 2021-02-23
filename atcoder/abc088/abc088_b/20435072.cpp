// detail: https://atcoder.jp/contests/abc088/submissions/20435072
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
  for (int i = 0; i < n; i++) cin >> a[i];
  sort(a.begin(), a.end(), greater<int>());
  int res = 0;
  for (int i = 0; i < n; i++) {
    if (i & 1) res -= a[i];
    else res += a[i];
  }
  cout << res << endl;
}
