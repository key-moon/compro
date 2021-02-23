// detail: https://atcoder.jp/contests/abc156/submissions/20434710
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
  int res = INT_MAX;
  for (int p = 0; p <= 100; p++) {
    int cur = 0;
    for (var&& item : a) {
      cur += (item - p) * (item - p);
    }
    chmin(res, cur);
  }
  cout << res << endl;
}
