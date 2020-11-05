// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1302/judge/4970816/C++17
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
  int n, m;
  while (cin >> m >> n, n){
    const int INF = INT_MAX / 2;
    vector<int> minstep((int)pow(3, m), INF);
    for (int i = 0; i < n; i++){
      string s;
      cin >> s;
      int encode = 0;
      for (var&& c : s){
        encode *= 3;
        encode += (c == '0' ? 0 : 1);
      }
      minstep[encode] = 0;
    }
    for (int b = 0; b < minstep.size(); b++){
      int base = 1;
      int cur = b;
      for (int i = 0; i < m; i++){
        var dig = cur % 3;
        if (dig == 2){
          var s1 = minstep[b - base];
          var s2 = minstep[b - base * 2];
          int step = max(s1, s2) + 1;
          if (s1 == INF) step = s2;
          if (s2 == INF) step = s1;
          chmin(minstep[b], step);
        }
        cur /= 3;
        base *= 3;
      }
    }
    cout << minstep.back() << endl;
  }
  return 0;
}

