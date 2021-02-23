// detail: https://atcoder.jp/contests/abc094/submissions/20435578
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, m, x;
  cin >> n >> m >> x;
  vector<int> a(m);
  for (int i = 0; i < m; i++) cin >> a[i];
  var c1 = lower_bound(a.begin(), a.end(), x) - a.begin();
  var c2 = m - c1;
  cout << min(c1, c2) << endl;

}
