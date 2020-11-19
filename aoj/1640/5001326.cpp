// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1640/judge/5001326/C++17
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
  int n;
  while (cin >> n, n){  
    vector<int> d(n);
    for (int i = 0; i < n; i++){
      cin >> d[i];
    }
    int res = 0;
    for (int i = 3; i < n; i++){
      if (d[i - 3] == 2 && d[i - 2] == 0 && d[i - 1] == 2 && d[i] == 0) res++;
    }
    cout << res << endl;
  }
  return 0;
}
