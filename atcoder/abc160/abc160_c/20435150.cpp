// detail: https://atcoder.jp/contests/abc160/submissions/20435150
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int k, n;
  cin >> k >> n;
  vector<int> a(n);
  for (int i = 0; i < n; i++) cin >> a[i];
  a.emplace_back(a[0] + k);
  int res = INT_MAX;
  for (int i = 0; i < n; i++) {
    chmin(res, k - (a[i + 1] - a[i]));
  }
  cout << res << endl;
}
