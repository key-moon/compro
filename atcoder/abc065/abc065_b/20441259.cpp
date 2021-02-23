// detail: https://atcoder.jp/contests/abc065/submissions/20441259
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
  for (int i = 0; i < n; i++) {
    cin >> a[i];
    a[i]--;
  }
  int res = 0;
  int cur = 0;
  for (int i = 0; i <= n; i++) {
    cur = a[cur];
    res++;
    if (cur == 1) {
      cout << res << endl;
      return 0;
    }
  }
  cout << -1 << endl;
}
