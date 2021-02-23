// detail: https://atcoder.jp/contests/arc099/submissions/20445010
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, k;
  cin >> n >> k;
  vector<int> a(n);
  for (int i = 0; i < n; i++) cin >> a[i];
  var ind = min_element(a.begin(), a.end()) - a.begin();
  var res = 0;
  res += (ind + k - 2) / (k - 1);
  res += (n - ind - 1 + k - 2) / (k - 1);
  chmin(res, (n - 1 + k - 2) / (k - 1));
  cout << res << endl;
}
